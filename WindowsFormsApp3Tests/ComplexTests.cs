using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Tests
{
    [TestClass()]
    public class ComplexTests
    {
        [TestMethod()]
        public void RealInComplexTest1()
        {
            var str = "3i-5";
            var complex = new Complex(str);
            var real = complex.RealInComplex(str);
            var suppose = complex.SupposeInComplex(str);
            Assert.AreEqual(-5, real);
            Assert.AreEqual(3, suppose);
        }

        [TestMethod()]
        public void RealInComplexTest2()
        {
            var str1 = "3i-5,3";
            var str2 = "3i-5,8";

            var complex1 = new Complex(str1);
            var complex2 = new Complex(str2);

            var sum = complex1 + complex2;
            var del = complex1 / complex2;

            Assert.AreEqual("-11,1000003814697+6i", sum.Print());
            Assert.AreEqual("0,931988744256781-0,0351782345724038i", del.Print());
        }

        [TestMethod()]
        public void RealInComplexTest3()
        {
            var str1 = "3-5iф";
            var str2 = "3i-5";

            var complex1 = new Complex(str1);
            var complex2 = new Complex(str2);

            var error = complex1.CheckSuppose();

            Assert.AreEqual(true, error);
        }

        [TestMethod()]
        public void RealInComplexTest33()
        {
            var с1 = new Complex("3-5i");
            var с2 = new Complex("3-5i");
            Assert.AreEqual(с1, с2);
        }

        [TestMethod()]
        public void RealInComplexTest32()
        {
            var str1 = "3-5i";
            Assert.AreEqual(str1, new Complex(str1).Print());
        }
    }
}