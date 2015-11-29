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
using System.Xml;
using System.Reflection;

namespace bibtex_management_system
{
    public partial class GUI : Form
    {
        FileManager texFile;
        FileManager bibFile;
        BibTeXInterpreter bibInterpreter;
        LaTeXInterpreter ltxInterpreter;
        BibTeXRecordsCollection bibRecordsCurrent;
        BibTeXRecordsCollection bibRecordsReference;
        BibTeXEntryContent bibEntryContent;
        StyleCollection styleCollection;
        StyleInterpreter styleInterpreter;
        bool isFilesOpened;
        bool boundEventSelectedItemChanged = false;

        public GUI()
        {
            InitializeComponent();
            texFile = new FileManager();
            bibFile = new FileManager();
            bibRecordsCurrent = new BibTeXRecordsCollection();
            bibRecordsReference = new BibTeXRecordsCollection();
            isFilesOpened = false;
            gridViewEntryDetail.EditMode = DataGridViewEditMode.EditOnEnter;
            bibEntryContent = new BibTeXEntryContent();
            styleCollection = new StyleCollection();
            styleInterpreter = new StyleInterpreter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Style.xml");
        }

        private void clear()
        {
            bibRecordsCurrent = new BibTeXRecordsCollection();
            bibRecordsReference = new BibTeXRecordsCollection();
            bibEntryContent = new BibTeXEntryContent();
            styleCollection = new StyleCollection();
            listViewEntires.Items.Clear();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (ofd.CheckFileExists && ofd.CheckPathExists &&
                    ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1).Equals("tex") &&
                    File.Exists(ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\\")) + "\\ref_all.bib"))
                {
                    texFile.openTexFile(ofd.FileName);
                    bibFile.openTexFile(ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\\")) + "\\ref_all.bib");

                    ltxInterpreter = new LaTeXInterpreter(texFile.getContentOfTexFile());
                    bibInterpreter = new BibTeXInterpreter(bibFile.getContentOfTexFile());
                    clear();

                    loadReferenceEntries();
                    loadCurrentEntries();
                    fillListViewEntires();

                    isFilesOpened = true;
                    MessageBox.Show("Files opened.");
                }
                else if (ofd.CheckFileExists && ofd.CheckPathExists && ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1).Equals("bib"))
                {
                    bibFile.openTexFile(ofd.FileName);
                    bibInterpreter = new BibTeXInterpreter(bibFile.getContentOfTexFile());
                    ltxInterpreter = null;
                    clear();

                    loadCurrentEntries();
                    fillListViewEntires();


                    MessageBox.Show("File opened.");
                }
                else
                {
                    isFilesOpened = false;
                    if (!File.Exists(ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\\")) + "\\ref_all.bib"))
                        MessageBox.Show("Missing reference bib file.");
                    else
                        MessageBox.Show("Please select .tex file.");
                }
            }
        }

        private void loadCurrentEntries()
        {
            if (ltxInterpreter != null)
            {
                foreach (string bibTexReference in ltxInterpreter.getAllBibtexReferences())
                {
                    BibTeXRecord rec = bibRecordsReference.getRecordByID(bibTexReference);
                    string aa = bibTexReference;
                    bibRecordsCurrent.addRecord(bibRecordsReference.getRecordByID(bibTexReference));
                }
            }
            else
            {
                foreach (BibTeXRecord tempRecord in bibInterpreter.getAllBibTeXRecords())
                {
                    if (bibRecordsCurrent.getRecordByID(tempRecord.ID) != null)
                    {
                        MessageBox.Show("Duplicate");
                    }
                    bibRecordsCurrent.addRecord(tempRecord);
                }
                //bibRecordsCurrent.addRecords(bibInterpreter.getAllBibTeXRecords());
            }
            bibEntryContent.addEntryContent(bibRecordsCurrent);

            styleCollection.addStyle("NONE", "", "");

            styleCollection.addStyles(styleInterpreter.loadStyleCollection().Styles);
        }

        private void fillListViewEntires()
        {
            if (ltxInterpreter != null)
            {
                List<string> tempCollection = ltxInterpreter.getAllBibtexReferences();
                foreach (string _ltxIterator in tempCollection)
                {
                    listViewEntires.Items.Add(new ListViewItem(_ltxIterator));
                }
            }
            else
            {
                List<BibTeXRecord> tempCollection = bibInterpreter.getAllBibTeXRecords();
                foreach (BibTeXRecord bibIterator in tempCollection)
                {
                    listViewEntires.Items.Add(new ListViewItem(bibIterator.ID));
                }
                    
            }
        }

        private void loadReferenceEntries()
        {
            bibRecordsReference.addRecords(bibInterpreter.getAllBibTeXRecords());
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help().Show();
        }

        private void listViewEntires_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEntires.SelectedItems.Count != 0)
            {
                gridViewEntryDetail.Rows.Clear(); 
                gridViewComboBox.Items.Clear();
                BibTeXRecord record = bibRecordsCurrent.getRecordByID(listViewEntires.SelectedItems[0].Text);
                fillDetailedGridView(record);
                changeStyle();
            }
        }
        

