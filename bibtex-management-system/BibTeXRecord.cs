using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class BibTeXRecord
    {
        string id;
        string type;
        List<string> nameOfParameters;
        List<string> valueOfParameters;
        List<string> valueOfParameterOrg; 
        List<bool> enabled; 
        List<string> styleName; 

        public string Type { set { type = value; } get { return type; } }
        public string ID { set { id = value; } get { return id; } }
        public List<string> NameOfParameters { set { nameOfParameters = value; } get { return nameOfParameters; } }
        public List<string> ValueOfParameters { set { valueOfParameters = value; } get { return valueOfParameters; } }
        public List<string> ValueOfParametersOrg { get { return valueOfParameterOrg; } }
        public List<bool> Enabled { set { enabled = value; } get { return enabled; } }

        public BibTeXRecord()
        {
            nameOfParameters = new List<string>();
            valueOfParameters = new List<string>();
            valueOfParameterOrg = new List<string>();
            enabled = new List<bool>(); 
            styleName = new List<string>();
        }

        public BibTeXRecord(List<string> nameOfParameters, List<string> valueOfParameters)
        {
            this.nameOfParameters = new List<string>(nameOfParameters);
            this.valueOfParameters = new List<string>(valueOfParameters);
            this.valueOfParameterOrg = new List<string>(valueOfParameters);
            this.enabled = new List<bool>();
            this.styleName = new List<string>(); 
        }

        public void addNameOfParameters(string name)
        {
            this.nameOfParameters.Add(name);
        }

        public void addValueOfParameters(string value)
        {
            this.valueOfParameters.Add(value);
        }

        public string toString()
        {
            string result = "@";
            result += this.type;
            result = result + "{" + this.id + ",\n";
            for (int i = 0; i < this.nameOfParameters.Count; ++i)
            {
                if (this.Enabled[i] && i < this.nameOfParameters.Count - 1)
                {
                    result = result + "\t" + nameOfParameters[i] + " = " + "{" + valueOfParameters[i] + "}," + "\n";
                }
                else
                    result = result + "\t" + nameOfParameters[i] + " = " + "{" + valueOfParameters[i] + "}" + "\n";
            }
            result += "}\n";
            return result;
        }

        public bool isStyleApplied() 
        {
            return true;
        }
    }
}
