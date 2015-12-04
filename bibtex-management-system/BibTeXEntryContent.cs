using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class BibTeXEntryContent
    {
        Dictionary<string, Content> content;

        public BibTeXEntryContent()
        {
            content = new Dictionary<string, Content>();
        }

        public void addEntryContent(BibTeXRecordsCollection records)
        {
            foreach (BibTeXRecord record in records.getRecords())
                foreach (Parameter parameter in record.Parameters.Values)
                    if(!content.ContainsKey(parameter.Name))
                        content.Add(parameter.Name, new Content(parameter.Name));
        }

        public bool getEnabled(string contentValue)
        {
            Content parameter;
            content.TryGetValue(contentValue, out parameter);
            if (parameter != null)
                return parameter.Enabled;
            return false;
        }

        public void setEnabled(string contentValue, bool enabled)
        {
            Content parameter;
            content.TryGetValue(contentValue, out parameter);
            if (parameter != null)
                parameter.Enabled = enabled;
        }

        public string getStyle(string contentValue)
        {
            Content parameter;
            content.TryGetValue(contentValue, out parameter);
            if (parameter != null)
                return parameter.Style;

            return "";
        }

        public void setStyle(string contentValue, string styleName)
        {
            Content parameter;
            content.TryGetValue(contentValue, out parameter);
            if (parameter != null)
                parameter.Style = styleName;
        }
    }
}
