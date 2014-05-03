using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagrantWin;

namespace VagrantWinTest
{
    [TestClass]
    public class コマンド文字列変換テスト
    {
        [TestMethod]
        public void 文字列からEnumへの変換()
        {
            Assert.AreEqual(VagrantCommand.Status, VagrantWrapper.ToCommand("status"));
            Assert.AreEqual(VagrantCommand.Up, VagrantWrapper.ToCommand("up"));
            Assert.AreEqual(VagrantCommand.Halt, VagrantWrapper.ToCommand("halt"));
            Assert.AreEqual(VagrantCommand.Provision, VagrantWrapper.ToCommand("provision"));
            Assert.AreEqual(VagrantCommand.Destroy, VagrantWrapper.ToCommand("destroy"));
        }

        [TestMethod]
        public void Enumから文字列への変換()
        {
            Assert.AreEqual("status", VagrantWrapper.ToCommandString(VagrantCommand.Status));
            Assert.AreEqual("destroy -f", VagrantWrapper.ToCommandString(VagrantCommand.Destroy));
        }
    }
}
