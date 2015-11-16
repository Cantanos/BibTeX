using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class BibTeXEntryContent
    {
        List<string> content;
        List<bool> enabled;
        List<string> styles;

        public BibTeXEntryContent()
        {
            this.content = new List<string>();
            this.enabled = new List<bool>();
            styles = new List<string>();
        }

        public void addEntryContent(BibTeXRecordsCollection records)
        {
            for (int i = 0; i < records.getRecords().Count; i++)
            {
                for (int j = 0; j < records.getRecords()[i].NameOfParameters.Count; j++)
                {
                    bool repeat = false;

                    for (int z = 0; z < content.Count; z++)
                    {
                        if (content[z] == records.getRecords()[i].NameOfParameters[j])
                        {
                            repeat = true;
                            break;
                        }
                    }
                    if (!repeat)
                        content.Add(records.getRecords()[i].NameOfParameters[j]);
                }

            }

            for (int i = 0; i < content.Count; i++)
            {
                enabled.Add(true);
                styles.Add("NONE");
            }
        }

        public bool getEnabled(string contentValue)
        {
            for (int i = 0; i < content.Count; i++)
                if (content[i] == contentValue)
                    return enabled[i];

            return false;
        }

        public void setEnabled(string contentValue, bool enabled)
        {
            for (int i = 0; i < content.Count; i++)
                if (content[i] == contentValue)
                    this.enabled[i] = enabled;
        }

        public string getStyle(string contentValue)
        {
            for (int i = 0; i < content.Count; i++)
                if (content[i] == contentValue)
                    return styles[i];

            return "";
        }

        public void setStyle(string contentValue, string styleName)
        {
            for (int i = 0; i < content.Count; i++)
                if (content[i] == contentValue)
                    this.styles[i] = styleName;
        }
    }
}
