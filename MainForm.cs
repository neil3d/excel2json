using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel2json {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void panelExcelDropBox_DragDrop(object sender, DragEventArgs e) {

        }

        private void btnHelp_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://neil3d.github.io");
        }
    }
}
