using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSteganographyThesisProject
{
    public static class _8DirBasedAlgorithm
    {
        public static string messageBinary = "";
        public static char[] messageLengthBinaryChar;
        public static char[] secretMesssgaeBinary;
        public static StringBuilder secretMessageBitLeft = new StringBuilder();
        public static StringBuilder secretMessageBitRight = new StringBuilder();
        public static StringBuilder totalSecretMessageBit = new StringBuilder();

        public static string HideMessage(string message, string stego_file_name, string cover_file_name)
        {
            try
            {
                messageLengthBinaryChar = messageLengthBinaryFormat(message.Length);
                secretMesssgaeBinary = messageBinaryFormat(message);
                int bitno = 0;

                Bitmap img = new Bitmap(cover_file_name);
                int messageBinaryLength = 0, allPixel = 0, perLine = 0, extraPixel = 0, messageLength = 0;
                if (img.Width <= 256)
                {
                    messageBinaryLength = secretMesssgaeBinary.Length;
                    allPixel = messageBinaryLength / (3);
                    perLine = Convert.ToInt32(messageBinaryLength / (3 * 8));
                    extraPixel = allPixel - (perLine * 8) - 1;
                    messageLength = message.Length;
                }
                if (img.Width <= 512)
                {
                    messageBinaryLength = secretMesssgaeBinary.Length;
                    allPixel = messageBinaryLength / (3);
                    perLine = Convert.ToInt32(messageBinaryLength / (3 * 8));
                    extraPixel = allPixel - (perLine * 8) - 1;
                    messageLength = message.Length;
                }

                img.SetPixel((img.Width) / 2, (img.Height) / 2, embed_data_pixel_rgba(img, Convert.ToInt32((img.Width) / 2), Convert.ToInt32((img.Height) / 2), bitno, 0));

                bitno += 3;

                //now we are going to insert the
                for (int i = 1; i <= perLine; i++) //this loop for up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2);
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++) //this loop for right-up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++) //this loop for right-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2);
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++) //this loop for right-down-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++) //this loop for down-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2);
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++) //this loop for left - down - direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine; i++)//this loop for left-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2);
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }
                for (int i = 1; i <= perLine + extraPixel; i++) //this loop for left-up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    img.SetPixel(x, y, embed_data_pixel_rgba(img, x, y, bitno, 0));
                    bitno = bitno + 3; //this bitno will help me to know the tract of message character index
                }


                //===================================
                //here we are hiding message length
                //int messageLength = message.Length;
                string messageLengthBinary = Convert.ToString(messageLength, 2).PadLeft(12, '0'); ;
                messageLengthBinaryChar = messageLengthBinary.ToCharArray();

                //for 1st pixel (x1,y1) = {((w/2)-2),1}
                int x1 = Convert.ToInt32((((img.Width) / 2) - 2));
                int y1 = Convert.ToInt32(1);
                img.SetPixel(x1, y1, embed_data_pixel_rgba(img, x1, y1, 0, 1));

                //for 2nd pixel 
                int x2 = Convert.ToInt32(img.Width - 1);
                int y2 = Convert.ToInt32((img.Height / 2) - 2);
                img.SetPixel(x2, y2, embed_data_pixel_rgba(img, x2, y2, 3, 1));

                //for 3rd pixel 
                int x3 = Convert.ToInt32((img.Width / 2) + 2);
                int y3 = Convert.ToInt32(img.Height - 1);
                img.SetPixel(x3, y3, embed_data_pixel_rgba(img, x3, y3, 6, 1));

                //for 3rd pixel 
                int x4 = Convert.ToInt32(1);
                int y4 = Convert.ToInt32((img.Height / 2) + 2);
                img.SetPixel(x4, y4, embed_data_pixel_rgba(img, x4, y4, 9, 1));

                img.Save(stego_file_name, ImageFormat.Png);

                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
        }
        private static Color embed_data_pixel_rgba(Bitmap imag, int x1, int y1, int smbp, int data) //param (image, dimension-x, dimension-y, tracking_index, data_of_messagelength_or_messagebit_or_framelength)
        {
            Color pixel = imag.GetPixel(x1, y1);
            string red = Convert.ToString(pixel.R, 2).PadLeft(8, '0');
            string green = Convert.ToString(pixel.G, 2).PadLeft(8, '0');
            string blue = Convert.ToString(pixel.B, 2).PadLeft(8, '0');

            int newred = 0, newgreen = 0, newblue = 0;
            if (data == 0)//data == 0 means store embedding secret mesage bit
            {
                //here we are replacing the secrect message bit into the last position in red and converted to integer
                newred = Convert.ToInt32((new StringBuilder(red) { [7] = secretMesssgaeBinary[smbp + 0] }.ToString()), 2);
                newgreen = Convert.ToInt32((new StringBuilder(green) { [7] = secretMesssgaeBinary[smbp + 1] }.ToString()), 2);
                newblue = Convert.ToInt32((new StringBuilder(blue) { [7] = secretMesssgaeBinary[smbp + 2] }.ToString()), 2);
            }
            else if (data == 1) //data == 1 means store embedding secret mesage length
            {
                //here we are replacing the secrect message bit into the last position in red and converted to integer
                newred = Convert.ToInt32((new StringBuilder(red) { [7] = messageLengthBinaryChar[smbp + 0] }.ToString()), 2);
                newgreen = Convert.ToInt32((new StringBuilder(green) { [7] = messageLengthBinaryChar[smbp + 1] }.ToString()), 2);
                newblue = Convert.ToInt32((new StringBuilder(blue) { [7] = messageLengthBinaryChar[smbp + 2] }.ToString()), 2);
            }

            Color myRgbColor = new System.Drawing.Color();
            myRgbColor = Color.FromArgb(pixel.A, newred, newgreen, newblue);
            return myRgbColor;
        }
        public static string ExtractSecretMessage(string stego_file_name)
        {
            try
            {
                string frameNoBinary = "";
                string secretMessage = "";


                Bitmap coverimage = new Bitmap(stego_file_name);
                int frameN = 0;
                int onlyOne = 0;

                for (int x = 0; x < 1; x++)
                {
                    for (int y = 0; y < coverimage.Height; y++)
                    {
                        if (x == 0 && y < 10)
                        {
                            string s = secretBitMetaData(coverimage, x, y);
                            frameNoBinary += s;
                        }
                        else
                        {
                            if (onlyOne == 0)
                            {
                                //here we got the frame no from the 4 pixel of that 000001.bmp
                                frameN = Convert.ToInt32(frameNoBinary, 2);
                                //lengthOfMsgBit = 0;
                                //if (((frameN * 8) % 3) == 2)
                                //{
                                //    lengthOfMsgBit += 1;
                                //}
                                //else if (((frameN * 8) % 3) == 1)
                                //{
                                //    lengthOfMsgBit += 2;
                                //}

                                //lengthOfMsgBit += frameN;
                                onlyOne = 1;
                            }


                            if (secretMessage.Length <= (frameN * 8))
                            {
                                string s = secretBitMetaData(coverimage, x, y);
                                secretMessage += s;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }



                Bitmap img = new Bitmap(stego_file_name);

                string messageLengthBinary = "";
                //now our target is to get scret message size
                //==========================================
                //for 1st pixel (x1,y1) = {((w/2)-2),1}
                int x1 = Convert.ToInt32((((img.Width) / 2) - 2));
                int y1 = Convert.ToInt32(1);
                messageLengthBinary += readPixelData(img, x1, y1);

                //for 2nd pixel 
                int x2 = Convert.ToInt32(img.Width - 1);
                int y2 = Convert.ToInt32((img.Height / 2) - 2);
                messageLengthBinary += readPixelData(img, x2, y2);

                //for 3rd pixel 
                int x3 = Convert.ToInt32((img.Width / 2) + 2);
                int y3 = Convert.ToInt32(img.Height - 1);
                messageLengthBinary += readPixelData(img, x3, y3);

                //for 3rd pixel 
                int x4 = Convert.ToInt32(1);
                int y4 = Convert.ToInt32((img.Height / 2) + 2);
                messageLengthBinary += readPixelData(img, x4, y4);

                //here we got the secret message length from the 4 pixel of that selected frames.bmp
                int messageLength = Convert.ToInt32(messageLengthBinary, 2) * 8;

                messageLengthBinary = "";

                //here we have find out the total pixels number and per direction's pixel numbers
                //to maintain error from pass length we have to add (extra 0 or 00)
                if ((messageLength % 3) == 2)
                {
                    messageLength += 1;
                }
                else if ((messageLength % 3) == 1)
                {
                    messageLength += 2;
                }

                int messageBinaryLength = messageLength;
                int allPixel = messageBinaryLength / (3);
                int perLine = Convert.ToInt32(messageBinaryLength / (3 * 8));
                int extraPixel = allPixel - (perLine * 8) - 1;


                secretMessage += readPixelData(img, Convert.ToInt32((img.Width) / 2), Convert.ToInt32((img.Height) / 2));

                for (int i = 1; i <= perLine; i++) //this loop for up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2);
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    secretMessage += readPixelData(img, x, y);

                }
                for (int i = 1; i <= perLine; i++) //this loop for right-up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine; i++) //this loop for right-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2);
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine; i++) //this loop for right-down-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) + i;
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine; i++) //this loop for down-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2);
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine; i++) //this loop for left - down - direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2) + i;
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine; i++)//this loop for left-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2);
                    secretMessage += readPixelData(img, x, y);
                }
                for (int i = 1; i <= perLine + extraPixel; i++) //this loop for left-up-direction embedding
                {
                    int x = Convert.ToInt32((img.Width) / 2) - i;
                    int y = Convert.ToInt32((img.Height) / 2) - i;
                    secretMessage += readPixelData(img, x, y);
                }



                //secretMessage = string.Concat(secretMessage.Reverse().Skip(substract).Reverse());
                char[] secretMessageBinary = secretMessage.ToCharArray();
                string bit8 = "";
                int aa = 0;
                string secretRealMessage = "";

                //Console.WriteLine(secretMessage);
                for (int i = 0; i < secretMessageBinary.Length; i++)
                {
                    if (aa != 8)
                    {
                        bit8 = bit8 + secretMessageBinary[i].ToString();

                        aa++;
                    }
                    if (aa == 8)
                    {
                        int acii = Convert.ToInt32(bit8, 2);
                        secretRealMessage = secretRealMessage + Char.ConvertFromUtf32(acii);
                        bit8 = "";
                        aa = 0;
                    }
                }
                return secretRealMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Failed : " + ex.Message;
            }
        }
        private static string readPixelData(Bitmap img, int x, int y)
        {
            System.Drawing.Color pixel = img.GetPixel(x, y);
            string red = Convert.ToString(pixel.R, 2).PadLeft(8, '0');
            string green = Convert.ToString(pixel.G, 2).PadLeft(8, '0');
            string blue = Convert.ToString(pixel.B, 2).PadLeft(8, '0');
            string data = red.Last().ToString() + green.Last().ToString() + blue.Last().ToString();
            return data;
        }
        private static string secretBitMetaData(Bitmap img, int x, int y)
        {
            Color pixel = img.GetPixel(x, y);
            string red = Convert.ToString(pixel.R, 2).PadLeft(8, '0');
            string green = Convert.ToString(pixel.G, 2).PadLeft(8, '0');
            string blue = Convert.ToString(pixel.B, 2).PadLeft(8, '0');
            string s = (red.Last().ToString() + green.Last().ToString() + blue.Last().ToString());
            return s;
        }
        public static char[] messageBinaryFormat(string message)
        {
            /*
            * Here we are creating messages bit to binary form
            */
            //message is converted to 8bit binary
            StringBuilder sb = new StringBuilder();
            foreach (char c in message.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            messageBinary = sb.ToString();

            //to maintain error from pass length we have to add (extra 0 or 00)
            if (((messageBinary.Length) % 3) == 2)
            {
                messageBinary += "0";
            }
            else if (((messageBinary.Length) % 3) == 1)
            {
                messageBinary += "00";
            }

            return messageBinary.ToCharArray(); //all binary bit has been converted into array.
        }
        public static char[] messageLengthBinaryFormat(int number)
        {
            string binary = Convert.ToString(number, 2).PadLeft(30, '0');
            return binary.ToCharArray();
        }
        public static string CheckValidation(string coverFile, string stegoFile)
        {
            try
            {
                double mseGray = 0.0, mse = 0.0, psnr = 0.0;
                Bitmap bmp1 = new Bitmap(coverFile);
                Bitmap bmp2 = new Bitmap(stegoFile);

                for (int i = 0; i < bmp1.Width; i++)
                {
                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        int gray1 = bmp1.GetPixel(i, j).R;
                        int gray2 = bmp2.GetPixel(i, j).R;
                        double sum = Math.Pow(gray1 - gray2, 2);
                        mseGray += sum;
                    }
                }
                mse = (mseGray) / (bmp1.Width * bmp1.Height) * 3;
                psnr = 10 * Math.Log10((255 * 255) / mse);

                string validation = "MSE : " + mse.ToString() + Environment.NewLine + "PSNR : " + psnr.ToString() + Environment.NewLine;

                return validation;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
