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
        Dictionary<string, Parameter>  parameters;

        public string Type { set { type = value; } get { return type; } }
        public string ID { set { id = value; } get { return id; } }
        public Dictionary<string, Parameter> Parameters { set { parameters = value; } get { return parameters; } }
        

        public BibTeXRecord()
        {
            parameters = new Dictionary<string, Parameter>();
        }

        public BibTeXRecord(List<Parameter> pParameters)
        {
            parameters = new Dictionary<string, Parameter>();
            pParameters.ForEach(AddParameter); 
        }

        private void AddParameter(Parameter pParameter)
        {
            if(!parameters.ContainsKey(pParameter.Name))
                parameters.Add(pParameter.Name, pParameter);
        }

        public string toString()
        {
            StringBuilder builder = new StringBuilder("@");
            builder.Append(type).Append("{").Append(id).Append(",\n");
            builder.Append(String.Join(",\n", parameters.Values));
            builder.Append("}\n");
            return builder.ToString();
        }

        public bool isStyleApplied() 
        {
            return true;
        }
    }
}
