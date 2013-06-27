using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkBrowserLib;
using NUnit.Framework;

namespace NetworkBrowserLib.TESTS
{
    [TestFixture]
   public class Network_TEST
    {

        public Network_TEST()
        {

        }

        Network _network = null;

        [SetUp]
        public void SetUpNetwork()
        {
            _network = new Network();
        }

        [Test]
        public void Network_ComputerCount_ReturnOne()
        {
            //ARRANGE
            int expectedResult = 1;
            int actualResult;
            //ACT
            actualResult = _network.ComputerCount;
            //ASSERT
            Assert.IsTrue(actualResult == expectedResult);
            
        }
        [Test]
        public void Network_RetrieveComputerNames()
        {
            //arrange
            List<String> expListOfComputers = new List<string> { "DANIEL-PC"};
            List<String> actualListOfComputers;
            //act

            actualListOfComputers = _network.ListOfComputerNames;
            //assert
            Assert.IsTrue(actualListOfComputers[0] == expListOfComputers[0]);
            
        }
    }
}
