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
            var str1 = "3i-5.3";
            var str2 = "3i-5.8";

            var complex1 = new Complex(str1);
            var complex2 = new Complex(str2);

            var sum = complex1 + complex2;
            var del = complex1 / complex2;

            Assert.AreEqual("-10+6i", sum.Print());
            Assert.AreEqual("-8+0i", del.Print());
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

        
    }
}