using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalString = "JKL;";
            string transformations = "H V -1";

            var mtrx = new KeyboardMatrix();
            mtrx.Initialize();
            mtrx.Transform(originalString, transformations);
            Console.WriteLine($"Original string: {originalString} \n" +
                $"after the transformations: {transformations} \n" +
                $"became the string: {mtrx.TransformedString}");

            Console.ReadKey();
        }
    }
}
