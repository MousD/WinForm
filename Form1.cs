using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisioneuseImage_Etape3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Affiche la boite de dialogue d'ouverture d'un fichier, si l'utilisateur clique OK, chargement de l'image choisie
            // Show the Open File dialog. If the user clicks OK, load the picture that the user chose. 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Effecer l'image
            // Clear the picture.         
            pictureBox1.Image = null; 
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Affiche la boite de dialogue de changement de couleur, si l'utilisateur clique OK, chargement de la couleur choisie       
            // Show the color dialog box. If the user clicks OK, change the pictureBox control's background to the color the user chose.         
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // ferme la fenetre
            // Close the form.        
            this.Close(); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else 
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;   
        }
    }
}
