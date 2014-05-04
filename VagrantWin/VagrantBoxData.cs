using System.Linq;

namespace VagrantWin
{
    public class VagrantBoxData
    {
        public bool Check { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Provider { get; set; }
        public bool GetVagrantBoxDataParseBentoFile(string line)
        {
            if (!line.Contains('[')) return false;
            if (!line.Contains(']')) return false;
            if (!line.Contains('(')) return false;
            if (!line.Contains(')')) return false;
            Name = line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1);
            Url = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1);
            if (line.Contains("virtualbox"))
            {
                Provider = "VirtualBox";
            }
            //                        else if (line.Contains("vmware"))
            //                        {
            //                            data.Provider = "VMWare";
            //                        }
            return true;
        }

        public bool GetVagrantBoxDataParseCommandLine(string line)
        {
            if (!line.Contains(' ')) return false;
            if (!line.Contains('(')) return false;
            if (!line.Contains(',')) return false;
            var preSpace = line.IndexOf(' ');
            var preBracket = line.IndexOf('(');
            var postBracket = line.IndexOf(',');
            var name = line.Substring(0, preSpace);
            var provider = line.Substring(preBracket + 1, postBracket - preBracket - 1);
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (string.IsNullOrWhiteSpace(provider)) return false;
            //現状はprovider名でチェック
            if (provider != "virtualbox") return false;

            Check = true;
            Name = name;
            Provider = provider;
            return true;
        }
    }
}
