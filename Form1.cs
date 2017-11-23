using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionnaireMaths
{
    public partial class Form1 : Form
    {
        // Création d'un objet pour la generation d'un nouveau nombre aléatoire
        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend; // diminuende en français.
        int subtrahend; // dimininuteur en français.
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

         public void StartTheQuiz()
         { 
             //Addition
             // Génération de 2 nb aléatoire à ajouter pour l'addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
             // Convertion des 2 nombres générer en "String" pour être afficher
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
             // Valeur par defaut
            sum.Value = 0;


             //Soustraction
            // Génération de 2 nb aléatoire à soustraire pour la soustraction
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            // Convertion des 2 nombres générer en "String" pour être afficher
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            // Valeur par defaut
            difference.Value = 0;


             //Multiplication
            // Génération de 2 nb aléatoire 
            multiplicand = randomizer.Next(2,11);
            multiplier = randomizer.Next(2,11);
            // Convertion des 2 nombres générer en "String" pour être afficher
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
           // Valeur par defaut
            product.Value = 0;


            //Multiplication
            // Génération de 2 nb aléatoire
            divisor = randomizer.Next(2,11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = randomizer.Next(2,11);
            // Convertion des 2 nombres générer en "String" pour être afficher
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            // Valeur par defaut
            quotient.Value = 0;


            timeLeft = 30;
            timeLabel1.Text = "30 Seconds";
            timer1.Start();
          }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer ())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel1.Text = timeLeft + " Seconds";
                if (timeLeft <= 5)
                {
                    timeLabel1.BackColor = Color.Red;
                }
            }          
            else
            {
                timeLabel1.BackColor = DefaultBackColor;
                timer1.Stop();
                timeLabel1.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time." , "Sorry!");

                //Resultat des calculs
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;


                // Remise à Zero
                timeLabel1.Text = "Let's Go!";
                
                //sum.Value = 0;
                //difference.Value = 0;
                //product.Value = 0;
                //quotient.Value = 0;

                startButton.Enabled = true;

            }
        }
        
        private bool CheckTheAnswer()
        {
            if ( (addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
