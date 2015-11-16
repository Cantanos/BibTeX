using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class LaTeXInterpreter
    {
        string content;


        public LaTeXInterpreter(string content)
        {
            this.content = content;
        }
        public List<string> getAllBibtexReferences()
        {
            List<string> references = new List<string>();
            if (content != null && !String.Empty.Equals(content))
            {
                string tmp = content;
                while (tmp.IndexOf("\\cite") != -1)
                {
                    tmp = tmp.Substring(tmp.IndexOf("\\cite") + 6);
                    references.AddRange(prepareIdentifier(tmp.Substring(0, tmp.IndexOf("}"))));
                }
                List<string> copy = new List<string>(references);
                references.Clear();
                references.AddRange(removeDuplicate(copy));

            }
            return references;
        }

        List<string> prepareIdentifier(string toPrepare)
        {
            List<string> result = new List<string>();

            if (toPrepare.Contains(","))
            {
                List<string> fromSplit = new List<string>(toPrepare.Split(','));
                foreach (string e in fromSplit)
                {
                    result.Add(removeSpecialCharacters(e));
                }
            }
            else
            {
                result.Add(removeSpecialCharacters(toPrepare));
            }
            return result;
        }

        string removeSpecialCharacters(string toPrepare)
        {
            for (int i = 0; i < toPrepare.Length; ++i)
            {
                if (!(toPrepare[i] > 64 && toPrepare[i] < 100))
                {
                    if (!(toPrepare[i] > 96 && toPrepare[i] < 123))
                    {
                        if (!(toPrepare[i] > 47 && toPrepare[i] < 58))
                        {
                            toPrepare = toPrepare.Replace(toPrepare[i].ToString(), "");
                        }
                    }
                }
            }
            return toPrepare.Trim();
        }

        List<string> removeDuplicate(List<string> toPrepare)
        {
            List<string> list = new List<string>();
            foreach (string e in toPrepare)
            {
                if (!list.Contains(e))
                {
                    list.Add(e);
                }
            }
            return list;
        }

    }
}
