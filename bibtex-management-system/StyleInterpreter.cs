using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace bibtex_management_system
{
    class StyleInterpreter
    {
        string path;
        bool good;

        public StyleInterpreter(string path)
        {
            this.path = path;
            good = false;

            if (!checkXmlFileExist())
                System.Windows.Forms.MessageBox.Show("File does not exist");
            else if (!checkXmlLoadGood())
                System.Windows.Forms.MessageBox.Show("Could not load xml file");
            else if (!checkXmlContent())
                System.Windows.Forms.MessageBox.Show("File content is improper");
            else if (!checkXmlUniqueID())
                System.Windows.Forms.MessageBox.Show("Styles ID must be unique");
            else
                // System.Windows.Forms.MessageBox.Show("Styles loaded successfully");
                good = true;
        }

        public StyleCollection loadStyleCollection()
        {
            StyleCollection collection = new StyleCollection();
            if (good)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(this.path);
                string name = "";
                List<string> input = new List<string>();
                string output = "";

                foreach (XmlNode node in xml.SelectNodes("styles/style"))
                {
                    if (node.Attributes.Count == 1 && node.Attributes[0].Name == "type")
                        name = node.Attributes[0].Value;

                    collection.addStyle(name);
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        foreach (XmlNode child2 in child.ChildNodes)
                        {
                            if (child2.Name == "input")
                                input.Add(child2.InnerText);
                            else if (child2.Name == "output")
                                output = child2.InnerText;
                        }
                        collection.getStyle()[collection.getSize() - 1].addSubStyle(input, output);
                        input.Clear();
                    }

                }
            }

            return collection;
        }

        public string getStyledText(Style style, string text)
        {
            string[] split = text.Split(new char[] { ' ' });

            bool found = false;


            for (int k = 0; k < style.SubStyle.Count; k++)
            {
                for (int i = 0; i < style.SubStyle[k].Input.Count; i++)
                {
                    for (int j = 0; j < split.Length; j++)
                    {
                        if (split[j] == style.SubStyle[k].Input[i])
                        {
                            split[j] = style.SubStyle[k].Output;
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                text = "";
                for (int i = 0; i < split.Length; i++)
                    text += split[i] + " ";

                text.Remove(text.Length - 1);
            }

            return text;

        }

        bool checkXmlFileExist()
        {
            return File.Exists(this.path);
        }

        bool checkXmlLoadGood()
        {
            XmlDocument xml = new XmlDocument();

            try
            {
                xml.Load(this.path);
            }
            catch
            {
                return false;
            }

            return true;
        }

        bool checkXmlContent()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(this.path);

            bool good = false;

            foreach (XmlNode node in xml.SelectNodes("styles/style"))
            {
                if (node.Attributes.Count != 1 || node.Attributes[0].Name != "type" || node.Attributes[0].Value.Length == 0)
                    return false;
                else if (node.ChildNodes.Count == 0)
                    return false;

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name != "code")
                        return false;
                    else if (child.ChildNodes.Count < 1)
                        return false;

                    int inputCount = 0;
                    int outputCount = 0;
                    int useCount = 0;
                    foreach (XmlNode child2 in child.ChildNodes)
                    {
                        if (child2.Name != "input" && child2.Name != "output" && child2.Name != "use")
                            return false;
                        else if (child2.Name == "input")
                            inputCount++;
                        else if (child2.Name == "output")
                            outputCount++;
                        else if (child2.Name == "use")
                            useCount++;
                    }

                    if (inputCount == 0 && useCount == 0)
                        return false;
                    else if ((outputCount == 0 && useCount == 0) || outputCount > 1)
                        return false;
                    else if (useCount != 0 && (inputCount != 0 || outputCount != 0))
                        return false;
                }

                good = true;
            }

            return good;
        }

        bool checkXmlUniqueID()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(this.path);

            List<string> ID = new List<string>();

            foreach (XmlNode node in xml.SelectNodes("styles/style"))
            {
                ID.Add(node.Attributes[0].Value);
            }

            for (int i = 0; i < ID.Count; i++)
            {
                for (int j = 0; j < ID.Count; j++)
                {
                    if (j != i && ID[i] == ID[j])
                        return false;
                }
            }

            return true;
        }
    }
}
