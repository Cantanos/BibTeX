using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bibtex_management_system
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("bibtex_management_system.ImageHELP.jpg");
            Bitmap image = new Bitmap(myStream);

            this.ClientSize = new Size(image.Width, image.Height);

            PictureBox pb = new PictureBox();
            pb.Image = image;
            pb.Dock = DockStyle.Fill;
            this.Controls.Add(pb);
        }
    }
}
