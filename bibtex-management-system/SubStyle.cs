using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class SubStyle
    {
        List<string> input;
        string output;

        public List<string> Input { get { return input; } }
        public string Output { get { return output; } }

        public SubStyle(string input, string output)
        {
            this.input = new List<string>();
            this.input.Add(input);
            this.output = output;
        }

        public SubStyle(List<string> input, string output)
        {
            this.input = new List<string>(input);
            this.output = output;
        }
    }
}
