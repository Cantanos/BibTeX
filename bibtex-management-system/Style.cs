using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class Style
    {
        string name;
        List<SubStyle> subStyle;

        public string Name { get { return name; } }
        public List<SubStyle> SubStyle { get { return subStyle; } }

        public Style(string name)
        {
            this.name = name;
            subStyle = new List<SubStyle>();
        }

        public Style(string name, string input, string output)
        {
            this.name = name;
            subStyle = new List<SubStyle>();
            subStyle.Add(new SubStyle(input, output));
        }

        public void addSubStyle(string input, string output)
        {
            subStyle.Add(new SubStyle(input, output));
        }

        public void addSubStyle(List<string> input, string output)
        {
            subStyle.Add(new SubStyle(input, output));
        }
    }
}
