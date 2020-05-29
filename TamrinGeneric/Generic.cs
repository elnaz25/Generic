using System;
using System.IO;
using System.Reflection;

namespace TamrinGeneric
{
    public class GenericClass<T> where T : class , new ()
    {

        public object ReadFileToObject(string fileName)
        {

            var type = typeof(T);
            var obj = Activator.CreateInstance(type);
            var result = obj;
            string[] lines = File.ReadAllLines(fileName);
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string propName = lines[i].Split(':')[0].Trim();
                    string value = lines[i].Split(':')[1].Trim();

                    if (prop.Name.ToLower() == propName.ToLower())
                    {
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
                        break;
                    }
                }
            }
            
            return result;
        }
    }
}
