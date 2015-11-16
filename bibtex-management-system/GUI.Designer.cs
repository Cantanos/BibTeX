namespace bibtex_management_system
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewEntires = new System.Windows.Forms.ListView();
            this.columnEntries = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gridViewEntryDetail = new System.Windows.Forms.DataGridView();
            this.gridViewNameOfParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewValueOfParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridViewComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntryDetail)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // listViewEntires
            // 
            this.listViewEntires.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEntries});
            this.listViewEntires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEntires.FullRowSelect = true;
            this.listViewEntires.Location = new System.Drawing.Point(3, 3);
            this.listViewEntires.MultiSelect = false;
            this.listViewEntires.Name = "listViewEntires";
            this.listViewEntires.Size = new System.Drawing.Size(193, 211);
            this.listViewEntires.TabIndex = 2;
            this.listViewEntires.UseCompatibleStateImageBehavior = false;
            this.listViewEntires.View = System.Windows.Forms.View.Details;
            this.listViewEntires.SelectedIndexChanged += new System.EventHandler(this.listViewEntires_SelectedIndexChanged);
            // 
            // columnEntries
            // 
            this.columnEntries.Tag = "asd";
            this.columnEntries.Text = "Entries";
            this.columnEntries.Width = 190;
            // 
            // gridViewEntryDetail
            // 
            this.gridViewEntryDetail.AllowUserToAddRows = false;
            this.gridViewEntryDetail.AllowUserToDeleteRows = false;
            this.gridViewEntryDetail.AllowUserToResizeRows = false;
            this.gridViewEntryDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridViewEntryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewEntryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewNameOfParameter,
            this.gridViewValueOfParameter,
            this.gridViewCheckBox,
            this.gridViewComboBox});
            this.gridViewEntryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewEntryDetail.Location = new System.Drawing.Point(202, 3);
            this.gridViewEntryDetail.Name = "gridViewEntryDetail";
            this.gridViewEntryDetail.RowHeadersVisible = false;
            this.gridViewEntryDetail.Size = new System.Drawing.Size(460, 211);
            this.gridViewEntryDetail.TabIndex = 4;
            this.gridViewEntryDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewCellContentClick);
            this.gridViewEntryDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridViewEditingControlShowing);
            // 
            // gridViewNameOfParameter
            // 
            this.gridViewNameOfParameter.HeaderText = "Name of Parameter";
            this.gridViewNameOfParameter.Name = "gridViewNameOfParameter";
            this.gridViewNameOfParameter.ReadOnly = true;
            this.gridViewNameOfParameter.Width = 140;
            // 
            // gridViewValueOfParameter
            // 
            this.gridViewValueOfParameter.HeaderText = "Value of Parameter";
            this.gridViewValueOfParameter.Name = "gridViewValueOfParameter";
            this.gridViewValueOfParameter.ReadOnly = true;
            this.gridViewValueOfParameter.Width = 140;
            // 
            // gridViewCheckBox
            // 
            this.gridViewCheckBox.HeaderText = "Enable";
            this.gridViewCheckBox.Name = "gridViewCheckBox";
            this.gridViewCheckBox.Width = 60;
            // 
            // gridViewComboBox
            // 
            this.gridViewComboBox.HeaderText = "Style";
            this.gridViewComboBox.Name = "gridViewComboBox";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.listViewEntires, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridViewEntryDetail, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 217);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 241);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(673, 600);
            this.MinimumSize = new System.Drawing.Size(673, 200);
            this.Name = "GUI";
            this.Text = "BibTeX Management System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntryDetail)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listViewEntires;
        private System.Windows.Forms.ColumnHeader columnEntries;
        private System.Windows.Forms.DataGridView gridViewEntryDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewNameOfParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewValueOfParameter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridViewCheckBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridViewComboBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

