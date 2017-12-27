using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace lab6_2
{
    class Program
    {
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        static void Main(string[] args)
        {
            Cat mycat = new Cat();
            Type t = mycat.GetType();

            Console.WriteLine("\nИнформация о типе");

            Console.WriteLine("Namespace " + t.Namespace);
            Console.WriteLine("Assembly Qualified " + t.AssemblyQualifiedName);
            Console.WriteLine("\nКонструкторы");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nData (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nАтрибуты свойств:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }

            Console.WriteLine("\nМетод использования рефлексии");
            Cat myCat = (Cat)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            object[] parameters = new object[] { 2, 5 };

            object Result = t.InvokeMember("Cat_moves", BindingFlags.InvokeMethod, null, myCat, parameters);
            Console.WriteLine("Current place " + Result);
            Console.WriteLine("\nНажмите любую кнопку для продолжения");
            Console.Read();

        }
    }
}