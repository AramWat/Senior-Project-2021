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
            StreamReader sr = new StreamReader("W:/Spring2021/Senior proj/JavaCXGamesMode/JavaCSharp/JavaCSharp/Test.txt");
            string input = sr.ReadToEnd();
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ICharStream stream = inputStream;
            JavaLexer lexer = new JavaLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            JavaParser parser = new JavaParser(tokens);
            IParseTree tree = parser.compilationUnit();
            //TokenStreamRewriter rewriter = new TokenStreamRewriter(tokens);
            //Console.WriteLine(parser.ToString());
            

            //Console.WriteLine(tree.ToStringTree(parser));
            JavaVisitor visitor = new JavaVisitor();
            visitor.Visit(tree);

            Console.ReadLine();

        }

    }
}
