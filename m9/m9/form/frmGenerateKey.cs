using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace m9
{
    public partial class frmGenerateKey : Form
    {
        int currentBitStrength = 1024;
        public frmGenerateKey()
        {
            InitializeComponent();
        }
        private bool saveFile(string title, string filterString, string outputString)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = title;
            saveFileDialog.Filter = filterString;//เลือกtype
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false);
                    if (outputString != null)
                    { streamWriter.Write(outputString); }
                    streamWriter.Close();
                    return true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    return false;
                }
            }
            return false;
        }
        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(currentBitStrength);
            string PrivateKeys = "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(true);//generate key
            string PublicKey = "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(false);
            if (saveFile("Save Private Keys As", "Private Keys Document( *.kez )|*.kez", PrivateKeys))
            {
                if (saveFile("Save Public Key As", "Public Key Document( *.pke )|*.pke", PublicKey))
                {
                    MessageBox.Show("Export Key complete.", "msgBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
    }
}
