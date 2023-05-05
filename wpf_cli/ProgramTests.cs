using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void adoTest()
        {
            char adosav = 'A';
            int terulet = 100;
            Assert.AreEqual(80000,Program.ado(adosav,terulet));
        }
        [TestMethod()]
        public void adoTest2()
        {
            char adosav = 'B';
            int terulet = 100;
            Assert.AreEqual(60000, Program.ado(adosav, terulet));
        }
        [TestMethod()]
        public void adoTest3()
        {
            char adosav = 'C';
            int terulet = 100;
            Assert.AreEqual(10000, Program.ado(adosav, terulet));
        }
        [TestMethod()]
        public void adoTest4()
        {
            char adosav = 'A';
            int terulet = 0;
            Assert.AreEqual(0, Program.ado(adosav, terulet));
        }
    }
}