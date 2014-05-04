using System.Linq;

namespace VagrantWin
{
    public class VagrantData
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Provider { get; set; }

        public bool GetVagrantDataParseCommandLine(string line)
        {
            if (!line.Contains(' ')) return false;
            if (!line.Contains('(')) return false;
            if (!line.Contains(')')) return false;
            var preSpace = line.IndexOf(' ');
            var postSpace = line.LastIndexOf(' ');
            var preBracket = line.IndexOf('(');
            var postBracket = line.IndexOf(')');
            var name = line.Substring(0, preSpace);
            var status = line.Substring(preSpace, postSpace - preSpace).Trim();
            var provider = line.Substring(preBracket + 1, postBracket - preBracket - 1);
            if (string.IsNullOrWhiteSpace(name)) return false;
            if (string.IsNullOrWhiteSpace(status)) return false;
            if (string.IsNullOrWhiteSpace(provider)) return false;
            //現状はprovider名でチェック
            if (provider != "virtualbox") return false;

            Name = name;
            Status = status;
            Provider = provider;
            return true;
        }

    }
}
