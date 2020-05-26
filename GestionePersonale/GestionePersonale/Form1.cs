using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionePersonale;

namespace GestionePersonale
{
    public partial class Form1 : Form
    {
        functions.dipendete[] dipendenti = new functions.dipendete[2000];
        int x = default(int);
        string file = "Archivio";
        int i = default(int);


        public Form1()
        {
        
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }

            functions.dipendete dipendete = default(functions.dipendete);
            dipendete.nome = textBox1.Text;
            dipendete.cognome = textBox2.Text;
            dipendete.codicefiscale = textBox3.Text.ToUpper();
            dipendete.email = textBox4.Text;
            dipendete.indirizzo = textBox5.Text;
            dipendete.settore = textBox6.Text;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";


            dipendenti[x] = dipendete;
            x++;

            functions.Functions.scrivi(dipendenti, x, file);
            MessageBox.Show("Dipendente aggiunto correttamente");
            functions.Functions.aggiornalista(listView1, x, dipendenti);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            functions.Functions.Leggi(dipendenti, ref x, file);
            button2.Visible = false;
            tabControl1.Visible = true;
            functions.Functions.aggiornalista(listView1, x, dipendenti);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = functions.Functions.cerca(dipendenti, textBox8.Text.ToUpper(), x);
            functions.Functions.FiltraLista(listView1, i, dipendenti);
            

        }      

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox8.Text= listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dipendenti[i].settore = textBox7.Text;
            functions.Functions.aggiornalista(listView1, x, dipendenti);
            functions.Functions.scrivi(dipendenti, x, file);
            textBox7.Text = "";
            textBox8.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Metti il codice fiscale");
                return;
            }
            functions.Functions.elimina(dipendenti, ref x, textBox8.Text);
            MessageBox.Show("Persona rimossa correttamente");
            button4.PerformClick();
            textBox7.Text = "";
            textBox8.Text = "";

        }

        private void visualizzaDipendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form img = new Form();
            img.Size = new Size(100, 100);
            img.StartPosition = FormStartPosition.CenterScreen;
            PictureBox pb = new PictureBox();
            pb.Size = new Size(100, 100);
            string dipendente = ($"{listView1.SelectedItems[0].SubItems[0].Text}{listView1.SelectedItems[0].SubItems[1].Text}");
            pb.Load(dipendente);
            img.Controls.Add(pb);
            this.Controls.Add(img);
        }
    }
}
