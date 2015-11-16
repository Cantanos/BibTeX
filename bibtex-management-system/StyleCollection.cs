using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class StyleCollection
    {
        List<Style> styles;

        public List<Style> Styles { get { return styles; } }

        public StyleCollection()
        {
            styles = new List<Style>();
        }

        public void addStyle(string name, string input, string output)
        {
            styles.Add(new Style(name, input, output));
        }

        public void addStyle(string name)
        {
            styles.Add(new Style(name));
        }

        public int getSize()
        {
            return styles.Count;
        }

        public List<Style> getStyle()
        {
            return styles;
        }

        public int getStyleIndex(string styleName)
        {
            for (int i = 0; i < styles.Count; i++)
                if (styles[i].Name == styleName)
                    return i;

            return -1;
        }

        public Style getStyle(string styleName)
        {
            for (int i = 0; i < styles.Count; i++)
                if (styles[i].Name == styleName)
                    return styles[i];

            return null;
        }

        public void addStyles(List<Style> styles)
        {
            for (int i = 0; i < styles.Count; i++)
            {
                this.styles.Add(styles[i]);
            }
        } 
    }
}
