namespace excel2json.GUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnImportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyJSON = new System.Windows.Forms.ToolStripButton();
            this.btnSaveJson = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelExcelDropBox = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxExcel = new System.Windows.Forms.PictureBox();
            this.labelExcelFile = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDateFormat = new System.Windows.Forms.ComboBox();
            this.btnReimport = new System.Windows.Forms.Button();
            this.comboBoxLowcase = new System.Windows.Forms.ComboBox();
            this.comboBoxHeader = new System.Windows.Forms.ComboBox();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.tabControlCode = new System.Windows.Forms.TabControl();
            this.tabPageJSON = new System.Windows.Forms.TabPage();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.comboBoxSheetName = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelExcelDropBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxExcel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControlCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(11, 99);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(142, 24);
            label2.TabIndex = 1;
            label2.Text = "Encoding:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 43);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 24);
            label1.TabIndex = 1;
            label1.Text = "Export Type:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(11, 149);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(142, 24);
            label4.TabIndex = 6;
            label4.Text = "Lowcase:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(11, 203);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(142, 24);
            label3.TabIndex = 4;
            label3.Text = "Header:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(11, 253);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(142, 24);
            label5.TabIndex = 9;
            label5.Text = "Date Format:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 1095);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip.Size = new System.Drawing.Size(1437, 29);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "Ready";
            // 
            // statusLabel
            // 
            this.statusLabel.IsLink = true;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusLabel.Size = new System.Drawing.Size(211, 24);
            this.statusLabel.Text = "https://neil3d.github.io";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.btnImportExcel, this.toolStripSeparator1, this.btnCopyJSON, this.btnSaveJson,
                this.toolStripSeparator2, this.btnHelp
            });
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(1437, 55);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "Import excel file and export as JSON";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Image = global::excel2json.Properties.Resources.excel;
            this.btnImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(121, 52);
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportExcel.ToolTipText = "Import Excel .xlsx file";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCopyJSON
            // 
            this.btnCopyJSON.Image = global::excel2json.Properties.Resources.clipboard;
            this.btnCopyJSON.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyJSON.Name = "btnCopyJSON";
            this.btnCopyJSON.Size = new System.Drawing.Size(111, 52);
            this.btnCopyJSON.Text = "Copy JSON";
            this.btnCopyJSON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopyJSON.ToolTipText = "Copy JSON string to clipboard";
            this.btnCopyJSON.Click += new System.EventHandler(this.btnCopyJSON_Click);
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.Image = global::excel2json.Properties.Resources.json;
            this.btnSaveJson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(105, 52);
            this.btnSaveJson.Text = "Save JSON";
            this.btnSaveJson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveJson.ToolTipText = "Save JSON file";
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::excel2json.Properties.Resources.about;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(55, 52);
            this.btnHelp.Text = "Help";
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHelp.ToolTipText = "Help Document on web";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlCode);
            this.splitContainer1.Size = new System.Drawing.Size(1437, 1040);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelExcelDropBox);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 1038);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelExcelDropBox
            // 
            this.panelExcelDropBox.AllowDrop = true;
            this.panelExcelDropBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelExcelDropBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExcelDropBox.Controls.Add(this.flowLayoutPanel2);
            this.panelExcelDropBox.Location = new System.Drawing.Point(15, 16);
            this.panelExcelDropBox.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panelExcelDropBox.Name = "panelExcelDropBox";
            this.panelExcelDropBox.Size = new System.Drawing.Size(447, 422);
            this.panelExcelDropBox.TabIndex = 1;
            this.panelExcelDropBox.DragDrop +=
                new System.Windows.Forms.DragEventHandler(this.panelExcelDropBox_DragDrop);
            this.panelExcelDropBox.DragEnter +=
                new System.Windows.Forms.DragEventHandler(this.panelExcelDropBox_DragEnter);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pictureBoxExcel);
            this.flowLayoutPanel2.Controls.Add(this.labelExcelFile);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(445, 420);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxExcel
            // 
            this.pictureBoxExcel.Image = global::excel2json.Properties.Resources.excel_64;
            this.pictureBoxExcel.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxExcel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBoxExcel.Name = "pictureBoxExcel";
            this.pictureBoxExcel.Size = new System.Drawing.Size(435, 200);
            this.pictureBoxExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExcel.TabIndex = 0;
            this.pictureBoxExcel.TabStop = false;
            // 
            // labelExcelFile
            // 
            this.labelExcelFile.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.labelExcelFile.Location = new System.Drawing.Point(5, 210);
            this.labelExcelFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelExcelFile.Name = "labelExcelFile";
            this.labelExcelFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelExcelFile.Size = new System.Drawing.Size(435, 140);
            this.labelExcelFile.TabIndex = 1;
            this.labelExcelFile.Text = "Drop you .xlsx file here!";
            this.labelExcelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(this.comboBoxSheetName);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this.comboBoxDateFormat);
            this.groupBox1.Controls.Add(this.btnReimport);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.comboBoxLowcase);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(this.comboBoxHeader);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.comboBoxEncoding);
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(15, 470);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(447, 438);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // comboBoxDateFormat
            // 
            this.comboBoxDateFormat.DisplayMember = "0";
            this.comboBoxDateFormat.FormattingEnabled = true;
            this.comboBoxDateFormat.Items.AddRange(new object[] {"yyyy/MM/dd", "yyyy/MM/dd hh:mm:ss"});
            this.comboBoxDateFormat.Location = new System.Drawing.Point(164, 248);
            this.comboBoxDateFormat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxDateFormat.Name = "comboBoxDateFormat";
            this.comboBoxDateFormat.Size = new System.Drawing.Size(272, 32);
            this.comboBoxDateFormat.TabIndex = 8;
            this.comboBoxDateFormat.ValueMember = "0";
            // 
            // btnReimport
            // 
            this.btnReimport.Location = new System.Drawing.Point(128, 360);
            this.btnReimport.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnReimport.Name = "btnReimport";
            this.btnReimport.Size = new System.Drawing.Size(137, 45);
            this.btnReimport.TabIndex = 7;
            this.btnReimport.Text = "Reimport";
            this.btnReimport.UseVisualStyleBackColor = true;
            this.btnReimport.Click += new System.EventHandler(this.btnReimport_Click);
            // 
            // comboBoxLowcase
            // 
            this.comboBoxLowcase.DisplayMember = "0";
            this.comboBoxLowcase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLowcase.FormattingEnabled = true;
            this.comboBoxLowcase.Items.AddRange(new object[] {"Yes", "No"});
            this.comboBoxLowcase.Location = new System.Drawing.Point(164, 144);
            this.comboBoxLowcase.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxLowcase.Name = "comboBoxLowcase";
            this.comboBoxLowcase.Size = new System.Drawing.Size(272, 32);
            this.comboBoxLowcase.TabIndex = 5;
            this.comboBoxLowcase.ValueMember = "0";
            // 
            // comboBoxHeader
            // 
            this.comboBoxHeader.DisplayMember = "0";
            this.comboBoxHeader.FormattingEnabled = true;
            this.comboBoxHeader.Items.AddRange(new object[] {"2", "3", "4", "5", "6"});
            this.comboBoxHeader.Location = new System.Drawing.Point(164, 196);
            this.comboBoxHeader.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxHeader.Name = "comboBoxHeader";
            this.comboBoxHeader.Size = new System.Drawing.Size(272, 32);
            this.comboBoxHeader.TabIndex = 3;
            this.comboBoxHeader.ValueMember = "0";
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DisplayMember = "0";
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.FormattingEnabled = true;
            this.comboBoxEncoding.Location = new System.Drawing.Point(164, 92);
            this.comboBoxEncoding.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(272, 32);
            this.comboBoxEncoding.TabIndex = 0;
            this.comboBoxEncoding.ValueMember = "0";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DisplayMember = "0";
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {"Array", "Dict Object"});
            this.comboBoxType.Location = new System.Drawing.Point(164, 40);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(272, 32);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.ValueMember = "0";
            // 
            // tabControlCode
            // 
            this.tabControlCode.Controls.Add(this.tabPageJSON);
            this.tabControlCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCode.Location = new System.Drawing.Point(0, 0);
            this.tabControlCode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabControlCode.Name = "tabControlCode";
            this.tabControlCode.SelectedIndex = 0;
            this.tabControlCode.Size = new System.Drawing.Size(1167, 1038);
            this.tabControlCode.TabIndex = 0;
            // 
            // tabPageJSON
            // 
            this.tabPageJSON.Location = new System.Drawing.Point(4, 33);
            this.tabPageJSON.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageJSON.Name = "tabPageJSON";
            this.tabPageJSON.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabPageJSON.Size = new System.Drawing.Size(1159, 1001);
            this.tabPageJSON.TabIndex = 0;
            this.tabPageJSON.Text = "JSON";
            this.tabPageJSON.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted +=
                new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(11, 306);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(142, 24);
            label6.TabIndex = 11;
            label6.Text = "Sheet Name:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxSheetName
            // 
            this.comboBoxSheetName.DisplayMember = "0";
            this.comboBoxSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSheetName.FormattingEnabled = true;
            this.comboBoxSheetName.Items.AddRange(new object[] {"Yes", "No"});
            this.comboBoxSheetName.Location = new System.Drawing.Point(164, 301);
            this.comboBoxSheetName.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSheetName.Name = "comboBoxSheetName";
            this.comboBoxSheetName.Size = new System.Drawing.Size(272, 32);
            this.comboBoxSheetName.TabIndex = 10;
            this.comboBoxSheetName.ValueMember = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 1124);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MinimumSize = new System.Drawing.Size(1448, 1144);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "excel2json";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelExcelDropBox.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxExcel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlCode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnImportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnCopyJSON;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelExcelDropBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxExcel;
        private System.Windows.Forms.Label labelExcelFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxLowcase;
        private System.Windows.Forms.ComboBox comboBoxHeader;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripButton btnSaveJson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnReimport;
        private System.Windows.Forms.TabControl tabControlCode;
        private System.Windows.Forms.TabPage tabPageJSON;
        private System.Windows.Forms.ComboBox comboBoxDateFormat;
        private System.Windows.Forms.ComboBox comboBoxSheetName;
    }
}