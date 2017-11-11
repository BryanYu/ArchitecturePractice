using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bryan.BMI.Practice.UnitTest
{
    [TestClass]
    public class BOTest1
    {
        [TestMethod]
        public void Test_BMI_GetBMI()
        {
            var target = new BMI.Practice.BO.BMI()
            {
                Height = 170,
                Weight = 70
            };
            var expected = 24.22;

            var actual = target.Result;

            Assert.AreEqual(expected, actual.ToString("0.00"));
            
        }
    }
}
