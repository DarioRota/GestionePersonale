﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace functions
{
    public struct dipendete
    {
        public string nome;
        public string cognome;
        public string codicefiscale;
        public string email;
        public string indirizzo;
        public string settore;
    }
    public class Functions
    {
        public static int Leggi(dipendete[] eledip, ref int num, string nomefile)
        {
            dipendete nuovodipendente = default(dipendete);
            int dipendentiletti = default(int);
            StreamReader miofile;
            miofile = new StreamReader(nomefile);
            while (miofile.EndOfStream == false) ;
            {
                nuovodipendente.nome = miofile.ReadLine();
                nuovodipendente.cognome = miofile.ReadLine();
                nuovodipendente.codicefiscale = miofile.ReadLine();
                nuovodipendente.email = miofile.ReadLine();
                nuovodipendente.indirizzo = miofile.ReadLine();
                nuovodipendente.settore = miofile.ReadLine();
                eledip[num] = nuovodipendente;
                num++;
                dipendentiletti++;
            }
            miofile.Close();
            return dipendentiletti;

        }
        public static void aggiornalista(ListView lista, int num, dipendete[] eledip)
        {
            lista.Items.Clear();
            int x = 0;
            while (x < num)
            {
                var row = new string[] { eledip[x].nome,eledip[x].cognome,eledip[x].codicefiscale,eledip[x].email,
                eledip[x].indirizzo,eledip[x].settore};
                var listrow = new ListViewItem(row);
                lista.Items.Add(listrow);
                x++;
            }
        }
        public static int elimina(dipendete[] eledip, ref int num, string codice)
        {
            int npe = default(int);
            for (int x = 0; x < num; x++)
            {
                if (string.Compare(eledip[x].codicefiscale, codice) == 0)
                {
                    eledip[x] = eledip[num - 1];
                    num--;
                    npe++;
                }
            }
            return npe;

        }
        public static int cerca(dipendete[] eledip, string codice, int num)
        {
            int indice = default(int);
            for (int x = 0; x < num; x++)
            {
                if (string.Compare(eledip[x].codicefiscale, codice) == 0)
                {
                    indice = x;
                }
            }
            return indice;
        }
        public static void ordinacrescente(dipendete[] eledip, int num)
        {
            int x = 0;
            int y = 0;
            dipendete temp = default(dipendete);
            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (string.Compare(eledip[x].cognome, eledip[y].cognome) > 0)
                    {
                        temp = eledip[x];
                        eledip[x] = eledip[y];
                        eledip[y] = temp;
                    }
                    y++;
                }
                x++;
            }
        }
        public static void ordinadecrescente(dipendete[] eledip, int num)
        {
            int x = 0;
            int y = 0;
            dipendete temp = default(dipendete);
            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (string.Compare(eledip[x].cognome, eledip[y].cognome) < 0)
                    {
                        temp = eledip[x];
                        eledip[x] = eledip[y];
                        eledip[y] = temp;
                    }
                    y++;
                }
                x++;
            }
        }
        public static void scrivi(dipendete[] eledip, int num, string pathfile)
        {
            StreamWriter miofile;
            miofile = new StreamWriter(pathfile);
            for (int x = 0; x < num; x++)
            {
                miofile.WriteLine(eledip[x].nome);
                miofile.WriteLine(eledip[x].cognome);
                miofile.WriteLine(eledip[x].codicefiscale);
                miofile.WriteLine(eledip[x].email);
                miofile.WriteLine(eledip[x].indirizzo);
                miofile.WriteLine(eledip[x].settore);
            }
            miofile.Close();
        }
    }
}