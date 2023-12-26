
using System;
using System.Diagnostics;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            F newF = F.Get();
            Type typeF = typeof(F);

            // Reflection serialize
            stopwatch.Start();
            string serializedS = SerializHelper.ReflectionSerialize(typeF, newF);
            stopwatch.Stop();
            Console.WriteLine($"ReflectionSerialize execution time in {SerializHelper.iterCount} iterations = {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Serialized string by reflection: ");
            Console.WriteLine(serializedS);
            stopwatch.Stop();
            Console.WriteLine($"SerializString output time = {stopwatch.ElapsedMilliseconds} ms");

            // Json serialize
            stopwatch.Reset();
            stopwatch.Start();
            serializedS = SerializHelper.JsonSerialize(newF);
            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine($"JsonSerialize execution time = {stopwatch.ElapsedMilliseconds} ms");

            // Json deserialize
            stopwatch.Reset();
            stopwatch.Start();
            var fObj = SerializHelper.JsonDesearialize<F>(serializedS);
            stopwatch.Stop();
            Console.WriteLine($"JsonDesearialize execution time = {stopwatch.ElapsedMilliseconds} ms");

            // Csv serialize
            stopwatch.Reset();
            stopwatch.Start();
            serializedS = SerializHelper.CsvSerialize(typeF, newF);
            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine($"CsvSerialize execution time = {stopwatch.ElapsedMilliseconds} ms");

            // Csv deserialize
            stopwatch.Reset();
            stopwatch.Start();
            var obj = SerializHelper.CsvDeserialize(typeF, serializedS);
            stopwatch.Stop();
            Console.WriteLine($"CsvDeserialize execution time = {stopwatch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
