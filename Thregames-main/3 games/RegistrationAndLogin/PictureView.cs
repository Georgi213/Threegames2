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

namespace RegistrationAndLogin
{
    public partial class PictureView : Form
    {
        Random rnd = new Random();
        TextBox textBox1, textBox2;
        public PictureView()
        {
            CenterToScreen(); 
            Text = "Piltide vaatamine";
            ClientSize = new Size(1200, 600);
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel 
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                RowCount = 2,
            };
            
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
          
            pictureBox1 = new PictureBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill,
                TabStop = false,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            tableLayoutPanel.SetColumnSpan(pictureBox1, 2);
            checkBox1 = new CheckBox
            {
                AutoSize = true,
                Text = "Venitada",
                UseVisualStyleBackColor = true,
            };
            checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
            };
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
                Title = "Valige pildifail"
            };
            
            Controls.Add(tableLayoutPanel);
            tableLayoutPanel.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel.Controls.Add(checkBox1, 0, 1);
            tableLayoutPanel.Controls.Add(flowLayoutPanel1, 1, 1);
            string[] textbutton = { "Naita pilti", "Tuhjenda pilt", "Maarake taustavarv", "Sulge", "Juhuslik pilt", "Teie fail kaustas" };
            for (int i = 0; i < textbutton.Length; i++) 
            {
                Button zxc = new Button
                {
                    AutoSize = true,
                    UseVisualStyleBackColor = true,
                    Text = textbutton[i]

                };
                zxc.Click += Tegevus;
                flowLayoutPanel1.Controls.Add(zxc);
            }
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(textBox2);

        }
        private void Tegevus(object sender, EventArgs e)  
        {
           
            string[] files_jpg = Directory.GetFiles(@"..\..\..\randompic", "*.jpg");
            string[] files_png = Directory.GetFiles(@"..\..\..\randompic", "*.png");
          
            List<string> files = new List<string>();
            files.AddRange(files_png);
            files.AddRange(files_jpg);
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Tuhjenda pilt")
            {
                pictureBox1.Image = null;
            }
            else if (nupp_sender.Text == "Sulge")
            {
                Close();
            }
            else if (nupp_sender.Text == "Maarake taustavarv") 
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    pictureBox1.BackColor = colorDialog1.Color;
            }
            else if (nupp_sender.Text == "Naita pilti") 
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                    Bitmap finalImg = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height); 
                    pictureBox1.Image = finalImg;
                    pictureBox1.Show();
                }
            }
            else if (nupp_sender.Text == "Juhuslik pilt")
            {

                pictureBox1.Load(files[rnd.Next(0, files.Count)]);
                Bitmap finalImg = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = finalImg;
                pictureBox1.Show();
            }
            else if (nupp_sender.Text == "Teie fail kaustas") 
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = openFileDialog1.SafeFileName;
                    string destinationFile = @"..\..\..\randompic\" + sourceFile;
                    File.Move(openFileDialog1.FileName, destinationFile);
                }
            }
            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) 
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

    }
}
