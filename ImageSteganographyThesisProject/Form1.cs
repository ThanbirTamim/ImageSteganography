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

namespace ImageSteganographyThesisProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowseCoverImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Browse PNG File";
                openFileDialog.Filter = "Image file (*.png)|*.png";
                openFileDialog.Multiselect = false;
                string fileWav = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileWav = openFileDialog.FileName;
                }
                if (String.IsNullOrEmpty(fileWav))
                    throw new Exception("Please select a png file....");
                txtFileName.Text = fileWav;

                if (File.Exists(txtFileName.Text.Trim()))
                {
                    Bitmap bitmap = new Bitmap(txtFileName.Text.Trim());
                    pictureBox1.Image = bitmap;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (radioAlgo1.Checked == true)
                    {
                        label1.Text = "Max Letter: " + Math.Round((((bitmap.Width * bitmap.Width) - 4) * 3) / 16.0f).ToString();
                    }
                    else if (radioAlgo2.Checked == true)
                    {
                        if (bitmap.Width <= 256)
                        {
                            label1.Text = "Max Letter: " + 381.ToString();

                        }
                        else if (bitmap.Width <= 512)
                        {
                            label1.Text = "Max Letter: " + 765.ToString();
                        }
                    }
                    else if (radioAlgo3.Checked == true)
                    {
                        label1.Text = "Max Letter: " + (Math.Round((((bitmap.Width * bitmap.Width) - 4) * 3) / 8.0f) - 3).ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSecretMessage_TextChanged(object sender, EventArgs e)
        {
            lblTxtCount.Text = "Letter Count: " + txtSecretMessage.Text.Trim().Length;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            //1st 6 pixel is used to hide metadata
            //Rest of pixel is used to hide secret data bit
            string secret_meaage = txtSecretMessage.Text.Trim();
            if (String.IsNullOrEmpty(secret_meaage))
                throw new Exception("Please write some text to hide!");

            if (DialogResult.Yes == MessageBox.Show("Do you want to hide message into selected cover image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //here we are going to save our stago file
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Title = "Where you going to save your stego image file?",
                    Filter = "Image file (*.png)|*.png",
                    FileName = "Stego.png"
                };

                string stegoFileAddress = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    stegoFileAddress = saveFileDialog.FileName;
                }

                if (String.IsNullOrEmpty(stegoFileAddress))
                    throw new Exception("Save file is not be empty. Try again later!");

                string status = "Failed";



                if (radioAlgo1.Checked == true)
                {
                    //param <message, stego_file, cover_file>
                    status = ProposedAlgorithm.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                    //param <cover_file, stego_file>
                    CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                }
                else if (radioAlgo2.Checked == true)
                {
                    status = _8DirBasedAlgorithm.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                    //param <cover_file, stego_file>
                    CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                }
                else if (radioAlgo3.Checked == true)
                {
                    status = XORBasedTechnique.HideMessage(secret_meaage, stegoFileAddress, txtFileName.Text.Trim());
                    //param <cover_file, stego_file>
                    CheckMeaturementMetrix(txtFileName.Text.Trim(), stegoFileAddress);//now target is to check Meaturement metrics like PSNR, MSE
                }


                if (status.Contains("Success"))
                {
                    Bitmap bitmap = new Bitmap(stegoFileAddress);
                    pictureBox2.Image = bitmap;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                MessageBox.Show(status);
            }

        }

        private void CheckMeaturementMetrix(string v, string stegoFileAddress)
        {
            try
            {
                if (radioAlgo1.Checked == true)
                {
                    string validation = ProposedAlgorithm.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgo2.Checked == true)
                {
                    string validation = _8DirBasedAlgorithm.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
                else if (radioAlgo3.Checked == true)
                {
                    string validation = XORBasedTechnique.CheckValidation(v, stegoFileAddress);
                    txtMeaturement.Text = validation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to extract message from selected stego png image?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string secretMessage = "Failed to extract!!!";

                    if (radioAlgo1.Checked == true)
                    {
                        secretMessage = ProposedAlgorithm.ExtractSecretMessage(txtFileName.Text.Trim());
                    }
                    else if (radioAlgo2.Checked == true)
                    {
                        secretMessage = _8DirBasedAlgorithm.ExtractSecretMessage(txtFileName.Text.Trim());
                    }
                    else if (radioAlgo3.Checked == true)
                    {
                        secretMessage = XORBasedTechnique.ExtractSecretMessage(txtFileName.Text.Trim());
                    }

                    txtSecretMessage.Text = secretMessage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
