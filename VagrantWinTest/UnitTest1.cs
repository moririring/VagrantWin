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
        public void VagrantDataの追加処理()
        {
            var data = new VagrantData();
            data.Name = "default";
            _vagrantDatas.Add(data);

            Assert.IsTrue(_vagrantDatas[0].Name == data.Name);
        }

        [TestMethod]
        public void 適当な文字列を渡してパースに失敗()
        {
            Assert.IsTrue(VagrantData.GetVagrantDataParseLine("a") == null);
        }
        [TestMethod]
        public void ちゃんとした文字列でもprovider名が違ったらパースに失敗()
        {
            //virtualbox
            Assert.IsTrue(VagrantData.GetVagrantDataParseLine("a (b) ") == null);
        }
        [TestMethod]
        public void ちゃんとした文字列でprovider名がvirtualboxの時だけ成功()
        {
            //virtualbox
            Assert.IsTrue(VagrantData.GetVagrantDataParseLine("HogeName Status (virtualbox) ") != null);
        }
    }
}
