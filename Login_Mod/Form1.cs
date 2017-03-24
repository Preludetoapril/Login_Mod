using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace Login_Mod
{
    public partial class Form1 : Form
    {
        MySqlConnection cnx = new MySqlConnection("Server = 10.112.96.109; Uid=root; Password=laidtorest;Database=ventas;Port=3306");
        MySqlCommand cmd = new MySqlCommand();


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            try {
                cmd.CommandText = "select count(*) from usuario where username='" + txtUsuario.Text + "' and password='" + txtPassword.Text + "'";
                int valor = int.Parse(cmd.ExecuteScalar().ToString());
                //se comprara si el valor recibido 
                if (valor == 1) {
                    
                    MessageBox.Show("Bienvenido: "+txtUsuario.Text);
                    MainMenu mmenu = new MainMenu();
                    mmenu.Show();
                    this.Hide();
                    }
                else { MessageBox.Show("Usuario o Password Incorrectos"); }

            }
            catch(Exception ex)
            {
                lblmensaje.Text = "Error siguiente: " + ex;
            }
            cnx.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
