using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationAndLogin
{
    public partial class Starting : Form
    {
        Button picture, mathquiz, matchinggame;
        public Starting()
        {
            this.Name = "Pildivaatur";
            this.Size = new Size(400, 400);

            picture = new Button
            {
                Text = "Pildivaatur",
                Location = new Point(140, 150),
                Size = new Size(100, 50),
                BackColor = Color.LightBlue
            };
            picture.Click += Picture_Click;
            mathquiz = new Button
            {
                Text = "Matemaatika viktoriin ",
                Location = new System.Drawing.Point(140, 210),
                Size = new Size(100, 50),
                BackColor = Color.LightBlue
            };
            mathquiz.Click += Mathquiz_Click;
            matchinggame = new Button
            {
                Text = "Soobitamise mäng ",
                Location = new System.Drawing.Point(140, 270),
                Size = new Size(100, 50),
                BackColor = Color.LightBlue
            };
            matchinggame.Click += Mathchinggame_Click;
            this.Controls.Add(picture);
            this.Controls.Add(mathquiz);
            this.Controls.Add(matchinggame);
        }
        //sasad
        private void Mathquiz_Click(object sender, EventArgs e)
        {
            Mathematicquiz  math = new Mathematicquiz();
            math.StartPosition = FormStartPosition.CenterScreen;
            math.Show();

        }
        private void Mathchinggame_Click(object sender, EventArgs e)
        {
            Matching math = new Matching();
            math.StartPosition = FormStartPosition.CenterScreen;
            math.Show();

        }

        private void Picture_Click(object sender, EventArgs e)
        {
            PictureView pictureviewer = new PictureView();
            pictureviewer.StartPosition = FormStartPosition.CenterScreen;
            pictureviewer.Show();

        }
    }
}
