using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallbackSampleImplementation
{

    #region Tasks

    public class ProcessTaskResult
    {
        public bool success { get; set; } = true;
        public System.Net.HttpStatusCode? httpcode { get; set; } = null;


        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProcessTaskResult() : base() { }


        public ProcessTaskResult(System.Net.HttpStatusCode failurecode) : this()
        {
            this.success = false;
            this.httpcode = failurecode;
        }

        #endregion

    }

    #endregion

    /// <summary>
    /// AES
    /// Extensions
    /// </summary>
    public static class Auxilary
    {

        #region Objects Extensions



        /// <summary>
        /// Safe Null Check
        /// </summary>
        /// <typeparam name="T">implicit type parameter 'T'</typeparam>
        /// <param name="entity">self</param>
        /// <returns>true if null</returns>
        public static bool IsNull<T>(this T entity)
          => !(entity is object);

        #endregion


        #region String Extensions

        /// <summary>
        /// checks IsNullOrEmpty and IsNullOrWhiteSpace
        /// </summary>
        /// <param name="text">self</param>
        /// <returns>true if null or empty string</returns>
        public static bool IsTextNull(this string text)
            => (string.IsNullOrEmpty(text) ||
            string.IsNullOrWhiteSpace(text));

        #endregion


        #region Collections

        /// <summary>
        /// Usage: Partitioning and Parallel Tasks (async lambda)
        /// Note: CRUID operation issue (especially for mongodb bulk inserts; ids must be synchronized) where by reference does not work after chunking on the original list.  
        /// </summary>
        public static IEnumerable<IEnumerable<T>> GetChunks<T>(this IEnumerable<T> elements, int size)
        {
            if (elements.IsNullOrEmpty())
                yield return null;

            var list = elements.ToList();
            while (list.Count > 0)
            {
                var chunk = list.Take(size);
                yield return chunk;

                list = list.Skip(size).ToList();
            }
        }

        /// <summary>
        /// An AddRange Extension for anything that implements IList
        /// </summary>
        /// <typeparam name="T">implicit type parameter 'T'</typeparam>
        /// <param name="list">list to add to</param>
        /// <param name="values">values or list to add</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> values)
        {
            if (values == null)
                return;

            if (list == null)
                list = new List<T>();

            foreach (var value in values.ToList())
                list.Add(value);
        }

        /// <summary>
        /// Safe why to check if a collection/list/enumerable is null or has a count of 0
        /// </summary>
        /// <typeparam name="T">implicit type parameter 'T'</typeparam>
        /// <param name="list">anything that implements IEnumerable</param>
        /// <returns>true if count = 0 or null</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
            => (list != null) ?
            (list.ToList().Count == 0) :
            true;

        /// <summary>
        /// Safe Find Index
        /// </summary>
        public static int FindIndex<T>(this ICollection<T> collection, Predicate<T> match)
        {
            if (collection == null)
                return -1;

            if (collection.Count == 0)
                return -1;


            return collection.ToList().FindIndex(match);
        }

        /// <summary>
        /// Safe and Quick Remove Item
        /// </summary>
        public static void RemoveItem<T>(this IList<T> collection, Predicate<T> match)
        {
            if (collection == null)
                return;

            if (collection.Count == 0)
                return;

            int index = collection.FindIndex(match);
            if (index == -1)
                return;
            collection.RemoveAt(index);
        }

        #endregion

        #region Dictionary Extensions

        /// <summary>
        /// Getter
        /// </summary>
        public static VT Get<KT, VT>(this IDictionary<KT, VT> dictionary, KT key, VT defaultValue = default(VT))
        {
            if (dictionary == null)
                return defaultValue;
            VT value;
            if (dictionary.TryGetValue(key, out value))
                return value;
            return defaultValue;
        }

        /// <summary>
        /// Setter
        /// </summary>
        public static void Set<KT, VT>(this IDictionary<KT, VT> dictionary, KT key, VT value)
        {
            if (!dictionary.ContainsKey(key))
                lock (dictionary)
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, value);
                        return;
                    }

            dictionary[key] = value;
        }

        /// <summary>
        /// Scramble Dictionary
        /// </summary>
        public static Dictionary<TKey, TValue> Scramble<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            int size = dict.Count;
            List<int> Scrindex = new List<int>();
            Scrindex = Enumerable.Range(0, size).ToList();
            for (int i = Scrindex.Count - 1; i > 0; i--)
            {
                int randomIndex = rand.Next(0, i + 1);



                int temp = Scrindex[i];
                Scrindex[i] = Scrindex[randomIndex];
                Scrindex[randomIndex] = temp;
            }
            Dictionary<TKey, TValue> sdict = new Dictionary<TKey, TValue>();
            for (int j = 0; j < size; j++)
            {
                int rindex = Scrindex[j];
                sdict.Add(dict.Keys.ToList()[rindex], dict.Values.ToList()[rindex]);
            }
            return sdict;
        }

        #endregion

        #region Other

        /// <summary>
        /// Will return null if the CLR datetime will not fit in an SQL datetime
        /// </summary>
        /// <param name="datetime">self</param>
        /// <returns>DateTime value or null</returns>
        public static DateTime? EnsureSQLSafe(this DateTime? datetime)
        => (datetime.HasValue && (datetime.Value < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue || datetime.Value > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)) ?
                null :
                datetime;

        #endregion

    }

    #region Enum Extensions

    /// <summary>
    /// AES
    /// Enum Extensions
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// Converts a string to a type enum
        /// </summary>
        /// <typeparam name="TEnum">enum type to be converted to</typeparam>
        /// <param name="source">string value to convert</param>
        /// <param name="ignoreCase">is case ignored</param>
        /// <param name="throwconversionexceptions">throw conversion exceptions or return a default value (nullable returns null) [InvalidOperationException]</param>
        /// <returns>converted enum or default or [InvalidOperationException]</returns>
        public static TEnum FromStringToEnum<TEnum>(this string source, bool ignoreCase = true, bool throwconversionexceptions = false) where TEnum : struct
        {

            if (!typeof(TEnum).IsEnum)
                throw new InvalidOperationException("enumeration type required.");
            if (source.IsTextNull())
                return default(TEnum);

            TEnum result;
            if (!Enum.TryParse(source, ignoreCase, out result))
            {
                if (throwconversionexceptions)
                    throw new InvalidOperationException("conversion failure.");
                else
                    return default(TEnum);
            }

            return result;
        }

        /// <summary>
        /// Converts one enum type to another by matching string names
        /// </summary>
        /// <typeparam name="TEnum">enum type to be converted to</typeparam>
        /// <param name="source">enum value to convert</param>
        /// <param name="ignoreCase">is case ignored</param>
        /// <returns>converted enum type or default or [InvalidOperationException]</returns>
        public static TEnum ConvertByName<TEnum>(this Enum source, bool ignoreCase = true) where TEnum : struct
        {
            // if limited by lack of generic enum constraint
            if (!typeof(TEnum).IsEnum)
                throw new InvalidOperationException("enumeration type required.");

            TEnum result;
            if (!Enum.TryParse(source.ToString(), ignoreCase, out result))
                throw new InvalidOperationException("conversion failure.");

            return result;
        }

        /// <summary>
        /// Renders a list of enums values from a Concrete Enum Structure
        /// </summary>
        /// <typeparam name="T">parameter type 'T'</typeparam>
        /// <returns>list of enum values</returns>
        public static IEnumerable<T> GetValues<T>()
            => Enum.GetValues(typeof(T)).Cast<T>();
    }

    #endregion


    #region Attributes

    public static class AttributeExtensions
    {

        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (att != null)
                return valueSelector(att);

            return default(TValue);
        }

    }


    #endregion

}
