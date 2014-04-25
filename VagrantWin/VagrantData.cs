using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VagrantWin
{
    public class VagrantData
    {
        public bool Check { get; set; } 
        public string Name { get; set; }
        public string Status { get; set; }
        public string Provider { get; set; }

        static public VagrantData GetVagrantDataParseLine(string line)
        {
            if (!line.Contains(' ')) return null;
            if (!line.Contains('(')) return null;
            if (!line.Contains(')')) return null;
            //こんなparseで大丈夫か？
            var preSpace = line.IndexOf(' ');
            var postSpace = line.LastIndexOf(' ');
            var preBracket = line.IndexOf('(');
            var postBracket = line.IndexOf(')');
            var name = line.Substring(0, preSpace);
            var status = line.Substring(preSpace, postSpace - preSpace).Trim();
            var provider = line.Substring(preBracket + 1, postBracket - preBracket - 1);

            if (string.IsNullOrWhiteSpace(name)) return null;
            if (string.IsNullOrWhiteSpace(status)) return null;
            if (string.IsNullOrWhiteSpace(provider)) return null;

            var vagrantData = new VagrantData
            {
                Check = true,
                Name = name,
                Status = status,
                Provider = provider
            };
            return vagrantData;
        }

    }
}
