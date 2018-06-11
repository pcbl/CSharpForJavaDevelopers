using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.officeDay.codeDom
{
    [TestClass()]
    public class CSharpScriptEngineTests
    {
        [TestMethod()]
        public void EvalIntTest()
        {
            int expected = 5;
            var result = CSharpScriptEngine.Eval<int>("return 2 + 3;",null);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EvalIntParamsTest()
        {
            int expected = 9;
            object[] input = new object[] {5, 4};
            var result = CSharpScriptEngine.Eval<int>("return (int)parameters[0] + (int)parameters[1];", input);
            Assert.AreEqual(expected, result);
        }
    }
}