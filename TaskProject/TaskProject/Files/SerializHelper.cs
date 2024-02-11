using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class SerializHelper
    {
        public const int iterCount = 10000;

        public static string ReflectionSerialize(Type type, Object obj)
        {
            string res = string.Empty;
            
            var fields = type.GetFields();

            for (int i = 0; i < iterCount; i++)
            {
                res = string.Empty;

                foreach (var f in fields)
                {
                    res += $"Field {f.Name}, Value = {f.GetValue(obj)}" + Environment.NewLine;
                }
            }

            return res;
        }

        public static string JsonSerialize(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonDesearialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string CsvSerialize(Type type, Object obj)
        {
            string res = string.Empty;

            var fields = type.GetFields();

            res = string.Empty;
            // Fields names
            res += String.Join(";", fields.Select(x => x.Name).ToList()) + Environment.NewLine;
            // Fields values
            res += String.Join(";", fields.Select(x => x.GetValue(obj)).ToList());

            return res;
        }

        public static Object CsvDeserialize(Type type, string data)
        {
            var obj = Activator.CreateInstance(type);

            var names = data.Substring(0, data.IndexOf(Environment.NewLine)).Split(';').ToList();
            var values = data.Substring(data.IndexOf(Environment.NewLine)+2).Split(';');

            foreach (var f in type.GetFields())
            {
                var index = names.IndexOf(f.Name);
                if (index != -1)
                {
                    f.SetValue(obj, Convert.ChangeType(values[index], f.FieldType));
                }
            }

            return obj;
        }
    }
}
