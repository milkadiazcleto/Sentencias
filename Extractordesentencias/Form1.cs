using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Extractordesentencias
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            radioButton1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path1 = textBox1.Text;
            var allFiles = Directory.GetFiles(path1, "*.txt", SearchOption.AllDirectories);

            foreach (var t in allFiles)
            {
                string x;
                string nombre;
                x = File.ReadAllText(Convert.ToString(t));
                nombre = Path.GetFileNameWithoutExtension(t);

                string[] archivo;


                if (radioButton1.Checked)
                {
                    archivo = x.Split(';');

                    for (int y = 0; y < archivo.Length; y++)
                    {

                        char[] letras = archivo[y].ToCharArray();

                        for (int g = 0; g < letras.Length; g++)
                        {
                            string linea;
                            linea = "";
                            if (letras[g] == 'I' && letras[g] != null && letras[g + 1] == 'N' && letras[g + 1] != null && letras[g + 2] == 'S' && letras[g + 2] != null)
                            {
                                for (int i = g; i < letras.Length - 1; i++)
                                {
                                    linea = string.Concat(linea, letras[i]);

                                }

                            }
                            if (linea != "")
                            {
                                if (textBox3.Text != "" && linea.Substring(12, textBox3.Text.Length + 1) == String.Concat(textBox3.Text, " "))
                                {
                                    textBox2.Text = String.Concat(textBox2.Text, linea, "\r\n", "\r\n");
                                }
                            }

                        }
                    }
                    tabPage2.Show();

                }
                else
                {
                    if (radioButton2.Checked)
                    {
                        archivo = x.Split('.');

                        for (int y = 0; y < archivo.Length; y++)
                        {

                            char[] letras = archivo[y].ToCharArray();

                            for (int g = 0; g < letras.Length; g++)
                            {
                                string linea;
                                linea = "";
                                if (letras[g] == 'U' && letras[g] != null && letras[g + 1] == 'P' && letras[g + 1] != null && letras[g + 2] == 'D' && letras[g + 2] != null)
                                {
                                    for (int i = g; i < letras.Length; i++)
                                    {
                                        linea = string.Concat(linea, letras[i]);

                                    }

                                }
                                if (linea != "")
                                {
                                    if (textBox3.Text != "" && linea.Substring(12, textBox3.Text.Length + 1) == String.Concat(textBox3.Text, " "))
                                    {
                                        textBox2.Text = String.Concat(textBox2.Text, linea, "\r\n", "\r\n");
                                    }
                                    else
                                    {
                                        textBox2.Text = String.Concat(textBox2.Text, linea, "\r\n", "\r\n");
                                    }
                                }

                            }
                        }
                        tabPage2.Show();

                    }
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StreamWriter nuevo;
            if (textBox3.Text != "")
            {
                nuevo = new StreamWriter("Sentencias" + textBox3.Text + ".txt");
            }
            else
            {
                nuevo = new StreamWriter("Sentencias" + ".txt");
            }
            nuevo.Write(textBox2.Text);
            nuevo.WriteLine();
            nuevo.Close();
            MessageBox.Show("El archivo se almaceno correctamente", "Mensaje");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
