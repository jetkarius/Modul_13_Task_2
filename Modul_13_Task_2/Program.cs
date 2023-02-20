using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Modul_13_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("H:\\Text1.txt");

            CountingWords(text);
        }
        static void CountingWords(string text)
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            char[] delimiters = new char[] { ' ', '\r', '\n', ',', '.', '-', '"', '!', '?', ':' };
            string[] AllWords = text.Split(delimiters);
            int minWordLength = 2;

            foreach (var word in AllWords)
            {
                string w = word.Trim().ToLower();
                if (w.Length >= minWordLength)
                {
                    if (!stats.ContainsKey(w))
                    {
                        stats.Add(w, 1);
                    }
                    else
                    {
                        stats[w] += 1;
                    }
                }
            }
            var orderedStats = stats.OrderByDescending(x => x.Value);

            Console.WriteLine("Всех слов :" + stats.Count);
            Console.WriteLine();
            foreach (var pair in orderedStats.Take(10))
            {
                Console.WriteLine("{0} - встречается в тексте: {1} раз", pair.Key, pair.Value);
            }
        }
    }
}