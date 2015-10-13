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

namespace MySQLManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection Connector = new MySqlConnection();

        MySqlCommand Command;

        string ConnectionString;

        private BindingSource bindingSource = new BindingSource();
        // Connection to MySQL
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectionString = "Server = localhost; Uid = " + LoginTextBox.Text + "; password = " + PassTextBox.Text;

            Connector.ConnectionString = ConnectionString;

            commandRichTextBox.Text += ConnectionString + "\n";

            try
            {
                Connector.Open();
                statusRichTextBox.Text = "Enteres to MySQL\n";
                statusRichTextBox.AppendText("Current user: " + LoginTextBox.Text);
            }
            catch (Exception ex)
            {
                statusRichTextBox.Text = "Error: Can't connect to MySQL";
                commandRichTextBox.Text = "";
                LoginTextBox.Text = "";
                PassTextBox.Text = "";
            }
        }
        //Disconnection from MySQL
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Connector.Close();
            commandRichTextBox.Text = "";
            statusRichTextBox.Text = "Quit:  Bye!";
            enterRichTextBox.Text = "";
            dataGridView1.Columns.Clear();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            Command = Connector.CreateCommand();
            Command.CommandText = enterRichTextBox.Text;
            commandRichTextBox.AppendText(Command.CommandText + "\n");

            try
            {
                Command.ExecuteNonQuery();
                statusRichTextBox.Text = "OK";
            }
            catch (Exception ex)
            {
                statusRichTextBox.Text = "Error";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command = Connector.CreateCommand();
            Command.CommandText = "create database " + textBox1.Text + ";";
            commandRichTextBox.AppendText(Command.CommandText + "\n");

            try
            {
                Command.ExecuteNonQuery();
                statusRichTextBox.Text = "New database created";
            }
            catch (Exception ex)
            {
                statusRichTextBox.Text = "Error, can't create database";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Command = Connector.CreateCommand();
            Command.CommandText = "grant " + textBox4.Text + " to " + textBox2.Text + "@localhost identified by " + "'" + textBox3.Text + "';";
            commandRichTextBox.AppendText(Command.CommandText + "\n");

            try
            {
                Command.ExecuteNonQuery();
                statusRichTextBox.Text = "New user created";
            }
            catch(Exception ex)
            {
                statusRichTextBox.Text = "Error, can't create new user";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Command = Connector.CreateCommand();
            Command.CommandText = "drop database " + textBox5.Text + ";";
            commandRichTextBox.AppendText(Command.CommandText + "\n");

            try
            {
                Command.ExecuteNonQuery();
                statusRichTextBox.Text = "Database is deleted";
            }
            catch (Exception ex)
            {
                statusRichTextBox.Text = "Error, can't delete database";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Command = Connector.CreateCommand();
            Command.CommandText = "create table " + textBox6.Text + "." + textBox7.Text+ " (" + textBox8.Text+ ");";
            commandRichTextBox.AppendText(Command.CommandText + "\n");

            try
            {
                Command.ExecuteNonQuery();
                statusRichTextBox.Text = "Table is created";
            }
            catch (Exception ex)
            {
                statusRichTextBox.Text = "Error, can't create table";
            }

        }
    }
}
