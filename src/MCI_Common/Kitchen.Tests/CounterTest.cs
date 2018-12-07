using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Model;

namespace Kitchen.Tests
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class CounterTest
    {
       
        [TestMethod]
        public void TestGetInstance()
        {
            Counter result = Counter.GetInstance();
            Counter excepted = Counter.GetInstance();
            Assert.AreSame(excepted, result);
        }
    }
}
