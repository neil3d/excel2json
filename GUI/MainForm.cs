using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel2json.GUI {
    public partial class MainForm : Form {
        private DataManager mDataMgr;

        public MainForm() {
            InitializeComponent();

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

        private void loadExcelAsync(string path) {
            this.labelExcelFile.Text = path;

            ExcelLoader loader = new ExcelLoader();
            loader.path = path;
            this.backgroundWorker.RunWorkerAsync(loader);
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
                this.mDataMgr.loadExcel((ExcelLoader)e.Argument);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            lock (this.mDataMgr) {

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
    }
}
