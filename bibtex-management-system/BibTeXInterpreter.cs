using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class BibTeXInterpreter
    {
        string content;

        public BibTeXInterpreter(string content)
        {
            this.content = content;
        }

        public List<BibTeXRecord> getAllBibTeXRecords()
        {
            List<string> a = new List<string>();
            List<BibTeXRecord> records = new List<BibTeXRecord>();
            if (content != null && !String.Empty.Equals(content))
            {
                string tmp = content;
                while (tmp.IndexOf("@") != -1)
                {
                    tmp = tmp.Substring(tmp.IndexOf("@") + 1);
                    if (tmp.IndexOf("@") != -1)
                        records.Add(prepareRecord(tmp.Substring(0, tmp.IndexOf("@"))));
                    else
                        records.Add(prepareRecord(tmp));

                }
            }
            return records;
        }

        BibTeXRecord prepareRecord(string toPrepare)
        {
            BibTeXRecord result = new BibTeXRecord(readNamesOfParametersOfRecord(toPrepare), readValuesOfParametersOfRecord(toPrepare));
            result.Type = readType(toPrepare);
            result.ID = readID(toPrepare);
            for (int i = 0; i < result.NameOfParameters.Count; i++)
            {
                result.Enabled.Add(true);
            }

            return result;
        }

        string readType(string toPrepare)
        {
            return toPrepare.Substring(0, toPrepare.IndexOf("{"));
        }

        string readID(string toPrepare)
        {
            return toPrepare.Substring(toPrepare.IndexOf("{") + 1, toPrepare.IndexOf(",") - toPrepare.IndexOf("{") - 1);
        }

        List<string> readNamesOfParametersOfRecord(string toPrepare)
        {
            toPrepare = toPrepare.Substring(toPrepare.IndexOf(",") + 1);
            List<string> result = new List<string>(toPrepare.Split('\n'));

            for (int i = 0; i < result.Count; ++i)
            {
                if (!result[i].Contains("="))
                {
                    result.RemoveAt(i);
                    i--;
                }
                else
                {
                    result[i] = result[i].Substring(0, result[i].IndexOf('=')).Trim();
                }
            }
            return result;
        }

        List<string> readValuesOfParametersOfRecord(string toPrepare)
        {
            toPrepare = toPrepare.Substring(toPrepare.IndexOf(","), toPrepare.LastIndexOf("}") - toPrepare.IndexOf(","));
            List<string> result = new List<string>(toPrepare.Split('\n'));

            for (int i = 0; i < result.Count; ++i)
            {
                result[i] = result[i].Trim().Replace("\r", "");
                if (!result[i].Contains('=') && !result[i].Contains('}'))
                {
                    result.RemoveAt(i);
                    i--;
                }
                else if (!result[i].Contains('=') && result[i].Contains('}'))
                {
                    result[i - 1] += result[i];
                    result.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < result.Count; ++i)
            {
                if (result[i].IndexOf('{') == -1 || result[i].LastIndexOf('}') == -1)
                {
                    result[i].Substring(result[i].IndexOf('=')).Trim();
                }
                else
                {
                    result[i] = result[i].Substring(result[i].IndexOf('{') + 1, result[i].LastIndexOf('}') - result[i].IndexOf('{') - 1);
                }
            }

            return result;
        }
    }
}
