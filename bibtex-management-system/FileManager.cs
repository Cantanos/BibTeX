using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bibtex_management_system
{
    class FileManager
    {
        string texFileContent;

        public bool openTexFile(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            using (StreamReader sr = File.OpenText(path))
            {
                texFileContent = sr.ReadToEnd();
            }
            return true;
        }

        public void saveBibFile(string path, string data)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(data);
            }
        }

        public string getContentOfTexFile()
        {
            return this.texFileContent;
        }
    }
}
