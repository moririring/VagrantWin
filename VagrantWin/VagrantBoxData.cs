using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VagrantWin
{
    public class VagrantBoxData
    {
        public bool Check { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Provider { get; set; }

        static public VagrantBoxData GetVagrantBoxDataParseLine(string line)
        {
            if (!line.Contains(' ')) return null;
            if (!line.Contains('(')) return null;
            if (!line.Contains(',')) return null;
            //こんなparseで大丈夫か？
            var preSpace = line.IndexOf(' ');
            var preBracket = line.IndexOf('(');
            var postBracket = line.IndexOf(',');
            var name = line.Substring(0, preSpace);
            var provider = line.Substring(preBracket + 1, postBracket - preBracket - 1);

            if (string.IsNullOrWhiteSpace(name)) return null;
            if (string.IsNullOrWhiteSpace(provider)) return null;
            //パース条件が甘いので、これだけだと色んなものがある
            //現状はprovider名でチェック
            if (provider != "virtualbox") return null;

            var vagrantData = new VagrantBoxData
            {
                Check = true,
                Name = name,
                Provider = provider
            };
            return vagrantData;
        }
    }
}
