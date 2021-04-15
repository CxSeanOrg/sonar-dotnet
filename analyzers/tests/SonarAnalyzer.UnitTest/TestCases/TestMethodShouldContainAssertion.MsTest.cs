﻿namespace TestMsTest
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    public class Program
    {
        [TestMethod]
        public void TestMethod1() // Noncompliant {{Add at least one assertion to this test case.}}
//                  ^^^^^^^^^^^
        {
            var x = 42;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var x = 42;
            Assert.AreEqual(x, 42);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var x = 42;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(x, 42);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod4()
        {
            var x = System.IO.File.Open("", System.IO.FileMode.Open);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var x = 42;
            x.Should().Be(42);
        }

        [TestMethod]
        public void TestMethod8()
        {
            AssertSomething();
        }

        [TestMethod]
        public void TestMethod9()
        {
            ShouldSomething();
        }

        [TestMethod]
        public void TestMethod10()
        {
            ExpectSomething();
        }

        [TestMethod]
        public void TestMethod11()
        {
            MustSomething();
        }

        [TestMethod]
        public void TestMethod12()
        {
            VerifySomething();
        }

        [TestMethod]
        public void TestMethod13()
        {
            ValidateSomething();
        }

        [TestMethod]
        public void TestMethod14()
        {
            dynamic d = 10;
            Assert.AreEqual(d, 10.0);
        }

        [TestMethod]
        public void TestMethod15()
        {
            var x = 42;
            AreEqual(x, 42);
        }

        [TestMethod]
        public void TestMethod16()
        {
            var x = 42;
            if (x == 42)
            {
                throw new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException("You failed me!");
            }
        }

        [TestMethod]
        public void TestMethod17()
        {
            var x = 42;
            var exception = new Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException("You failed me!");
            if (x == 42)
            {
                throw exception;
            }
        }

        [TestMethod]
        public void TestMethod18() // Noncompliant
        {
            var x = 42;
            if (x == 42)
            {
                throw new Exception("You failed me!");
            }
        }

        [TestMethod]
        [Ignore]
        public void TestMethod19() // Don't raise on skipped test methods
        {
        }

        [TestMethod]
        public void TestMethod20() // Noncompliant
        {
            var x = 42;
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void ArrowMethod1() => DoNothing(); // Noncompliant
//                  ^^^^^^^^^^^^

        [TestMethod]
        public void ArrowMethod2() => AssertSomething();

        public void DoNothing() { }

        public void AssertSomething()
        {
            Assert.IsTrue(true);
        }

        public void ShouldSomething()
        {
            Assert.IsTrue(true);
        }

        public void ExpectSomething()
        {
            Assert.IsTrue(true);
        }

        public void MustSomething()
        {
            Assert.IsTrue(true);
        }

        public void VerifySomething()
        {
            Assert.IsTrue(true);
        }

        public void ValidateSomething()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class Program_DataTestMethod
    {
        [DataTestMethod]
        public void TestMethod1() // Noncompliant {{Add at least one assertion to this test case.}}
//                  ^^^^^^^^^^^
        {
            var x = 42;
        }

        [DataTestMethod]
        public void TestMethod2()
        {
            var x = 42;
            Assert.AreEqual(x, 42);
        }

        [DataTestMethod]
        public void TestMethod3()
        {
            var x = 42;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(x, 42);
        }

        [DataTestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod4()
        {
            var x = System.IO.File.Open("", System.IO.FileMode.Open);
        }

        [DataTestMethod]
        public void TestMethod5()
        {
            var x = 42;
            x.Should().Be(42);
        }

        [DataTestMethod]
        public void TestMethod8()
        {
            AssertSomething();
        }

        [DataTestMethod]
        public void TestMethod9()
        {
            ShouldSomething();
        }

        [DataTestMethod]
        public void TestMethod10()
        {
            ExpectSomething();
        }

        [DataTestMethod]
        public void TestMethod11()
        {
            MustSomething();
        }

        [DataTestMethod]
        public void TestMethod12()
        {
            VerifySomething();
        }

        [DataTestMethod]
        public void TestMethod13()
        {
            ValidateSomething();
        }

        [DataTestMethod]
        public void TestMethod14()
        {
            dynamic d = 10;
            Assert.AreEqual(d, 10.0);
        }

        [DataTestMethod]
        [Ignore]
        public void TestMethod15() // Don't raise on skipped test methods
        {
        }

        public void AssertSomething()
        {
            Assert.IsTrue(true);
        }

        public void ShouldSomething()
        {
            Assert.IsTrue(true);
        }

        public void ExpectSomething()
        {
            Assert.IsTrue(true);
        }

        public void MustSomething()
        {
            Assert.IsTrue(true);
        }

        public void VerifySomething()
        {
            Assert.IsTrue(true);
        }

        public void ValidateSomething()
        {
            Assert.IsTrue(true);
        }
    }

    public class Class1
    {
        public int Add(int a, int b) => a + b;
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() // Noncompliant
        {
            var result = new Class1().Add(1, 2);
        }
    }

    /// <summary>
    /// The NSubstitute assertions are extensively verified in the NUnit test files.
    /// Here we just do a simple test to confirm that the errors are not raised in conjunction with MsTest.
    /// </summary>
    [TestClass]
    public class NSubstituteTests
    {
        [TestMethod]
        public void Received() => Substitute.For<IDisposable>().Received().Dispose();
    }
}