        private void fillDetailedGridView(BibTeXRecord record) 
        {
            gridViewEntryDetail.Rows.Add(2);
            gridViewEntryDetail.Rows[0].Cells[0].Value = "Type";
            gridViewEntryDetail.Rows[0].Cells[1].Value = record.Type;
            gridViewEntryDetail.Rows[0].Cells[2].Value = true;
            gridViewEntryDetail.Rows[0].Cells[2].ReadOnly = true;

            gridViewEntryDetail.Rows[1].Cells[0].Value = "ID";
            gridViewEntryDetail.Rows[1].Cells[1].Value = record.ID;
            gridViewEntryDetail.Rows[1].Cells[2].Value = true;
            gridViewEntryDetail.Rows[1].Cells[2].ReadOnly = true;

            foreach (Style tempStyle in styleCollection.Styles)
            {
                gridViewComboBox.Items.Add(tempStyle.Name);
            }

            gridViewEntryDetail.Rows[0].Cells[3].Value = gridViewComboBox.Items[0];
            gridViewEntryDetail.Rows[1].Cells[3].Value = gridViewComboBox.Items[0];


            for (int i = 0; i < record.NameOfParameters.Count; ++i)
            {
                gridViewEntryDetail.Rows.Add();

                gridViewEntryDetail.Rows[gridViewEntryDetail.Rows.Count - 1].Cells[0].Value = record.NameOfParameters[i];
                gridViewEntryDetail.Rows[gridViewEntryDetail.Rows.Count - 1].Cells[1].Value = record.ValueOfParameters[i];
                gridViewEntryDetail.Rows[gridViewEntryDetail.Rows.Count - 1].Cells[2].Value = bibEntryContent.getEnabled(record.NameOfParameters[i]);
                gridViewEntryDetail.Rows[gridViewEntryDetail.Rows.Count - 1].Cells[3].Value = gridViewComboBox.Items[styleCollection.getStyleIndex(bibEntryContent.getStyle(record.NameOfParameters[i]))]; //HARDCORE!!
            }
        }

        private void gridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 2 && e.ColumnIndex == 2) 
            {
                DataGridView gridView = sender as DataGridView;

                BibTeXRecord record = bibRecordsCurrent.getRecordByID(listViewEntires.SelectedItems[0].Text);
                bool enabled = !record.Enabled[e.RowIndex - 2];
                bibEntryContent.setEnabled(record.NameOfParameters[e.RowIndex - 2], !bibEntryContent.getEnabled(record.NameOfParameters[e.RowIndex - 2])); //zeby indexowal od zera
                foreach (BibTeXRecord tempBibRecord in bibRecordsCurrent.getRecords())
                {
                    int j=0;
                    foreach (string parameterName in tempBibRecord.NameOfParameters)
                    {
                        if (parameterName == record.NameOfParameters[e.RowIndex-2])
                        {
                            tempBibRecord.Enabled[j] = enabled;
                            break;
                        }
                        j++;
                    }
                }
            }
        }


        private void gridViewEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            ComboBox comboBox = e.Control as ComboBox;
            if (boundEventSelectedItemChanged == false)
            {
                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                boundEventSelectedItemChanged = true;
            }
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;


            int currentIndex = gridViewEntryDetail.CurrentCell.RowIndex - 2;

            if (currentIndex >= 0)
            {
                BibTeXRecord record = bibRecordsCurrent.getRecordByID(listViewEntires.SelectedItems[0].Text);
                bibEntryContent.setStyle(record.NameOfParameters[currentIndex], comboBox.Text);

                changeStyle();
            }
        }

        void changeStyle()
        {
            BibTeXRecord record = bibRecordsCurrent.getRecordByID(listViewEntires.SelectedItems[0].Text);

            for (int i = 0; i < record.NameOfParameters.Count; i++)
            {
                if (bibEntryContent.getStyle(record.NameOfParameters[i]) != "NONE")
                {
                    string changedText = styleInterpreter.getStyledText(styleCollection.getStyle(bibEntryContent.getStyle(record.NameOfParameters[i])), record.ValueOfParameters[i]);

                    gridViewEntryDetail.Rows[i + 2].Cells[1].Value = changedText;
                    record.ValueOfParameters[i] = changedText;
                }
                else
                {
                    gridViewEntryDetail.Rows[i + 2].Cells[1].Value = record.ValueOfParametersOrg[i];
                    record.ValueOfParameters[i] = record.ValueOfParametersOrg[i];
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bibRecordsCurrent.getRecords().Count == 0)
            {
                MessageBox.Show("There is no data to save.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bib File (*.bib)| *.bib";
            DialogResult result = sfd.ShowDialog();


            if (result == DialogResult.OK)
            {
                if (sfd.FileName.Substring(sfd.FileName.LastIndexOf(".") + 1).Equals("bib"))
                {
                    FileManager fileManager = new FileManager();
                    string data = "";
                    foreach (BibTeXRecord bibRecord in bibRecordsCurrent.getRecords())
                    {
                        data += bibRecord.toString();
                    }
                    fileManager.saveBibFile(sfd.FileName, data);

                    MessageBox.Show("Successfully saved.");
                }
                else
                {
                    MessageBox.Show("Wrong extension. Please select .bib file.");
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
