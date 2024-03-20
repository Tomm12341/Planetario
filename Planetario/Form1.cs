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
        // Creiamo un nuovo planetario in cui possiamo inserire i pianeti
        Planetario Sistema = new Planetario();

        // Metodo per convertire le coordinate che inseriamo nella text box (coordinate cartesiane) in coordinate adatte al form che ha il centro in alto a sinista
        
        private Vettore Coordinate(Vettore c)
        {
            const int limite_X = 10000000;
            const int limite_Y = 10000000;

            float xc = this.ClientSize.Width / 2;
            float yc = this.ClientSize.Height / 2;

            float xf = (float)(((xc + c.X) / limite_X) * this.ClientSize.Width / 2);
            float yf = (float)(-((yc + c.Y) / limite_Y) * this.ClientSize.Height / 2);

            return new Vettore(xf, yf);
        }
       

        Color[] colore_pianeta = { Color.Beige, Color.Cyan, Color.Green, Color.Magenta, Color.Red, Color.Yellow, Color.Purple, Color.Pink, Color.Orange };


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

        // Metodo per disegnare un pianeta 
        
        private void Disegna(Pianeta p, Color colore_pianeta)
        {
            Graphics g = this.CreateGraphics();
            Vettore corForm = Coordinate(p.Spostamento);
            float x = (float)((corForm.X));
            float y = (float)((corForm.Y));
            g.FillEllipse(new SolidBrush(colore_pianeta), x, y, (float)p.Raggio, (float)p.Raggio);
        }

        

        private bool[] PianetiInseriti;
        public Form1()
        {
            InitializeComponent();
            // Crea un array di booleani e imposta la sua lunghezza uguale al numero di elementi che ci sono nell'enum dei nomi dei pianeti
            PianetiInseriti = new bool[Enum.GetValues(typeof(NomiPianeti)).Length];
            Sistema.Pianeti = new List<Pianeta>();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pianeta pianeta = new Pianeta();

            if (!Vettore.TryParse(txtspos.Text, out Vettore spos) || !Vettore.TryParse(txtvelo.Text, out Vettore veloci) || !double.TryParse(txtmassa.Text, out double massa) || !double.TryParse(txtRaggio.Text, out double Raggio))
            {
                MessageBox.Show("Dati non validi");
            }
            else
            {

                spos = pianeta.Spostamento;

                veloci = pianeta.Velocita;

                massa = pianeta.Massa;

                Raggio = pianeta.Raggio;


                // Ottiengo un pianeta casuale non ancora inserito
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

                // Imposto il nome del pianeta come "inserito"
                PianetiInseriti[(int)elementoCasuale] = true;

                txtspos.Clear();
                txtvelo.Clear();
                txtmassa.Clear();
                txtRaggio.Clear();

                // Aggiungo i pianeti al planetario
                Sistema.Pianeti.Add(pianeta);

            }
        }

        // Questo metodo mi permette di capire se un pianeta è già stato inserito
        private bool PianetiGiaInseriti()
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
            this.Controls.Remove(txtRaggio);

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
    

