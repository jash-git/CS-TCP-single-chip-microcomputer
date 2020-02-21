using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;// add lib
using System.IO;// add lib
using System.Threading;

namespace V8_command_sample
{
    public partial class Form1 : Form
    {
        //---
        //add public member
        public TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public BinaryReader br;
        public BinaryWriter bw;
        public String StrResult = "";
        //---add public member
        public Form1()
        {
            InitializeComponent();
        }

        private void SendCommand(byte []Command,int iResult)
        {     
            NetworkStream clientStream = clientSocket.GetStream();
            bw = new BinaryWriter(clientStream);
            bw.Write(Command);

            Thread.Sleep(100);
            byte[] inStream = new byte[2000];
            br = new BinaryReader(clientStream);
            int intLen = br.Read(inStream, 0, iResult);
            StrResult = "";
            StrResult = "";
            for (int i = 0; i < intLen; i++)//show hex
            {
                if (i == 0)
                {
                    StrResult += Convert.ToString(inStream[i], 16).ToUpper().PadLeft(2, '0');
                }
                else
                {
                    StrResult += " " + Convert.ToString(inStream[i], 16).ToUpper().PadLeft(2, '0');
                }
            }
        }

        private void ShowResult(String StrButtMsg)
        {
            String[] StrData = StrResult.Split(' ');
            String StrShowMsg = StrResult + "\n\n\n";
            StrShowMsg += String.Format("{0} :STX\n", StrData[0]);
            StrShowMsg += String.Format("{0} {1} :length\n", StrData[1], StrData[2]);
            StrShowMsg += String.Format("{0} {1} {2} {3} :command: 4 bytes\n", StrData[3], StrData[4], StrData[5], StrData[6]);
            StrShowMsg += String.Format("{0} :Num: 1 bytes\n", StrData[7]);
            StrShowMsg += String.Format("{0} {1} {2} {3} :index: 4 bytes\n", StrData[8], StrData[9], StrData[10], StrData[11]);
            StrShowMsg += String.Format("{0} {1} {2} :Reverse: 3 bytes", StrData[12], StrData[13], StrData[14]);
            MessageBox.Show(StrShowMsg, StrButtMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void initUI(bool state=true)
        {
            buttConnect.Enabled = state;
            buttAddCard.Enabled = !state;
            buttDeleteCard.Enabled = !state;
            buttSetTime.Enabled = !state;
            buttGetRecord.Enabled = !state;
            txtrecord.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initUI();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( (clientSocket!=null) && (clientSocket.Connected) )
            {
                clientSocket.Close();
            }
            
        }

        private void buttConnect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect(txtIP.Text, Convert.ToInt32(txtPort.Text));
                if (clientSocket.Connected)
                {
                    initUI(false);
                }
            }
            catch
            {

            }
        }

        private void buttAddCard_Click(object sender, EventArgs e)
        {
            int ishift = 0;
            byte[] card = new byte[8];
            byte[] index = new byte[4];
            byte[] name = new byte[32];
            byte[] bSend = new byte[103];
            byte[] pin = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] validdate = new byte[] { 0x07, 0xD0, 0x01, 0x01, 0x00, 0x00, 0x08, 0x14, 0x01, 0x01, 0x00, 0x00 };
            byte[] parameter = new byte[] { 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] status_week = new byte[] { 0x11, 0xFF };
            byte[] timer = new byte[] { 0x00, 0x00, 0x17, 0x3B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] reverse = new byte[] { 0x00, 0x00 };
            String StrBuf = "";
            byte[] ArraySRC = System.Text.Encoding.ASCII.GetBytes(txtCard.Text);
            Array.Reverse(ArraySRC);
            StrBuf = System.Text.Encoding.ASCII.GetString(ArraySRC);
            for (int i=0;i<8;i++)
            {
                card[i]= Convert.ToByte(Convert.ToInt32(txtCard.Text.Substring(i * 2, 2), 16));
            }

            StrBuf = Convert.ToString(Convert.ToInt32(txtIndex.Text), 16);
            StrBuf = StrBuf.PadLeft(8, '0');
            for (int i = 0; i < 4; i++)
            {

                index[i] = Convert.ToByte(Convert.ToInt32(StrBuf.Substring(i * 2, 2), 16));
            }

            UnicodeEncoding Unicode = new UnicodeEncoding();

            StrBuf = txtName.Text;
            if (StrBuf.Length<16)
            {
                StrBuf = StrBuf.PadRight(16, '\0');
            }
            int byteCount = Unicode.GetByteCount(StrBuf.ToCharArray(), 0, 16);
            int bytesEncodedCount = Unicode.GetBytes(StrBuf, 0, 16, name, 0);
            for(int i=0;i<(32-1);i+=2)
            {
                byte bBuf = name[i];
                name[i] = name[i + 1];
                name[i + 1] = bBuf;
            }

            bSend[0] = 0x05;//STX
            bSend[1] = 0x00;
            bSend[2] = 0x64;//length(100)
            bSend[3] = 0x80;
            bSend[4] = 0x00;
            bSend[5] = 0x80;
            bSend[6] = 0x51;//command:4 bytes
            bSend[7] = 0x01;
            bSend[8] = 0x00;
            bSend[9] = 0x00;
            bSend[10] = 0x00;
            bSend[11] = 0x00;
            bSend[12] = 0x00;
            bSend[13] = 0x00;
            bSend[14] = 0x00;//Num+Mode+Rev:8 bytes

