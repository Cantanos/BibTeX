using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bibtex_management_system
{
    public partial class MessageWithEditBox : Form
    {
        
        public MessageWithEditBox()
        {
            InitializeComponent();
        }
        static MessageWithEditBox MsgBox; static string result = "";
        public static string Show(string message, string caption = "", string editText="")
        {
            MsgBox = new MessageWithEditBox();
            MsgBox.Text = caption;
            MsgBox.TextToShow.Text = message;
            MsgBox.textBox1.Text = editText; 
            MsgBox.ShowDialog();
            return result;
        }
        private void ApplyButton_OnClick(object sender, EventArgs e)
        {
            result = textBox1.Text;
            MsgBox.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            result = "";
            MsgBox.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
