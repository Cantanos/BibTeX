using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class Content
    {
        string parameter;
        bool enabled;
        string style;

        public string Parameter { set { parameter = value; } get { return parameter; } }
        public bool Enabled { set { enabled = value; } get { return enabled; } }
        public string Style { set { style = value; } get { return style; } }

        public Content(string pParameter)
        {
            parameter = pParameter;
            enabled = true;
            style = "NONE";
        }
    }
}
