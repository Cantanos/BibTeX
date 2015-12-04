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
            BibTeXRecord result = new BibTeXRecord(getParameters(toPrepare));
            result.Type = readType(toPrepare);
            result.ID = readID(toPrepare);
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

        List<Parameter> getParameters(string pToPrepare)
        {
            List<Parameter> result = new List<Parameter>();
            pToPrepare = pToPrepare.Substring(pToPrepare.IndexOf(","), pToPrepare.LastIndexOf("}") - pToPrepare.IndexOf(","));
            List<string> lines = new List<string>(pToPrepare.Split('\n'));
            string value = "";
            bool completed = true;
            for(int i=0; i<lines.Count; i++)
            {
                if (lines[i].Contains("="))
                {
                    if (completed)
                        value = getValue(lines[i]);
                    else
                        value += getValue(lines[i]);

                    if (lines[i].Contains('}'))
                    {
                        completed = true;
                        string name = lines[i].Substring(0, lines[i].IndexOf('=')).Trim();
                        result.Add(new Parameter(name, value));
                    }
                    else
                        completed = false;
                }
            }
            return result;
        }

        private string getValue(string pParameter)
        {
            if (pParameter.IndexOf('{') == -1 || pParameter.LastIndexOf('}') == -1)
            {
                return pParameter.Substring(pParameter.IndexOf('=')).Trim();
            }
            else
            {
                return pParameter = pParameter.Substring(pParameter.IndexOf('{') + 1, pParameter.LastIndexOf('}') - pParameter.IndexOf('{') - 1);
            }
        }

        //List<string> readValuesOfParametersOfRecord(string toPrepare)
        //{
        //    toPrepare = toPrepare.Substring(toPrepare.IndexOf(","), toPrepare.LastIndexOf("}") - toPrepare.IndexOf(","));
        //    List<string> result = new List<string>(toPrepare.Split('\n'));

        //    for (int i = 0; i < result.Count; ++i)
        //    {
        //        result[i] = result[i].Trim().Replace("\r", "");
        //        if (!result[i].Contains('=') && !result[i].Contains('}'))
        //        {
        //            result.RemoveAt(i);
        //            i--;
        //        }
        //        else if (!result[i].Contains('=') && result[i].Contains('}'))
        //        {
        //            result[i - 1] += result[i];
        //            result.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //    for (int i = 0; i < result.Count; ++i)
        //    {
        //        if (result[i].IndexOf('{') == -1 || result[i].LastIndexOf('}') == -1)
        //        {
        //            result[i].Substring(result[i].IndexOf('=')).Trim();
        //        }
        //        else
        //        {
        //            result[i] = result[i].Substring(result[i].IndexOf('{') + 1, result[i].LastIndexOf('}') - result[i].IndexOf('{') - 1);
        //        }
        //    }

        //    return result;
        //}
    }
}
