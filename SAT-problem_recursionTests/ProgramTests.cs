using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAT_problem_recursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT_problem_recursion.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void IsThereSolutionTest1()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new();
            var Exp = !X1 & (X1 | X2) & X2 & X3 & X4 & X5;
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest2()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new();
            var Exp = !X1 & (X1 | X2 & X1) & X2 & X3 & X4 & X5;
            Assert.IsFalse(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest3()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new();
            var Exp = (X1 & X2 | X1) & (X3 | !(X2 & X3 & !X1));
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest4()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new();
            var Exp = (X1 & X2 | X1) & (X3 & (X2 & X3 & !X1)) | X4 & !X4 & X5;
            Assert.IsFalse(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest5()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new();
            var Exp = !(X1 | X2 | X3 | (X1 & X2) | !X3);
            Assert.IsFalse(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest6()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new(),
                X6 = new(), X7 = new(), X8 = new(), X9 = new(), X10 = new();
            var Exp = !X1 & !(X2 & X3) & (X4 | X5) | !(X6 & X7 | X8) & (X9 | X10);
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest7()
        {
            BoolVariable X1 = new();
            var Exp = !(!X1) & X1;
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest8()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new();
            var Exp = (X1 | X2 & !(X1 & X2)) & !(X3 & X1) | X1;
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest9()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new(), X6 = new(), X7 = new(), X8 = new(), X9 = new(), X10 = new(), X11 = new(), X12 = new(), X13 = new(), X14 = new(), X15 = new();
            var Exp = X1 & X2 & X3 & X4 & X5 & X6 & X7 & X8 &
                X9 & X10 & X11 & X12 & X13 & X14 & X15;
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
        [TestMethod()]
        public void IsThereSolutionTest10()
        {
            BoolVariable X1 = new(), X2 = new(), X3 = new(), X4 = new(), X5 = new();
            var Exp = !(X2 & X1) | (X3 | !(X4 & X1)) & (X1 | !X5) & X5 | !(X4 & X3);
            Assert.IsTrue(Program.IsThereSolution(Exp, true));
        }
    }
}