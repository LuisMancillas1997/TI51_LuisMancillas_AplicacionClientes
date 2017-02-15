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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            //Se inicia el form.
            InitializeComponent();  
        }

        MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; database=AplicacionClientes; Uid=root; pwd=root;"); //Cadena de conexion de la base de datos

        DataSet dataset; //Definicion del dataset

        private void button4_Click(object sender, EventArgs e) //Boton para listar
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de seleccionar.
                conexion.Open();
                MySqlCommand seleccionar = new MySqlCommand("select * from clientes", conexion);
                MySqlDataAdapter conn = new MySqlDataAdapter(seleccionar);

                dataset = new DataSet();
                conn.Fill(dataset);

                dataGridView1.DataSource = dataset.Tables[0];
                conexion.Close();
            }

            catch (Exception)
            {
                {
                    MySqlCommand seleccionar1 = new MySqlCommand("select * from clientes", conexion);
                    MySqlDataAdapter conn = new MySqlDataAdapter(seleccionar1);
                    dataset = new DataSet();
                    conn.Fill(dataset);

                    dataGridView1.DataSource = dataset.Tables[0];
                    conexion.Close();
                }
            
            }
        }

        private void button6_Click(object sender, EventArgs e)  //Boton para seleccionar (es necesario primero seleccionar el dato en el DataGridView)
        {
            try 
            {
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)   //Boton de insertar
        {
           

            try
            {   //Se define las cadena nombre y apellido para referencia al TextBox donde se llenara el campo "nombre" y "apellido" del formulario.
                string nombre;
                nombre = textBox1.Text;

                string apellidos;
                apellidos = textBox2.Text;

                //Se necesita  llenar el campo, si no, se publicara nada en el DataGridView.
                if (nombre == "")
                {
                    MessageBox.Show("Debes de llenar el campo 'Nombre");
                 
                }

                //Se necesita  llenar el campo, si no, se publicara nada en el DataGridView.
                else if (apellidos == "")
                    {
                    MessageBox.Show("Debes de llenar el campo 'Apellidos'");
                 
                }

                else
                {

                    //Se conecta a la base de datos de MySQL y se utiliza el comando de insertar.
                    conexion.Open();
                    MySqlCommand añadir = new MySqlCommand("insert into clientes(nombre,apellidos,telefono,correo_electronico,categoriaid) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", conexion);
                    añadir.ExecuteNonQuery();

                    //Se borra los textBox automaticamente despues de hacer la insercion.
                    MessageBox.Show("Ingresado correctamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                
            }
                
            catch (Exception)
               
            {
                
            }

            
        }

        private void button2_Click(object sender, EventArgs e) //Boton para modificar.
        {
            try
            {
                //Se define las cadena nombre y apellido para referencia al TextBox donde se llenara el campo "nombre" y "apellido" del formulario.
                string nombre;
                nombre = textBox1.Text;

                string apellidos;
                apellidos = textBox2.Text;

                //Se necesita  llenar el campo, si no, se publicara nada en el DataGridView.
                if (nombre == "")
                {
                    MessageBox.Show("Debes de llenar el campo 'Nombre");

                }

                //Se necesita  llenar el campo, si no, se publicara nada en el DataGridView.
                else if (apellidos == "")
                {
                    MessageBox.Show("Debes de llenar el campo 'Apellidos'");

                }

                else
                {
                    //Se conecta a la base de datos de MySQL y se utiliza el comando de modificar.
                    conexion.Open();
                    MySqlCommand modificar = new MySqlCommand("update clientes set nombre='" + textBox1.Text + "',apellidos='" + textBox2.Text + "',telefono='" + textBox3.Text + "',correo_electronico='" + textBox4.Text + "',categoriaid='" + textBox5.Text + "' where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conexion);
                    modificar.ExecuteNonQuery();
                    MessageBox.Show("Modificado correctamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    conexion.Close();
                }
            }
            catch (Exception)
            {
               
            }
            
        }

        private void button3_Click(object sender, EventArgs e) //Boton para eliminar.
        {
            try
            {
                //Se conecta a la base de datos de MySQL y se utiliza el comando de eliminar.
                conexion.Open();
                MySqlCommand eliminar= new MySqlCommand("delete from clientes where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(), conexion);
                eliminar.ExecuteNonQuery();
                MessageBox.Show("Eliminado correctamente.");
                conexion.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e) //Boton para ir a form de Categorias.
        {
            Categorias frm = new Categorias();
            frm.Show();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

    
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
 
     
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
