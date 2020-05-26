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

        

        private void button2_Click(object sender, EventArgs e)
        {
            functions.Functions.Leggi(dipendenti, ref x, file);
            
            tabControl1.Visible = true;
            functions.Functions.aggiornalista(listView1, x, dipendenti);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox8.Text= listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox7.Text=="")
            {
                MessageBox.Show("Trova un dipendente o inserisci un settore valido prima");
                return;
            }
            dipendenti[i].settore = textBox7.Text;
            functions.Functions.aggiornalista(listView1, x, dipendenti);
            functions.Functions.scrivi(dipendenti, x, file);
            textBox7.Text = "";
            textBox8.Text = "";

        }
        
        private void visualizzaDipendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form img = new Form();
            img.Size = new Size(300, 300);
            img.StartPosition = FormStartPosition.CenterScreen;
            PictureBox pb = new PictureBox();
            pb.Size = new Size(300, 300);
            string dipendente = ($"{listView1.SelectedItems[0].SubItems[0].Text}{listView1.SelectedItems[0].SubItems[1].Text}.jpg");
            pb.Image = new Bitmap(dipendente);
            img.Controls.Add(pb);
            img.ShowDialog();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Conferma")
            {
                if (textBox9.Text == "")
                {
                    MessageBox.Show("Inserisci un livello");
                }
                dipendenti[i].livello = int.Parse(textBox9.Text);
                functions.Functions.scrivi(dipendenti, x, file);
                MessageBox.Show("Dipendente aggiunto correttamente");
                functions.Functions.aggiornalista(listView1, x, dipendenti);
            }
            if (button6.Text=="Cambia Livello")
            {
               
                textBox9.Enabled = true;
                textBox9.Text = dipendenti[i].livello.ToString();

                button6.Text = "Conferma";

            }
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            functions.Functions.Leggi(dipendenti, ref x, file);
            functions.Functions.aggiornalista(listView1, x, dipendenti);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        int move = default(int);
        int movX = default(int);
        int movY = default(int);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Currenttab.Text = tabControl1.SelectedTab.Text;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
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
            if (textBox11.Text == "")
            {
                MessageBox.Show("Compila tutti i campi");
                return;
            }
            if (textBox12.Text == "")
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
            dipendete.distanza = decimal.Parse(textBox12.Text);
            dipendete.livello = int.Parse(textBox11.Text);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";



            dipendenti[x] = dipendete;
            x++;

            functions.Functions.scrivi(dipendenti, x, file);
            MessageBox.Show("Dipendente aggiunto correttamente");
            functions.Functions.aggiornalista(listView1, x, dipendenti);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            i = functions.Functions.cerca(dipendenti, textBox8.Text.ToUpper(), x);
            if (i == -1)
            {
                MessageBox.Show("Inserisci un codice fiscale valido");
                return;
            }
            functions.Functions.FiltraLista(listView1, i, dipendenti);
            textBox7.Text = dipendenti[i].settore;
        }

        private void btn_elimina_Click(object sender, EventArgs e)
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

        private void bunifuThinButton_cerca_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            bunifuThinButton22.Enabled = false;
            bunifuThinButton23.Enabled = false;
            textBox9.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";

            if (textBox10.Text == "")
            {
                MessageBox.Show("Inserisci il codice fiscale");
                return;
            }
            i = functions.Functions.cerca(dipendenti, textBox10.Text, x);
            if(i==-1)
            {
                MessageBox.Show("Inserisci un codice fiscale valido");
                return;
            }
            textBox9.Text = dipendenti[i].livello.ToString();
            button6.Enabled = true;
            bunifuThinButton22.Enabled = true;
            bunifuThinButton23.Enabled = true;

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            textBox14.Text = (decimal.Round(dipendenti[i].distanza / 1000) * 50 * 40 / 100).ToString();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox14.Text != "")
            {
                if (dipendenti[i].livello == 5)
                {
                    textBox13.Text = (1792 + int.Parse(textBox14.Text)).ToString();
                }
                if (dipendenti[i].livello == 6)
                {
                    textBox13.Text = (2061 + int.Parse(textBox14.Text)).ToString();
                }
                if (dipendenti[i].livello == 7)
                {
                    textBox13.Text = (2301 + int.Parse(textBox14.Text)).ToString();
                }

            }
            else
            {
                if (dipendenti[i].livello == 5)
                {
                    textBox13.Text = 1792.ToString();
                }
                if (dipendenti[i].livello == 6)
                {
                    textBox13.Text = 2061.ToString();
                }
                if (dipendenti[i].livello == 7)
                {
                    textBox13.Text = 2301.ToString();
                }
            }
        }
    }
}
