using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;

namespace JavaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "HelloWorldExample{ public static void main(String args[]){ System.out.println(\"Hello World !\");}}" ;
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ICharStream stream = inputStream;
            JavaLexer lexer = new JavaLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            JavaParser parser = new JavaParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.compilationUnit();
            Console.Write(tree);
            Console.ReadLine();
        }
    }
}
