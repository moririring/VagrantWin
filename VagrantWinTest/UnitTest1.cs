using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagrantWin;

namespace VagrantWinTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly List<VagrantData> _vagrantDatas = new List<VagrantData>();

        [TestMethod]
        public void TestMethod1()
        {
            var data = new VagrantData();
            data.Name = "default";
            _vagrantDatas.Add(data);

            Assert.IsTrue(_vagrantDatas.Count == 1);
        }

        [TestMethod]
        public void 適当な文字列を渡してパースに失敗()
        {
            Assert.IsTrue(VagrantData.GetVagrantDataParseLine("a") == null);
        }
        [TestMethod]
        public void ちゃんとした文字列を渡してパースに成功()
        {
            Assert.IsTrue(VagrantData.GetVagrantDataParseLine("a (b) ") != null);
        }
    }
}
