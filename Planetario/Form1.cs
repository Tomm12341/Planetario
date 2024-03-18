using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planetario
{
    public partial class Form1 : Form
    {
        enum NomiPianeti
        {
            Aztlinte,
            Porar,
            Feldesa,
            Staphao,
            Avypau,
            Sarunt,
            Mumsaras,
            Rorolon,
            Tanophsi,
            Chrinolia,
            Posn,
            Aerkinu

        }
        private bool[] PianetiInseriti;
        public Form1()
        {
            InitializeComponent();
            PianetiInseriti = new bool[Enum.GetValues(typeof(NomiPianeti)).Length];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pianeta pianeta = new Pianeta();

            if (!Vettore.TryParse(txtspos.Text, out Vettore spos) || !Vettore.TryParse(txtvelo.Text, out Vettore veloci) || !double.TryParse(txtmassa.Text, out double massa))
            {
                MessageBox.Show("Spostamento non valido");
            }
            else
            {
                spos = pianeta.Spostamento;

                veloci = pianeta.Velocita;

                massa = pianeta.Massa;

            // Ottiengo un elemento casuale non ancora inserito
            NomiPianeti elementoCasuale;
            do
            {
                elementoCasuale = (NomiPianeti)new Random().Next(0, PianetiInseriti.Length);
            } while (PianetiInseriti[(int)elementoCasuale]);

            string spostamento = txtspos.Text.ToString();
            string velocita = txtvelo.Text.ToString();
            string mas = txtmassa.Text.ToString();

            // Aggiungo l'elemento alla ListBox
            lstPianeti.Items.Add($"{elementoCasuale} - Spostamento: {spostamento}, Velocità: {velocita}, Massa: {mas}");

            // Imposto il valore dell'elemento come "inserito"
            PianetiInseriti[(int)elementoCasuale] = true;

            txtspos.Clear();
            txtvelo.Clear();
            txtmassa.Clear();

        }
        }
        private bool TuttiGiaInseriti()
        {
            foreach (bool inserito in PianetiInseriti)
            {
                if (!inserito)
                    return false;
            }
            return true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstPianeti.Items.Remove(lstPianeti.SelectedItem);
        }
    }
    }

