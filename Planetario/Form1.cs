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
        Planetario Sistema = new Planetario();

        Color[] colore_pianeta = {Color.Beige, Color.Cyan, Color.Green, Color.Magenta, Color.Red, Color.Yellow, Color.Purple, Color.Pink, Color.Orange};
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
        private void Disegna(Graphics g, Pianeta p, Color colore_pianeta)
        {
            float raggio = RaggioPianeta(p.Massa);
            float x = (float)(Pianeta.Spostamento.x);
            float y = (float)(Pianeta.Spostamento.y);
            g.FillEllipse(new SolidBrush(colore_pianeta), x, y, raggio, raggio);
        }
        /* Prendiamo come rifermento la massa, il raggio e la densità della Terra e usiamo 
         la proporzione Mt:Rt=Mp:Rp
         */
        private float RaggioPianeta(double massa)
        {
            float raggio = (float)((6378 * massa) / 5.98e24);
            return raggio;
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
                MessageBox.Show("Dati non validi");
            }
            else
            {  Pianeta p = new Pianeta();

                spos = p.Spostamento;

               veloci = p.Velocita;

                massa = p.Massa;
                
               
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

                Sistema.Pianeti.Add(p);
               
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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.Controls.Remove(txtvelo);
            this.Controls.Remove(txtmassa);
            this.Controls.Remove(txtspos);
            this.Controls.Remove(label1);
            this.Controls.Remove(label2);
            this.Controls.Remove(label3);
            this.Controls.Remove(btnAdd);
            this.Controls.Remove(btnRemove);
            this.Controls.Remove(btnPlay);
            this.Controls.Remove(lstPianeti);
            timer1.Start();

            
        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    }

