using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagrantWin;

namespace VagrantWinTest
{
    [TestClass]
    public class UnitTest1
    {
        List<VagrantData> _vagrantDatas = new List<VagrantData>();

        [TestMethod]
        public void TestMethod1()
        {
            var data = new VagrantData();
            data.name = "default";
            _vagrantDatas.Add(data);

            Assert.IsTrue(_vagrantDatas.Count == 1);
        }
    }
}
