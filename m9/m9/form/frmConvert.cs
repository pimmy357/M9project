using RSACryptoPad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m9
{
    public partial class frmConvert : Form
    {
        public frmConvert()
        {
            InitializeComponent();
        }
        public delegate void FinishedProcessDelegate();
        public delegate void UpdateBitStrengthDelegate(int bitStrength);
        public delegate void UpdateTextDelegate(string inputText);

        private void UpdateText(string inputText)
        { txtOutput.Text = inputText; }

        private void FinishedProcess()
        {
            Application.DoEvents();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "";
                openFileDialog.Title = "Open Public Key File";
                openFileDialog.Filter = "Public Key Document( *.pke )|*.pke";
                string fileString = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        StreamReader streamReader = new StreamReader(openFileDialog.FileName, true);
                        fileString = streamReader.ReadToEnd();
                        streamReader.Close();
                        if (fileString.Length >= txtInput.MaxLength)
                        { MessageBox.Show("ERROR: \nThe file you are trying to open is too big for the text editor to display properly.\nPlease open a smaller document!\nOperation Aborted!"); }
                    }
                }
                if (fileString != null)
                {
                    FinishedProcessDelegate finishedProcessDelegate = new FinishedProcessDelegate(FinishedProcess);
                    UpdateTextDelegate updateTextDelegate = new UpdateTextDelegate(UpdateText);
                    string bitStrengthString = fileString.Substring(0, fileString.IndexOf("</BitStrength>") + 14);
                    fileString = fileString.Replace(bitStrengthString, "");
                    int bitStrength = Convert.ToInt32(bitStrengthString.Replace("<BitStrength>", "").Replace("</BitStrength>", ""));

                    if (fileString != null)
                    {
                        try
                        {
                            EncryptionThread encryptionThread = new EncryptionThread();
                            Thread encryptThread = new Thread(encryptionThread.Encrypt);
                            encryptThread.IsBackground = true;
                            encryptThread.Start(new Object[] { this, finishedProcessDelegate, updateTextDelegate, txtInput.Text, bitStrength, fileString });
                        }
                        catch (CryptographicException CEx)
                        { MessageBox.Show("ERROR: \nOne of the following has occured.\nThe cryptographic service provider cannot be acquired.\nThe length of the text being encrypted is greater than the maximum allowed length.\nThe OAEP padding is not supported on this computer.\n" + "Exact error: " + CEx.Message); }
                        catch (Exception Ex)
                        { MessageBox.Show("ERROR: \n" + Ex.Message); }
                    }
                }
            }
            else
            { MessageBox.Show("ERROR: You Can Not Encrypt A NULL Value!!!"); }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "";
                openFileDialog.Title = "Open Private Key File";
                openFileDialog.Filter = "Private Key Document( *.kez )|*.kez";
                string fileString = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        StreamReader streamReader = new StreamReader(openFileDialog.FileName, true);
                        fileString = streamReader.ReadToEnd();
                        streamReader.Close();
                        if (fileString.Length >= txtInput.MaxLength)
                        { MessageBox.Show("ERROR: \nThe file you are trying to open is too big for the text editor to display properly.\nPlease open a smaller document!\nOperation Aborted!"); }
                    }
                }
                if (File.Exists(openFileDialog.FileName))
                {
                    string bitStrengthString = fileString.Substring(0, fileString.IndexOf("</BitStrength>") + 14);
                    fileString = fileString.Replace(bitStrengthString, "");
                    int bitStrength = Convert.ToInt32(bitStrengthString.Replace("<BitStrength>", "").Replace("</BitStrength>", ""));
                    string tempStorage = txtInput.Text;
                    if (fileString != null)
                    {
                        FinishedProcessDelegate finishedProcessDelegate = new FinishedProcessDelegate(FinishedProcess);
                        UpdateTextDelegate updateTextDelegate = new UpdateTextDelegate(UpdateText);
                        try
                        {
                            EncryptionThread decryptionThread = new EncryptionThread();
                            Thread decryptThread = new Thread(decryptionThread.Decrypt);
                            decryptThread.IsBackground = true;
                            decryptThread.Start(new Object[] { this, finishedProcessDelegate, updateTextDelegate, txtInput.Text, bitStrength, fileString });
                        }
                        catch (CryptographicException CEx)
                        { MessageBox.Show("ERROR: \nOne of the following has occured.\nThe cryptographic service provider cannot be acquired.\nThe length of the text being encrypted is greater than the maximum allowed length.\nThe OAEP padding is not supported on this computer.\n" + "Exact error: " + CEx.Message); }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("ERROR:\n" + Ex.Message);
                        }
                    }
                }
            }
            else
            { MessageBox.Show("ERROR: You Can Not Decrypt A NULL Value!!!"); }
        }
    }
}
