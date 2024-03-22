using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Planetario
{
    public partial class Form1 : Form
    {
        // Creiamo un nuovo planetario in cui possiamo inserire i pianeti
        Planetario Sistema = new Planetario();

        // Metodo per convertire le coordinate che inseriamo nella text box (coordinate cartesiane) in coordinate adatte al form che ha il centro in alto a sinista
        /*
        private Vettore Coordinate(Vettore c)
        {
            const int limite_X = 10000000;
            const int limite_Y = 10000000;

            float xc = this.ClientSize.Width / 2;
            float yc = this.ClientSize.Height / 2;

            float xf = (float)(((xc + c.X) / limite_X) * (this.ClientSize.Width / 2));
            float yf = (float)(-((yc + c.Y) / limite_Y) * (this.ClientSize.Height / 2));

            return new Vettore(xf, yf);
        }
       */

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
        
        private void Disegna(Pianeta p)
        {
            
            Graphics g = this.CreateGraphics();

            /*
            Vettore corForm = Coordinate(p.Spostamento);
            */
            float x = (float)((p.Spostamento.X));
            float y = (float)((p.Spostamento.Y));
            g.FillEllipse(new SolidBrush(p.colore), x, y, (float)RaggioPianeta(p.Massa), (float)RaggioPianeta(p.Massa));
        }

        private double RaggioPianeta(double massa)
        {
            double raggio = (Math.Pow(massa, 0.33333)) * 5.51;
            return raggio;
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
            pianeta.Accelerazione = new Vettore(0, 0);
            pianeta.Forza = new Vettore(0, 0);
            Random rand = new Random();
            pianeta.colore = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));


            if (!Vettore.TryParse(txtspos.Text, out Vettore spos) || !Vettore.TryParse(txtvelo.Text, out Vettore veloci) || !double.TryParse(txtmassa.Text, out double massa))
            {
                MessageBox.Show("Dati non validi");
            }
            else
            {

                pianeta.Spostamento = spos;

                pianeta.Velocita = veloci;

                pianeta.Massa = massa;

            }



                // Ottiengo un pianeta casuale non ancora inserito
                NomiPianeti elementoCasuale;
                do
                {
                    elementoCasuale = (NomiPianeti)new Random().Next(0, PianetiInseriti.Length);
                } while (PianetiInseriti[(int)elementoCasuale]);

                string spostamento = txtspos.Text.ToString();
                string velocita = txtvelo.Text.ToString();
                string mas = txtmassa.Text.ToString();

             

                // Imposto il nome del pianeta come "inserito"
                PianetiInseriti[(int)elementoCasuale] = true;

                txtspos.Clear();
                txtvelo.Clear();
                txtmassa.Clear();
                

                // Aggiungo i pianeti al planetario
                lstPianeti.Items.Add($"{elementoCasuale} - Spostamento: {spostamento}, Velocità: {velocita}, Massa: {mas}");
                Sistema.Pianeti.Add(pianeta);

          

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
            int i = lstPianeti.SelectedIndex;
            Sistema.Pianeti.RemoveAt(i);
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
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);
            
           for(int i=0; i<300; i++)
            {
                Sistema.MuoviPianeti();
               
            }
            
            

            foreach (Pianeta p in Sistema.Pianeti)
            {
                Disegna(p);
            } 

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }
        private void Form1_Sizechanged(object sender, EventArgs e)
        {
            
        }
    }
}
    

