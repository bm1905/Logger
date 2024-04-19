using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Logger.Base
{
    public class Property
    {
        public IReadOnlyDictionary<string, string> Properties { get; }

        public Property(IDictionary<string, string> properties) : this((IEnumerable<KeyValuePair<string, string>>)properties)
        {

        }

        public Property(IEnumerable<KeyValuePair<string, string>> properties)
        {
            Properties = new ReadOnlyDictionary<string, string>(properties.ToDictionary(k => k.Key, v => v.Value));
        }

        public Property(params string[] items)
        {
            int length = items.Length;
            if (length % 2 != 0)
            {
                length--;
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int x = 0, y = 1; y < length; x += 2, y += 2)
            {
                dictionary.Add(items[x], items[y]);
            }

            Properties = new ReadOnlyDictionary<string, string>(dictionary);
        }

        public static implicit operator Property(Dictionary<string, string> dictionary)
        {
            return new Property(dictionary);
        }

        public static implicit operator Property(string[] items)
        {
            return new Property(items);
        }
    }
}
