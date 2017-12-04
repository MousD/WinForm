using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string _maConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Domi\demos\ADO_demo1\WindowsFormsApplication1\demo1.mdf;Integrated Security=True";
        SqlConnection SqlConn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Oledb = universel
            //OleDbConnection oldbSqlConn = new OleDbConnection();
            // autres base...ne pas oublier les references...
            //OracleConnection test = new OracleConnection();

            SqlConn.ConnectionString = _maConnectionString;
            SqlConn.Open();

            string leNom = textBox1.Text;

            string reqSQL = "INSERT INTO toto (nom) VALUES ('" + leNom + "')";

            SqlCommand cmd = new SqlCommand(reqSQL, SqlConn);
            // 2. Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();

            SqlConn.Close();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.DataSource = RecupererDonnees();



        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            //List<string> lstRecupTuples =  RecupererDonnees();
            listBox1.Items.Clear();
            listBox1.DataSource = RecupererDonnees();
        }

        private List<string> RecupererDonnees()
        {
            List<string> lstLocale = new List<string>();

            SqlDataReader reader; // Contiendra les données

            try
            {
                SqlConn.ConnectionString = _maConnectionString;
                SqlConn.Open();

                //==================

                // Requête SQL
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = SqlConn; // Connexion instanciée auparavant
                selectCommand.CommandText = "SELECT * FROM toto";
                reader = selectCommand.ExecuteReader(); // Exécution de la requête SQL

                while (reader.Read())
                {
                   //string s =  reader[]
                    // Affichage des données
                   lstLocale.Add (reader["Id"] + " " + reader["nom"]);
                   // lstLocale.Add(reader["nom"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Affiche des erreurs
                MessageBox.Show(ex.Message,"Probleme",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                SqlConn.Close();
            }

            //==================

            return lstLocale;
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            string itemSelection = listBox1.Text;
            // ou listBox1.SelectedItem.ToString();

            string id = TrouveMoiId(itemSelection);

            SqlConn.ConnectionString = _maConnectionString;
            SqlConn.Open();          

            string reqSQL = "DELETE FROM toto WHERE Id =" + id;
            //string reqSQL = "DELETE FROM toto WHERE nom = 'toto'";

            SqlCommand cmd = new SqlCommand(reqSQL, SqlConn);
            
            int result = cmd.ExecuteNonQuery();
            if (result != 1)
                MessageBox.Show("Pas glop");

            SqlConn.Close();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.DataSource = RecupererDonnees();
        }

        private string TrouveMoiId(string p_itemSelection)
        {
            string id = "";

            id = p_itemSelection.Split(' ')[0];

            return id;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            frmModifTuple o = new frmModifTuple();
            o.ShowDialog();

            MessageBox.Show(o.Text_modif);

            string itemSelection = listBox1.Text;
            string id = TrouveMoiId(itemSelection);

            SqlConn.ConnectionString = _maConnectionString;
            SqlConn.Open();

            string reqSQL = "UPDATE toto SET nom = '" + o.Text_modif + "'WHERE id =" + id;
            
            //string reqSQL = "DELETE FROM toto WHERE nom = 'toto'";

            SqlCommand cmd = new SqlCommand(reqSQL, SqlConn);

            int result = cmd.ExecuteNonQuery();
            if (result != 1)
                MessageBox.Show("Pas glop");

            SqlConn.Close();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.DataSource = RecupererDonnees();


        }


    }
}
