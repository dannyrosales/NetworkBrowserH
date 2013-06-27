using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NMock2;
using NetworkBrowserLib;

namespace NetworkBrowserLib.TESTS
{
    
    [TestFixture]
    public class Computers_TEST
    {

        private Computer _computer;

        [SetUp]
        public void ComputerSetup()
        {
            _computer = new Computer();
        }

        [Test] 
        public void Computer_GetName_ReturnHostName()
        {
            //ARRANGE
            string expectedResult;
            string actualResult;
            //ACT
            expectedResult = "DANIEL-PC";
            actualResult = _computer.Name;
            //ASSERT

            Assert.IsTrue(actualResult == expectedResult);
        }


        [Test]
        public void Computer_GetDomainName_ReturnUserDomain()
        {
            //ARRANGE
            string expectedResult;
            string actualResult;
            //ACT
            expectedResult = "OUR_HOME";
            actualResult = _computer.DomainName;
            //ASSERT

            Assert.IsTrue(actualResult == expectedResult);
        }

        [Test]
        public void IsCenter()
        {
            bool expResult = true;
            _computer.IsCenter = true;

            bool actualResult = _computer.IsCenter;

            Assert.IsTrue(expResult == actualResult);
        }


    }
}
