using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Parser
{
    class scan
    {
        public static void Main(string[] args)
        {
            string file = "W:/Spring2021/Senior proj/Parser/Parser/ScannerTest.txt";

            SimpleRegexTokenizer tokenizer = new SimpleRegexTokenizer();
            String lines = File.ReadAllText(file);
            tokenizer.Tokenize(lines);
            Console.ReadLine();
        }
    }
}
