using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagrantWin;

namespace VagrantWinTest
{
    [TestClass]
    public class VagrantFileTest
    {
        readonly List<VagrantData> _vagrantDatas = new List<VagrantData>();
        readonly List<VagrantBoxData> _vagrantBoxDatas = new List<VagrantBoxData>();

        [TestMethod]
        public void VagrantDataの追加処理()
        {
            var data = new VagrantData();
            data.Name = "default";
            _vagrantDatas.Add(data);

            Assert.IsTrue(_vagrantDatas[0].Name == data.Name);
        }
        [TestMethod]
        public void VagrantDBoxataの追加処理()
        {
            var data = new VagrantBoxData();
            data.Name = "default";
            _vagrantBoxDatas.Add(data);

            Assert.IsTrue(_vagrantBoxDatas[0].Name == data.Name);
        }

        [TestMethod]
        public void 適当な文字列を渡してパースに失敗()
        {
            var data = new VagrantData();
            Assert.IsTrue(data.GetVagrantDataParseCommandLine("a") == false);
        }
        [TestMethod]
        public void ちゃんとした文字列でもprovider名が違ったらパースに失敗()
        {
            var data = new VagrantData();
            Assert.IsTrue(data.GetVagrantDataParseCommandLine("a (b) ") == false);
        }
        [TestMethod]
        public void ちゃんとした文字列でprovider名がvirtualboxの時だけ成功()
        {
            var data = new VagrantData();
            Assert.IsTrue(data.GetVagrantDataParseCommandLine("HogeName Status (virtualbox) "));
        }
    }
}
