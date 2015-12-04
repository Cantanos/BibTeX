using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class Parameter
    {
        string name;
        string value;
        string originalValue;
        bool enabled;
        string styleName;
        bool styleChanged; // indicates whether its style has been changes by the latest action

        public bool Enabled { set { enabled = value; } get { return enabled; } }
        public string Name { set { name = value; } get { return name; } }
        public string Value { set { this.value = value; } get { return value; } }
        public string OriginalValue { set { originalValue = value; } get { return originalValue; } }
        public string StyleName { set { styleName = value; styleChanged = true; } get { return styleName; } }
        public bool StyleChanged { set { styleChanged = value; } get { return styleChanged; } }

        public Parameter(string pName, string pValue)
        {
            name = pName;
            value = pValue;
            originalValue = pValue;
            enabled = true;
            styleChanged = false;
        }

        public override string ToString()
        {
            return name + " = " + "{" + value + "}";
        }
    }
}
