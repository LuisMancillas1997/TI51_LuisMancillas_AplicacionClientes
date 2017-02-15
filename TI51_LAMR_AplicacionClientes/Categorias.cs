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

namespace TI51_LAMR_AplicacionClientes

{
    public partial class Categorias : Form
    {
        public Categorias()
        {
            //Se inicia el form.
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; database=AplicacionClientes; Uid=root; pwd=root;"); //Cadena de conexion de la base de datos

        DataSet dataset; //Definicion del dataset

        private void button1_Click(object sender, EventArgs e) //Boton para seleccionar (es necesario primero seleccionar el dato en el DataGridView)
        {
            try
            {
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e) //Boton para listar.
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de seleccionar.
                conexion.Open();
                MySqlCommand seleccionar = new MySqlCommand("select * from categorias", conexion);
                MySqlDataAdapter conn = new MySqlDataAdapter(seleccionar);

                dataset = new DataSet();
                conn.Fill(dataset);

                dataGridView1.DataSource = dataset.Tables[0];
                conexion.Close();
  
            }

            catch (Exception)
            {
                MySqlCommand seleccionar1 = new MySqlCommand("select * from categorias", conexion);
                MySqlDataAdapter conn = new MySqlDataAdapter(seleccionar1);
                dataset = new DataSet();
                conn.Fill(dataset);

                dataGridView1.DataSource = dataset.Tables[0];
                conexion.Close();  
            }
        }

        private void button3_Click(object sender, EventArgs e) //Boton para ir al form de Clientes.
        {
            Clientes frm = new Clientes();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)  //Boton para insertar.
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de insertar.
                conexion.Open();
                MySqlCommand insertar1 = new MySqlCommand("insert into categorias(nombre) values ('" + textBox1.Text + "')", conexion);
                insertar1.ExecuteNonQuery();

                MessageBox.Show("Ingresado correctamente.");
                textBox1.Clear();
                conexion.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error.." + error.Message);
                conexion.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e) //Boton para modificar.
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de modificar.
                conexion.Open();
                MySqlCommand modificar1 = new MySqlCommand("update categorias set nombre='" + textBox1.Text + "' where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conexion);
                modificar1.ExecuteNonQuery();
                MessageBox.Show("Modificado correctamente!");
                textBox1.Clear();
                conexion.Close();
            }
            catch (Exception)
            {
               
            }
            
        }

        private void button6_Click(object sender, EventArgs e) //Boton para eliminar.
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de eliminar.
                conexion.Open();
                MySqlCommand eliminar1 = new MySqlCommand("delete from categorias where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conexion);
                eliminar1.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente.");
                conexion.Close();
                textBox1.Clear();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Categorias_Load(object sender, EventArgs e)
        {

        }
    }
}
