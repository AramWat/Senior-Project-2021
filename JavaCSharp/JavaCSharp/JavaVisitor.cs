using System;
using System.IO;
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
        String newBody;
        String temp1;
        String temp2;
        int startIndex;
        int refIndex;
        String path = "MyText.cs";
        public override object VisitCompilationUnit([NotNull] Java8Parser.CompilationUnitContext context)
         {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("using System;" + "\n" + "using System.IO;");
            }
                Console.WriteLine("using System;");
            return VisitChildren(context);
        }


        public override object VisitTypeDeclaration([NotNull] Java8Parser.TypeDeclarationContext context)
        {
            startIndex = context.GetText().IndexOf("{");
            replace = context.GetText().Substring(0, startIndex);
            replace = replace.Replace("public","public ").Replace("class", "class ");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(replace + "\n" + "{");
            }
            //Console.WriteLine(replace + "\n" + "{");
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
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("\n" + replace + "\n" + "{");
            }
            //Console.WriteLine("\n" + replace + "\n" + "{");
            newBody = body.Substring(startIndex);
            return base.VisitClassBody(context);
        }

        public override object VisitMethodBody([NotNull] Java8Parser.MethodBodyContext context)
        {
            //if (newBody.Contains('"'))
            //{
            //    //gets start index of first " to locate string
            //    startIndex = newBody.IndexOf('"');
            //    //sets string variable equal to substring starting from first "
            //    subBodyMod = newBody.Substring(refIndex+1);
            //    //sets refIndex equal to second "
            //    refIndex = subBodyMod.IndexOf('"');
            //    //creates substring from provided index
            //    replace = subBodyMod.Substring(0,refIndex);
            //    Console.WriteLine("replace" + "\n" + replace);
            //}

            if (newBody.Contains("for"))
            {
                //gets start index and end index of for statement
                startIndex = newBody.IndexOf("for(");
                temp1 = newBody.Substring(startIndex);
                refIndex = temp1.IndexOf(")");
                //sets temp equal to for statement
                temp1 = newBody.Substring(startIndex, refIndex);
                if (temp1.Contains(':'))
                {
                    temp2 = temp1.Replace(":", " in ").Replace("for","foreach");
                    newBody = newBody.Replace(temp1, temp2);
                }

            }
            if (newBody.Contains("String"))
            {
                newBody = newBody.Replace("String","string ");
            }
            newBody = newBody.Replace("System.out.println", "Console.WriteLine").Replace("int", " int ").Replace(";", ";\n").Replace("{", " {\n").Replace("}", " }\n")
                .Replace("{", " {\n").Replace("length", "Length").Replace("double", " double ").Replace("boolean", " bool ").Replace("String", "string ").Replace("float", " float ")
                .Replace("long", " long ").Replace("new", " new ").Replace("private", " private ").Replace("static", " static ").Replace("class", "class ").Replace("indexOf", "IndexOf")
                .Replace("substring", "Substring").Replace("toString", "ToString").Replace("equals", "Equals").Replace("concat", "Concat").Replace("contains", "Contains");



            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newBody);
                
            }
            //Console.WriteLine(newBody);
            return base.VisitMethodBody(context);
        }

        public override object VisitBlock([NotNull] Java8Parser.BlockContext context)
        {
          
            return base.VisitBlock(context);
        }

        public override object VisitBlockStatement([NotNull] Java8Parser.BlockStatementContext context)
        {
          
            return base.VisitBlockStatement(context);
        }

        public override object VisitStatement([NotNull] Java8Parser.StatementContext context)
        {
           
            return base.VisitStatement(context);
        }

        public override object VisitExpression([NotNull] Java8Parser.ExpressionContext context)
        {
            
            return base.VisitExpression(context);
        }

        
    }

    
}
