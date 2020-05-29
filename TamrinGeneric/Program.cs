using System;
using System.IO;

namespace TamrinGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var genericclass = new GenericClass<Person>();
            string textpath = Path.Combine(Environment.CurrentDirectory, "TextFile.txt");

            genericclass.ReadFileToObject(textpath);
        }
    }
}
