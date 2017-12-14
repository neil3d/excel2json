using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace excel2json.GUI {
    public partial class MainForm : Form {
        private DataManager mDataMgr;
        private FastColoredTextBox mJsonTextBox;
        private FastColoredTextBox mSQLTextBox;
        private FastColoredTextBox mCodeTextBox;

        private TextStyle mBrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        private TextStyle mMagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        private TextStyle mGreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        private List<ToolStripButton> mExportButtonList;

        public MainForm() {
            InitializeComponent();

            //--
            mJsonTextBox = createTextBoxInTab(this.tabPageJSON);
            mJsonTextBox.Language = Language.Custom;
            mJsonTextBox.TextChanged += new EventHandler<TextChangedEventArgs>(this.jsonTextChanged);

            mSQLTextBox = createTextBoxInTab(this.tabPageSQL);
            mSQLTextBox.Language = Language.SQL;

            mCodeTextBox = createTextBoxInTab(this.tabPageCode);
            mCodeTextBox.Language = Language.CSharp;

            //-- componet init states
            this.comboBoxType.SelectedIndex = 0;
            this.comboBoxLowcase.SelectedIndex = 1;
            this.comboBoxHeader.SelectedIndex = 1;

            this.comboBoxEncoding.Items.Clear();
            this.comboBoxEncoding.Items.Add("utf8-nobom");
            foreach (EncodingInfo ei in Encoding.GetEncodings()) {
                Encoding e = ei.GetEncoding();
                this.comboBoxEncoding.Items.Add(e.EncodingName);
            }
            this.comboBoxEncoding.SelectedIndex = 0;

            //--
            mExportButtonList = new List<ToolStripButton>();
            mExportButtonList.Add(this.btnCopyJSON);
            mExportButtonList.Add(this.btnSaveJson);
            mExportButtonList.Add(this.btnSaveSQL);
            mExportButtonList.Add(this.btnSaveCSharp);
            enableExportButtons(false);

            mDataMgr = new DataManager();
        }

        private void enableExportButtons(bool enable) {
            foreach (var btn in mExportButtonList)
                btn.Enabled = enable;
        }

        private FastColoredTextBox createTextBoxInTab(TabPage tab) {
            FastColoredTextBox textBox = new FastColoredTextBox();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Microsoft YaHei", 11F);
            tab.Controls.Add(textBox);
            return textBox;
        }

        private void jsonTextChanged(object sender, TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(mBrownStyle, mMagentaStyle, mGreenStyle);
            //allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers("{", "}");
            //string highlighting
            e.ChangedRange.SetStyle(mBrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //number highlighting
            e.ChangedRange.SetStyle(mGreenStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
        }

        private void loadExcelAsync(string path) {
            //-- update ui
            this.labelExcelFile.Text = path;
            enableExportButtons(false);

            //-- load options from ui
            Program.Options options = new Program.Options();
            options.ExcelPath = path;
            options.ExportArray = this.comboBoxType.SelectedIndex == 0;
            options.Encoding = this.comboBoxEncoding.SelectedText;
            options.Lowcase = this.comboBoxLowcase.SelectedIndex == 0;
            options.HeaderRows = int.Parse(this.comboBoxHeader.Text);

            //-- start import
            this.backgroundWorker.RunWorkerAsync(options);
        }

        private void panelExcelDropBox_DragDrop(object sender, DragEventArgs e) {
            string[] dropData = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (dropData != null) {
                this.loadExcelAsync(dropData[0]);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://neil3d.github.io");
        }

        private void panelExcelDropBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.All;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            lock (this.mDataMgr) {
                try {
                    this.mDataMgr.loadExcel((Program.Options)e.Argument);
                }
                catch (Exception exp) {
                    e.Result = exp;
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            lock (this.mDataMgr) {
                this.statusLabel.IsLink = false;
                this.statusLabel.Text = "Load completed.";

                mJsonTextBox.Text = mDataMgr.JsonContext;
                mSQLTextBox.Text = mDataMgr.SQLContext;
                mCodeTextBox.Text = mDataMgr.CSharpCode;

                enableExportButtons(true);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Filter = "Excel File(*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK) {
                this.loadExcelAsync(dlg.FileName);
            }
        }

        private void statusLabel_Click(object sender, EventArgs e) {
            if (this.statusLabel.IsLink) {
                System.Diagnostics.Process.Start(this.statusLabel.Text);
            }
        }

        private void saveToFile(int type, string filter) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.RestoreDirectory = true;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) {
                lock (mDataMgr) {
                    switch (type) {
                        case 1:
                            mDataMgr.saveJson(dlg.FileName);
                            break;
                        case 2:
                            mDataMgr.saveSQL(dlg.FileName);
                            break;
                        case 3:
                            mDataMgr.saveCode(dlg.FileName);
                            break;
                    }
                }
            }// end of if
        }

        private void btnSaveJson_Click(object sender, EventArgs e) {
            saveToFile(1, "Json File(*.json)|*.json");  
        }

        private void btnSaveSQL_Click(object sender, EventArgs e) {
            saveToFile(2, "SQL File(*.sql)|*.sql");

        }

        private void btnSaveCSharp_Click(object sender, EventArgs e) {
            saveToFile(3, "C# Code File(*.cs)|*.cs");  
        }
    }
}
