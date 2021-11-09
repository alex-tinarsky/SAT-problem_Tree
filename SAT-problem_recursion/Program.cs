using System;
using System.Collections.Generic;
using System.Text;


namespace SAT_problem_recursion
{
    enum BoolOperations { And, Or, Not };
    public abstract class ExprBoolean
    {
        public static ExprBoolean operator &(ExprBoolean left, ExprBoolean right)
            => new BoolOp(BoolOperations.And, left, right);

        public static ExprBoolean operator |(ExprBoolean left, ExprBoolean right)
            => new BoolOp(BoolOperations.Or, left, right);

        public static ExprBoolean operator !(ExprBoolean expr)
            => new BoolOp(BoolOperations.Not, expr, null);
    }
    class BoolVariable : ExprBoolean
    {
        /*public bool Value { get; set; }*/
        public HashSet<bool> PossibleValues { get; set; }
        public BoolVariable()
        {
            this.PossibleValues = new HashSet<bool>(new bool[] { true, false });
        }
        /*public BoolVariable(bool val)
        {
            this.Value = val;
            this.PossibleValues = new HashSet<bool>(new bool[] { true, false });
        }*/
    }

    class BoolOp : ExprBoolean
    {
        public BoolOperations Op { get; }
        public ExprBoolean Left { get; }
        public ExprBoolean Right { get; }
        public BoolOp(BoolOperations op, ExprBoolean left, ExprBoolean right)
        {
            this.Op = op;
            this.Left = left;
            this.Right = right;
        }
    }

    public class Program
    {
        /*static void ExpressionToString(ExprBoolean exprTree, StringBuilder ExpressionString)
        {
            if (exprTree is BoolVariable)
            {
                ExpressionString.Append((exprTree as BoolVariable).Value);
                return;
            }
            var opTree = exprTree as BoolOp;
            switch (opTree.Op)
            {
                case BoolOperations.Not:
                    ExpressionString.Append("!");
                    ExpressionString.Append('(');
                    ExpressionToString(opTree.Left, ExpressionString);
                    ExpressionString.Append(')');
                    break;
                case BoolOperations.Or:
                    ExpressionToString(opTree.Left, ExpressionString);
                    ExpressionString.Append(" | ");
                    ExpressionToString(opTree.Right, ExpressionString);
                    break;
                case BoolOperations.And:
                    ParenthesesForOr(opTree.Left, ExpressionString);
                    ExpressionString.Append(" & ");
                    ParenthesesForOr(opTree.Right, ExpressionString);
                    break;
            }
        }

        static bool Evaluate(ExprBoolean exprTree)
        {
            if (exprTree is BoolOp)
            {
                var opTree = exprTree as BoolOp;
                switch (opTree.Op)
                {
                    case BoolOperations.Not:
                        return !(Evaluate(opTree.Left));
                    case BoolOperations.Or:
                        return (Evaluate(opTree.Left) | Evaluate(opTree.Right));
                    case BoolOperations.And:
                        return (Evaluate(opTree.Left) | Evaluate(opTree.Right));
                }
            }
            return (exprTree as BoolVariable).Value;
        }*/

        public static bool IsThereSolution(ExprBoolean exprTree, bool expectedValue)
        {
            if (exprTree is BoolOp)
            {
                var opTree = exprTree as BoolOp;
                switch (opTree.Op)
                {
                    case BoolOperations.Not:
                        return IsThereSolution(opTree.Left, !expectedValue);
                    case BoolOperations.Or:
                        return expectedValue ? 
                            (IsThereSolution(opTree.Left, expectedValue) |
                            IsThereSolution(opTree.Right, expectedValue)) : 
                            (IsThereSolution(opTree.Left, expectedValue) &
                            IsThereSolution(opTree.Right, expectedValue));
                    case BoolOperations.And:
                        return expectedValue ?
                            (IsThereSolution(opTree.Left, expectedValue) &
                            IsThereSolution(opTree.Right, expectedValue)) :
                            (IsThereSolution(opTree.Left, expectedValue) |
                            IsThereSolution(opTree.Right, expectedValue));
                }
            }
            var boolVar = exprTree as BoolVariable;
            boolVar.PossibleValues.IntersectWith(new bool[] { expectedValue });
            return boolVar.PossibleValues.Count > 0;
        }

        /*static void ParenthesesForOr(ExprBoolean expr, StringBuilder ExpressionString)
        {
            if ((expr is BoolOp) && ((expr as BoolOp).Op == BoolOperations.Or))
            {
                ExpressionString.Append('(');
                ExpressionToString(expr, ExpressionString);
                ExpressionString.Append(')');
            }
            else
            {
                ExpressionToString(expr, ExpressionString);
            }
        }*/

        static void Main(string[] args)
        {

            BoolVariable X1 = new(), X2 = new(), X3 = new();
            var Exp = X1 & (X2 | X3 | !X1);
            

            Console.WriteLine(IsThereSolution(Exp, true));
            Console.WriteLine("X1");
            foreach (bool elem in X1.PossibleValues)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("X2");
            foreach (bool elem in X2.PossibleValues)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("X3");
            foreach (bool elem in X3.PossibleValues)
            {
                Console.WriteLine(elem);
            }
            /*StringBuilder ExpressionString = new StringBuilder();
            ExpressionToString(Exp, ExpressionString);
            Console.WriteLine(ExpressionString.ToString());

            Console.WriteLine(Evaluate(Exp));*/
        }
    }
}