            ishift += 15;
            Array.Copy(index, 0, bSend, ishift, index.Length);//index(0888):4 bytes

            ishift += index.Length;
            Array.Copy(card, 0, bSend, ishift, card.Length);//UID:8 bytes

            ishift += card.Length;
            Array.Copy(pin, 0, bSend, ishift, pin.Length);//PIN:8 bytes

            ishift += pin.Length;
            Array.Copy(validdate, 0, bSend, ishift, validdate.Length);//Valid date:12 bytes

            ishift += validdate.Length;
            Array.Copy(parameter, 0, bSend, ishift, parameter.Length);//parameters:8 bytes

            ishift += parameter.Length;
            Array.Copy(status_week, 0, bSend, ishift, status_week.Length);//status and weekh:2 bytes

            ishift += status_week.Length;
            Array.Copy(timer, 0, bSend, ishift, timer.Length);//timer:12 bytes

            ishift += timer.Length;
            Array.Copy(reverse, 0, bSend, ishift, reverse.Length);//reverse:2 bytes

            ishift += reverse.Length;
            Array.Copy(name, 0, bSend, ishift, name.Length);//name:32 bytes

            //---
            /*
            StrResult = "";
            for (int i = 0; i < bSend.Length; i++)//show hex
            {
                if (i == 0)
                {
                    StrResult += Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
                else
                {
                    StrResult += " " + Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
            }
            MessageBox.Show(StrResult);
            */
            //---

            SendCommand(bSend, 15);

            ShowResult(buttAddCard.Text);
        }

        private void buttDeleteCard_Click(object sender, EventArgs e)
        {
            int ishift = 0;
            byte[] bSend = new byte[15];
            byte[] index = new byte[4];
            byte[] reverse = new byte[] { 0x00, 0x00, 0x00 };
            String StrBuf = "";

            StrBuf = Convert.ToString(Convert.ToInt32(txtIndex.Text), 16);
            StrBuf = StrBuf.PadLeft(8, '0');
            for (int i = 0; i < 4; i++)
            {

                index[i] = Convert.ToByte(Convert.ToInt32(StrBuf.Substring(i * 2, 2), 16));
            }

            bSend[0] = 0x05;//STX
            bSend[1] = 0x00;
            bSend[2] = 0x0C;//length(12)
            bSend[3] = 0x80;
            bSend[4] = 0x00;
            bSend[5] = 0x80;
            bSend[6] = 0x53;//command:4 bytes
            bSend[7] = 0x01;//Num:1 bytes

            ishift += 8;
            Array.Copy(index, 0, bSend, ishift, index.Length);//index(0888):4 bytes

            ishift += index.Length;
            Array.Copy(reverse, 0, bSend, ishift, reverse.Length);//reverse: 3 bytes

            //---
            /*
            StrResult = "";
            for (int i = 0; i < bSend.Length; i++)//show hex
            {
                if (i == 0)
                {
                    StrResult += Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
                else
                {
                    StrResult += " " + Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
            }
            MessageBox.Show(StrResult);
            */
            //---

            SendCommand(bSend, 15);

            ShowResult(buttDeleteCard.Text);
        }

        private void buttSetTime_Click(object sender, EventArgs e)
        {
            int ishift = 0;
            byte[] time = new byte[]{ 0x07, 0xE4, 0x02, 0x15, 0x08, 0x24, 0x22, 0x00 }; //Date and Time
                                                                                        //07 E4: Year(2020)
                                                                                        //02 15 :Date(2 / 15)
                                                                                        //08 24 :Time(08:36)
                                                                                        //22 :Second(42)
                                                                                        //00 :Reverse
            byte[] bSend = new byte[15];

            bSend[0] = 0x05;//STX
            bSend[1] = 0x00;
            bSend[2] = 0x0C;//length(12)
            bSend[3] = 0x80;
            bSend[4] = 0x00;
            bSend[5] = 0x05;
            bSend[6] = 0x01;//command:4 bytes

            ishift += 7;
            Array.Copy(time, 0, bSend, ishift, time.Length);//:Date and Time

            //---
            /*
            StrResult = "";
            for (int i = 0; i < bSend.Length; i++)//show hex
            {
                if (i == 0)
                {
                    StrResult += Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
                else
                {
                    StrResult += " " + Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
            }
            MessageBox.Show(StrResult);
            */
            //---

            SendCommand(bSend, 15);

            MessageBox.Show(StrResult, buttSetTime.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttGetRecord_Click(object sender, EventArgs e)
        {
            int ishift = 0;
            byte[] bSend = new byte[15];
            byte[] reverse = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            bSend[0] = 0x05;//STX
            bSend[1] = 0x00;
            bSend[2] = 0x0C;//length(12)
            bSend[3] = 0x80;
            bSend[4] = 0x00;
            bSend[5] = 0x80;
            bSend[6] = 0x61;//command:4 bytes
            bSend[7] = 0x01;//Read Type(1)
            bSend[8] = 0x01;//Read 1 record

            ishift += 9;
            Array.Copy(reverse, 0, bSend, ishift, reverse.Length);//:Reverse
            
            //---
            /*
            StrResult = "";
            for (int i = 0; i < bSend.Length; i++)//show hex
            {
                if (i == 0)
                {
                    StrResult += Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
                else
                {
                    StrResult += " " + Convert.ToString(bSend[i], 16).ToUpper().PadLeft(2, '0');
                }
            }
            MessageBox.Show(StrResult);
            */
            //---

            SendCommand(bSend, 55);
            txtrecord.Text += StrResult+"\n";
        }
    }
}
