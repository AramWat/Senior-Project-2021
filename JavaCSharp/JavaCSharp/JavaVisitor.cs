using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;

namespace JavaCSharp
{
    class JavaVisitor : Java8ParserBaseVisitor<object>
    {
        String replace;
        int startIndex;
        int refIndex;
        String newBody;
        public override object VisitCompilationUnit([NotNull] Java8Parser.CompilationUnitContext context)
        {
            Console.WriteLine("using System;");
            return VisitChildren(context);
        }

        public override object VisitTypeDeclaration([NotNull] Java8Parser.TypeDeclarationContext context)
        {
            startIndex = context.GetText().IndexOf("{");
            replace = context.GetText().Substring(0, startIndex);
            replace = replace.Replace("public","public ").Replace("class", "class ");
            Console.WriteLine(replace + "\n" + "{");
            return base.VisitTypeDeclaration(context);
        }

        public override object VisitClassOrInterfaceType([NotNull] Java8Parser.ClassOrInterfaceTypeContext context)
        {
            //Nothing inside body
            return base.VisitClassOrInterfaceType(context);
        }

        public override object VisitClassDeclaration([NotNull] Java8Parser.ClassDeclarationContext context)
        {

            return base.VisitClassDeclaration(context);
        }

        public override object VisitClassBody([NotNull] Java8Parser.ClassBodyContext context)
        {
            String body = context.GetText();
            if (body.Contains("publicstaticvoidmain(String[]args){"))
            {
                startIndex = body.IndexOf("args){") + 6;
                replace = "public static void Main(String[]args)";
            }
            Console.WriteLine("\n" + replace + "\n" + "{");
            newBody = body.Substring(startIndex);
            return base.VisitClassBody(context);
        }

        public override object VisitMethodBody([NotNull] Java8Parser.MethodBodyContext context)
        {
            newBody = newBody.Replace("System.out.println", "Console.WriteLine").Replace("int", " int ").Replace(";",";\n").Replace("{", " {\n").Replace("}", " }\n")
                .Replace("{", " {\n").Replace("length","Length");
            //for(int i = 0; i < newBody.Length;i++)
            //{
            //    if (newBody.Contains("int"))
            //    {
            //        refIndex = newBody.IndexOf("int");
            //    }
            //}
            Console.WriteLine(newBody);
            return base.VisitMethodBody(context);
        }

        public override object VisitBlock([NotNull] Java8Parser.BlockContext context)
        {
            Console.WriteLine("Block here");
            return base.VisitBlock(context);
        }

        public override object VisitBlockStatement([NotNull] Java8Parser.BlockStatementContext context)
        {
            Console.WriteLine("block statement");
            return base.VisitBlockStatement(context);
        }

        public override object VisitStatement([NotNull] Java8Parser.StatementContext context)
        {
            Console.WriteLine("statement");
            return base.VisitStatement(context);
        }

        public override object VisitExpression([NotNull] Java8Parser.ExpressionContext context)
        {
            Console.WriteLine("expression here");
            return base.VisitExpression(context);
        }

        
    }

    
}
