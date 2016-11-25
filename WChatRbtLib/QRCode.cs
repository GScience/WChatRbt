using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WChatRbtLib
{
    public partial class QRCode : Form
    {
        public QRCode(byte[] ImageByte)
        {
            InitializeComponent();

            QRImage.Image = Image.FromStream(new MemoryStream(ImageByte));
            QRImage.Image.Save("1.png");
            QRImage.Refresh();
        }
    }
}
