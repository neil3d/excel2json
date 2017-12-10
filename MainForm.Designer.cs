namespace excel2json {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImportExcel = new System.Windows.Forms.ToolStripButton();
            this.btnCopyJSON = new System.Windows.Forms.ToolStripButton();
            this.btnExportJSON = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelExcelDropBox = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxExcel = new System.Windows.Forms.PictureBox();
            this.labelExcelFile = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelExcelDropBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "Ready";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(57, 17);
            this.statusLabel.Text = "Ready ...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportExcel,
            this.btnCopyJSON,
            this.btnExportJSON,
            this.toolStripSeparator2,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 48);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "Import excel file and export as JSON";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Image = global::excel2json.Properties.Resources.excel;
            this.btnImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(85, 45);
            this.btnImportExcel.Text = "Import Excel";
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportExcel.ToolTipText = "Import Excel .xlsx file";
            // 
            // btnCopyJSON
            // 
            this.btnCopyJSON.Image = global::excel2json.Properties.Resources.clipboard;
            this.btnCopyJSON.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyJSON.Name = "btnCopyJSON";
            this.btnCopyJSON.Size = new System.Drawing.Size(78, 45);
            this.btnCopyJSON.Text = "Copy JSON";
            this.btnCopyJSON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopyJSON.ToolTipText = "Copy JSON string to clipboard";
            // 
            // btnExportJSON
            // 
            this.btnExportJSON.Image = global::excel2json.Properties.Resources.json;
            this.btnExportJSON.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportJSON.Name = "btnExportJSON";
            this.btnExportJSON.Size = new System.Drawing.Size(86, 45);
            this.btnExportJSON.Text = "Export JSON";
            this.btnExportJSON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportJSON.ToolTipText = "Export JSON file";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::excel2json.Properties.Resources.about;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(39, 45);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelExcelDropBox);
            this.splitContainer1.Size = new System.Drawing.Size(784, 492);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 5;
            // 
            // panelExcelDropBox
            // 
            this.panelExcelDropBox.AllowDrop = true;
            this.panelExcelDropBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelExcelDropBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExcelDropBox.Controls.Add(this.flowLayoutPanel1);
            this.panelExcelDropBox.Location = new System.Drawing.Point(8, 10);
            this.panelExcelDropBox.Name = "panelExcelDropBox";
            this.panelExcelDropBox.Size = new System.Drawing.Size(245, 120);
            this.panelExcelDropBox.TabIndex = 0;
            this.panelExcelDropBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelExcelDropBox_DragDrop);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pictureBoxExcel);
            this.flowLayoutPanel1.Controls.Add(this.labelExcelFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 118);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxExcel
            // 
            this.pictureBoxExcel.Image = global::excel2json.Properties.Resources.excel;
            this.pictureBoxExcel.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxExcel.Name = "pictureBoxExcel";
            this.pictureBoxExcel.Size = new System.Drawing.Size(237, 50);
            this.pictureBoxExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExcel.TabIndex = 0;
            this.pictureBoxExcel.TabStop = false;
            // 
            // labelExcelFile
            // 
            this.labelExcelFile.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelExcelFile.Location = new System.Drawing.Point(3, 56);
            this.labelExcelFile.Name = "labelExcelFile";
            this.labelExcelFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelExcelFile.Size = new System.Drawing.Size(237, 62);
            this.labelExcelFile.TabIndex = 1;
            this.labelExcelFile.Text = "Drop you .xlsx file here!";
            this.labelExcelFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelExcelDropBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImportExcel;
        private System.Windows.Forms.ToolStripButton btnExportJSON;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelExcelDropBox;
        private System.Windows.Forms.ToolStripButton btnCopyJSON;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxExcel;
        private System.Windows.Forms.Label labelExcelFile;
    }
}