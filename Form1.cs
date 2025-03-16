using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data; // IMPORTA A CONEXAO COM O BANCO DE DADOS
using MySql.Data.MySqlClient; //// IMPORTA A CONEXAO COM O BANCO DE DADOS (tem que colocar esses 2 sempre para conectar com o banco de dados

namespace agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string MysqlClientString = "Server = localhost; Port=3306;" + "User Id = root; Database =bdagenda; SSL Mode= 0"; //Indica o caminho para o banco de dados que a gente quer usar

        private void btncarregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MysqlClientString);
            conn.Open();
            DataTable dt = new DataTable(); //Cria o local para os registros
            MySqlDataAdapter da = new MySqlDataAdapter // É o mecanismo que vai pegando registro por registro e colocar no dentro do dt (dataTable)
            ("SELECT * from tbalunos", conn); // Vai carregar o da, o da (DataApter executa essa linha
            da.Fill(dt); //Pega os registros e coloca no datatable
            dataGridView1.DataSource = dt; //Exibe tudo que está no DataTable ir dataGridView
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;  //Muda o tamanho da coluna dentro do dataGridView
            dataGridView1.Columns[3].Width = 300;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            // Insere os dados nos campos de texto
            string sql = "insert into tbalunos(ID,nome,classe,email) " +
           "values('" + txtid.Text + "', '" + txtnome.Text + "','" + cboclasse.Text + "','" + txtemail.Text + "')";
            MySqlConnection conn = new MySqlConnection(MysqlClientString); // Cria a conexao
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(); //Cria uma variavel para executar comandos SQL
            cmd.Connection = conn;
            cmd.CommandText = sql; // Faz a conexao com com o banco de dados
            cmd.ExecuteNonQuery(); // Ele executa o cmd
            MessageBox.Show("Gravado com sucesso");
            btncarregar_Click(sender, e); // Ele vai executar a ação do button1 no click do button 2 tambem
            txtid.Clear();
            txtnome.Clear();
            txtemail.Clear();
            cboclasse.Text = "";
            // Esses 4 limpam a caixa de texto
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            try //Para Caso o usuario digite um ID que não existe ele vai dar um aviso
            {
                MySqlConnection conn = new MySqlConnection(MysqlClientString);
                conn.Open();
                DataTable dt = new DataTable(); 
                MySqlDataAdapter da = new MySqlDataAdapter 
                ("SELECT * from tbalunos where id = '" +txtid.Text+"'", conn); // where para ele pegar só do ID
                da.Fill(dt);
                txtnome.Text = dt.Rows[0].Field<string>("nome"); 
                txtemail.Text = dt.Rows[0].Field<string>("email"); // Irá mostrar nas caixas de texto após o usario escolher o ID.
                cboclasse.Text = dt.Rows[0].Field<string>("classe"); // Não irá mostrar no datagridview
                dataGridView1.DataSource = dt;
            }
            catch // Para Caso o usuario digite um ID que não existe ele vai dar um aviso
            {
                MessageBox.Show("Aluno não cadastrado","Alerta",
                MessageBoxButtons.OK,MessageBoxIcon.Information); // Deixa a caixa de alerta mais bonita.
            }
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            string sql = "update tbalunos set nome = '" + txtnome.Text + "', classe = '" + cboclasse.Text + "', email = '" + txtemail.Text + "' where id = '"+txtid.Text+"'"; // Altera os dados pelas caixas de texto
            MySqlConnection conn = new MySqlConnection(MysqlClientString); 
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(); 
            cmd.Connection = conn;
            cmd.CommandText = sql; 
            cmd.ExecuteNonQuery(); 
            MessageBox.Show("Alterado com sucesso");
            btncarregar_Click(sender, e); 
            txtid.Clear();
            txtnome.Clear();
            txtemail.Clear();
            cboclasse.Text = "";
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
