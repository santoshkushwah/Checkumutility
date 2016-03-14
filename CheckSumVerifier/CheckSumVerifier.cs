
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckSumVerifier
{
    public partial class FilecheckSumVerifier : Form
    {
        public FilecheckSumVerifier()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Excel file(*.xlsx)|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName;
                    fileName = dlg.FileName;

                    string checkSumFromProperty = XlsxReader.GetCheckSumFromFileProperty(fileName);

                    if (string.IsNullOrEmpty(checkSumFromProperty))
                    {
                        MessageBox.Show("Selected file is invalid(checksum code is missing).");
                    }

                    string fileChecksum = XlsxReader.GetCheckSumFromFile(fileName);


                    if (fileChecksum == checkSumFromProperty)
                        {
                            MessageBox.Show("Selected file is valid(untempered).");
                        }
                        else
                        {
                            MessageBox.Show("Selected file is invalid(tempered).");
                        }

                       
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
