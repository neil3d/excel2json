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



        private TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        private TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        private TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);

        public MainForm() {
            InitializeComponent();

            //--
            mJsonTextBox = createTextBoxInTab(this.tabPageJSON);
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
            foreach (EncodingInfo ei in Encoding.GetEncodings()) {
                Encoding e = ei.GetEncoding();
                this.comboBoxEncoding.Items.Add(e.EncodingName);
                System.Diagnostics.Debug.Print(e.EncodingName);
            }
            this.comboBoxEncoding.SelectedIndex = this.comboBoxEncoding.Items.Count - 1;

            //--
            mDataMgr = new DataManager();
        }

        private FastColoredTextBox createTextBoxInTab(TabPage tab) {
            FastColoredTextBox textBox = new FastColoredTextBox();
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Microsoft YaHei", 11F);
            tab.Controls.Add(textBox);
            return textBox;
        }

        private void jsonTextChanged(object sender, TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(BrownStyle, MagentaStyle, GreenStyle);
            //allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers("{", "}");
            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //number highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
        }

        private void loadExcelAsync(string path) {
            this.labelExcelFile.Text = path;

            Program.Options options = new Program.Options();
            options.ExcelPath = path;
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
    }
}
