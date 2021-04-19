using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;

namespace ConsoleApp3
{

    public class JavaVisitor : JavaParserBaseVisitor<object>
    {
        //For Storing C Code
        public static List<String> C = new List<string>();

        //For Indents
        public int[] indentCount = new int[0];

        public void indents()
        {
            for (int i = 0; i < indentCount[0]; i++)
            {
                C.Add("\t");
            }
        }

        public override object VisitCompilationUnit([NotNull] JavaParser.CompilationUnitContext context)
        {
            return VisitChildren(context);
        }
        public override object VisitClassDeclaration([NotNull] JavaParser.ClassDeclarationContext context)
        {
            Console.Write(context.GetChild(0).GetText() + " ");
            Console.Write(context.GetChild(1).GetText() + "\n");
            return VisitChildren(context);

        }
        public override object VisitTypeDeclaration([NotNull] JavaParser.TypeDeclarationContext context)
        {
            return VisitChildren(context);
        }
        public override object VisitClassOrInterfaceModifier([NotNull] JavaParser.ClassOrInterfaceModifierContext context)
        {
            //C.Add(context.GetText());
            //Console.WriteLine(C);
            Console.Write(context.GetChild(0).GetText() + " ");
            return VisitChildren(context);
        }
        public override object VisitClassBody([NotNull] JavaParser.ClassBodyContext context)
        {
            Console.Write(context.GetChild(0).GetText() + "\n");
            return VisitChildren(context);
        }
        public override object VisitClassBodyDeclaration([NotNull] JavaParser.ClassBodyDeclarationContext context)
        {
            return VisitChildren(context);
        }
        public override object VisitModifier([NotNull] JavaParser.ModifierContext context)
        {

            return VisitChildren(context);
        }
        public override object VisitMemberDeclaration([NotNull] JavaParser.MemberDeclarationContext context)
        {

            return VisitChildren(context);
        }
        public override object VisitMethodDeclaration([NotNull] JavaParser.MethodDeclarationContext context)
        {
            Console.Write(context.GetChild(0).GetText() + " ");
            Console.Write(context.GetChild(1).GetText() + " ");
            Console.Write(context.GetChild(2).GetText() + "\n");
            return VisitChildren(context);
        }
        public override object VisitTypeTypeOrVoid([NotNull] JavaParser.TypeTypeOrVoidContext context)
        {
            //Console.Write(context.GetText() +" ");
            return VisitChildren(context);
        }
        public override object VisitFormalParameter([NotNull] JavaParser.FormalParameterContext context)
        {
            //Console.Write(context.GetText());
            return VisitChildren(context);
        }
        public override object VisitMethodBody([NotNull] JavaParser.MethodBodyContext context)
        {
            return VisitChildren(context);
        }
        public override object VisitBlock([NotNull] JavaParser.BlockContext context)
        {
            Console.Write(context.GetChild(0).GetText() + "\n");
            char[] delimeters = { ' ', '.', '(', ')' };
            string statement = context.GetChild(1).GetText();
            string[] tok = statement.Split(delimeters, StringSplitOptions.None);
            foreach (string token in tok)
            {
                string rules = token;
                switch (rules)
                {
                    case "System":
                        Console.Write("Console.");
                        break;
                    case "out":
                        break;
                    case "println":
                        Console.Write("WriteLine(");
                        break;
                    case ";":
                        Console.Write(rules + "\n");
                        break;
                    default:
                        if (rules.StartsWith("\""))
                        {
                            Console.Write(rules + " ");
                            break;
                        }
                        else if (rules.EndsWith("\""))
                        {
                            Console.Write(rules + ")");
                            break;
                        }
                        break;
                }
                //Console.Write(token + " ");
            }
            Console.Write(context.GetChild(2).GetText() + "\n");
            return VisitChildren(context);
        }
        public override object VisitBlockStatement([NotNull] JavaParser.BlockStatementContext context)
        {

            return VisitChildren(context);
        }
        public override object VisitStatement([NotNull] JavaParser.StatementContext context)
        {
            Console.Write(context.GetText());
            return VisitChildren(context);
        }
        public override object VisitExpression([NotNull] JavaParser.ExpressionContext context)
        {
            //Console.Write(context.GetChild(1).GetText());
            return VisitChildren(context);
        }
        public override object VisitExpressionList([NotNull] JavaParser.ExpressionListContext context)
        {
            //  Console.Write(context.GetText());
            return VisitChildren(context);
        }
        public override object VisitPrimary([NotNull] JavaParser.PrimaryContext context)
        {
            //  Console.Write(context.GetText());
            return VisitChildren(context);
        }
        public override object VisitMethodCall([NotNull] JavaParser.MethodCallContext context)
        {
            //Console.Write(context.GetChild(3).GetText());
            return VisitChildren(context);
        }
        public override object VisitVariableInitializer([NotNull] JavaParser.VariableInitializerContext context)
        {
            //Console.GetText();
            //string rules = token;
            //switch (rules)
            //{
            //    case "int":
            //        Console.Write("int");
            //        break;
            //    case "long":
            //        Console.Write("long");
            //        break;
            //    case "float":
            //        Console.Write("float");
            //        break;
            //    case "boolean":
            //        Console.Write("bool");
            //        break;
            //    case "double":
            //        Console.Write("double");
            //        break;
            //    case "String":
            //        Console.Write("string");
            //        break;
            //    case "char":
            //        Console.Write("char");
            //        break;
            //}
                

            return base.VisitVariableInitializer(context);
        }
        public override object VisitVariableDeclaratorId([NotNull] JavaParser.VariableDeclaratorIdContext context)
        {
            return base.VisitVariableDeclaratorId(context);
        }
        public override object VisitVariableDeclarator([NotNull] JavaParser.VariableDeclaratorContext context)
        {
            return base.VisitVariableDeclarator(context);
        }
        public override object VisitVariableDeclarators([NotNull] JavaParser.VariableDeclaratorsContext context)
        {
            return base.VisitVariableDeclarators(context);
        }
    }
}
