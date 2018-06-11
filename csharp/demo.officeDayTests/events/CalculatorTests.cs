using System;
using System.Reflection;
using demo.officeDay.events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.officeDayTests.events
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            int currentValue = 0;
            int expectedValue = 3;
       
            Calculator calculator = new Calculator();
            //Remember that currentValue is on AddTest() scope! On Java that can be a bit challenging...
            //Open Dotpeek!
            EventHandler<CalculatorEventArgs> myHandler = (sender, args) => currentValue = args.Result;
            calculator.Processed += myHandler;
            calculator.Add(1);
            calculator.Add(2);

            //We remove the handler in order to ensure event unsubscription is working!
            calculator.Processed -= myHandler;
            calculator.Add(5);

            Assert.AreEqual(expectedValue, currentValue);
        }

    }
}