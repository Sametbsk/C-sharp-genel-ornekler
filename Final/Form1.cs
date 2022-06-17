using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Final
{
    public partial class Form1 : Form
    {
        int vize, final, büt, sayı, toplam, büyük, küçük, ram, dram, salise, saniye, dakika, saat;
        double not, ortalama,çevre,alan,r;
        double pi = 3.14159;


        SqlConnection bağlantı;
        SqlDataAdapter da;
        SqlCommand komut;

        public Form1()
        {
            InitializeComponent();
        }
        

        Random random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Height = random.Next(150);
            panel2.Height = random.Next(150);
            panel3.Height = random.Next(150);
            panel4.Height = random.Next(150);
            panel5.Height = random.Next(150);
            panel6.Height = random.Next(150);
            panel7.Height = random.Next(150);
            panel8.Height = random.Next(150);
            panel9.Height = random.Next(150);
            panel10.Height = random.Next(150);
        }
        //////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            label20.Text = DateTime.Now.ToString();
            griddoldur();
            comboBox1.Items.Add("GTR R34");
            comboBox1.Items.Add("SUPRA");
            comboBox1.Items.Add("488 GTB");
            comboBox1.Items.Add("LFA");
            comboBox1.Items.Add("GİULİA");
            comboBox1.Items.Add("GT63");
            comboBox1.Items.Add("911");
            comboBox1.Items.Add("M4");
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {}
         private void label6_Click(object sender, EventArgs e)
        {}

        //////////////////////////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)                                                                  //kronometre
        {
            timer2.Start();
        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            salise++;
            if (salise == 100)
            {
                salise = 0;
                saniye++;
            }

            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }

            if (dakika == 60)
            {
                dakika = 0;
                saat++;
            }

            label8.Text = salise.ToString();
            label7.Text = saniye.ToString();
            label6.Text = dakika.ToString();
            label5.Text = saat.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(saat + ":" + dakika + ":" + saniye + "." + salise);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            salise = 0;
            saniye = 0;
            dakika = 0;
            saat = 0;
            label8.Text = salise.ToString();
            label7.Text = saniye.ToString();
            label6.Text = dakika.ToString();
            label5.Text = saat.ToString();
            listBox1.Items.Clear();
        }
        //////////////////////////////////////////////////////////////////////////////////////

        private void button4_Click(object sender, EventArgs e)                                                                  //equlaizer barları
        {
            if (timer1.Enabled==true)
                timer1.Stop();
            else
                timer1.Start();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button5_Click(object sender, EventArgs e)                                                                   //zar atma
        {
            timer3.Start();
            button5.Enabled = false;
        }
        int sayac = 0;

        private void timer3_Tick(object sender, EventArgs e)
        {
            int zar1, zar2;
            Random rnd = new Random();
            zar1 = rnd.Next(0, 6);
            zar2 = rnd.Next(0, 6);
            pictureBox1.Image = ımageList1.Images[zar1];
            pictureBox2.Image = ımageList1.Images[zar2];
            sayac++;
            if (sayac == 30)
            {
                timer3.Stop();
                sayac = 0;
                button5.Enabled = true;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button6_Click(object sender, EventArgs e)                                                                  //listbox arası veri aktarma
        {
            if (listBox2.SelectedIndex !=-1)
            {
                listBox3.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapın.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapın.");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button8_Click(object sender, EventArgs e)                                                                  //rgb arkaplan
        {
            if (timer4.Enabled == true)
                timer4.Stop();
            else
                timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int R, G, B;
            Random rnd = new Random();
            R = rnd.Next(0, 255);
            G = rnd.Next(0, 255);
            B = rnd.Next(0, 255);
            BackColor = Color.FromArgb(R, G, B);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BackColor = Color.Empty;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button10_Click(object sender, EventArgs e)
        {                                                                                                                        //kayan yazı
            if (label9.Visible == true)
                label9.Visible = false; 
            else
                label9.Visible = true;


            if (label9.Visible == true)
                timer5.Start();
            if (label9.Visible == false)
                timer5.Stop();
            label9.Left = 810;

        }
        
        private void timer5_Tick(object sender, EventArgs e)
        {
            label9.Left -= 1;
            if (label9.Left < -760)
                label9.Left = 800;
        }
        //////////////////////////////////////////////////////////////////////////////////////

        string[] dosyalar = Directory.GetFiles(@"C:\Users\samet\Desktop\fotolar", "*.png");
        private void button11_Click(object sender, EventArgs e)                                                                 //random fotoğraf
        {
            Random rnd = new Random();
            pictureBox3.ImageLocation = dosyalar[rnd.Next(0, dosyalar.Length)];
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button20_Click(object sender, EventArgs e)
        {                                                                                                                      //çember alan çevre
            r = Convert.ToDouble(textBox6.Text);
            çevre = 2 * pi * r;
            alan = pi * r * r;
            label21.Text = "Çevre: "+çevre.ToString();
            label23.Text = "Alan: "+alan.ToString();
        }

        //////////////////////////////////////////////////////////////////////////////////////


        private void button12_Click(object sender, EventArgs e)
        {                                                                                                                       //vize final
            
            vize = Convert.ToInt32(textBox1.Text);
            final = Convert.ToInt32(textBox2.Text);
            not = vize * 0.4 + final * 0.6;
            if (not > 60)
                label12.Text = "Geçtin";
            else
            {
                label12.Text = "Bütünleme notu girin";
                label13.Visible = true;
                textBox3.Visible = true;
                button13.Visible = true;
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            büt = Convert.ToInt32(textBox3.Text);
            not = vize * 0.4 + büt * 0.6;
            if (not > 60)
                label12.Text = "Geçtin";
            else
                label12.Text = "Kaldın";
        }
        //////////////////////////////////////////////////////////////////////////////////////

       
        private void button14_Click(object sender, EventArgs e)
        {                                                                                                                        //random sayı ekleme ve ortalama vb.


            Random say = new Random();
            for (int i = 0; i < 20; i++)
            {
                sayı = say.Next(0, 1000);
                listBox4.Items.Add(sayı);
                toplam += sayı;
            }
            ortalama = toplam / 20;
            label14.Text = "Ortalama: " + ortalama.ToString();

            ram = Convert.ToInt32(listBox4.Items[0]);
            for (int i = 0; i < 20; i++)
            {
                if (ram < Convert.ToInt32(listBox4.Items[i]))
                {
                    büyük = Convert.ToInt32(listBox4.Items[i]);
                    ram = büyük;
                }

                label15.Text = "En büyük: " + büyük.ToString();

            }

            dram = Convert.ToInt32(listBox4.Items[0]);
            for (int i = 0; i < 20; i++)
            {
                if (dram > Convert.ToInt32(listBox4.Items[i]))
                {
                    küçük = Convert.ToInt32(listBox4.Items[i]);
                    dram = küçük;
                }

                label16.Text = "En küçük: " + küçük.ToString();
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            ortalama = 0;
            toplam = 0;
            label14.Text = "Ortalama: ";
            label15.Text = "En büyük sayı: ";
            label16.Text = "En küçük sayı: ";

        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();                                                                             //open file dialog
            a.ShowDialog();
            pictureBox1.ImageLocation = a.FileName;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            listBox5.Items.Clear();

            if (comboBox1.SelectedIndex == 0) 
            {                                                                                                                    //combobox ile veri listeleme
                listBox5.Items.Add("2.6Lt I6 280hp-392Nm");
                listBox5.Items.Add("4WD 6 vites Turbo");
                listBox5.Items.Add("1999 Japonya");
                listBox5.Items.Add("0-100 5.4sn");

            }
            else if (comboBox1.SelectedIndex == 1) 
            {
                listBox5.Items.Add("3.0Lt I6 280hp-432Nm");
                listBox5.Items.Add("RWD 6 vites Turbo");
                listBox5.Items.Add("1993 Japonya");
                listBox5.Items.Add("0-100 5.1sn");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                listBox5.Items.Add("3.9Lt V8 670hp-760Nm");
                listBox5.Items.Add("RWD 7 DCT Turbo");
                listBox5.Items.Add("2015 İtalya");
                listBox5.Items.Add("0-100 3.0sn");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                listBox5.Items.Add("4.8Lt V10 560hp-480Nm");
                listBox5.Items.Add("RWD 6 vites N/A");
                listBox5.Items.Add("2010 Japonya");
                listBox5.Items.Add("0-100 3.7sn");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                listBox5.Items.Add("2.9Lt V6 510hp-600Nm");
                listBox5.Items.Add("RWD 8 vites Turbo");
                listBox5.Items.Add("2019 İtalya");
                listBox5.Items.Add("0-100 3.9sn");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                listBox5.Items.Add("4.0Lt V8 843hp-1400Nm");
                listBox5.Items.Add("AWD 9 MCT Turbo");
                listBox5.Items.Add("2021 Almanya");
                listBox5.Items.Add("0-100 2.9sn");
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                listBox5.Items.Add("4.0Lt B6 510hp-470Nm");
                listBox5.Items.Add("RWD 7 PDK N/A");
                listBox5.Items.Add("2021 Almanya");
                listBox5.Items.Add("0-100 3.4sn");
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                listBox5.Items.Add("3.0Lt I6 510hp-650Nm");
                listBox5.Items.Add("AWD 8 ZF Turbo");
                listBox5.Items.Add("2021 Almanya");
                listBox5.Items.Add("0-100 3.7sn");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void button17_Click(object sender, EventArgs e)
        {
            double sayı1, sayı2,sonuç;
            sayı1 = Convert.ToDouble(textBox4.Text);
            sayı2 = Convert.ToDouble(textBox5.Text);
            if (radioButton1.Checked)
            {
                sonuç = sayı1 + sayı2;
                label19.Text = "Sonuç: "+sonuç.ToString();
            }
            if (radioButton2.Checked)
            {                                                                                                                    //hesap makinesi
                sonuç = sayı1 - sayı2;
                label19.Text ="Sonuç: "+ sonuç.ToString();
            }
            if (radioButton3.Checked)
            {
                sonuç = sayı1 / sayı2;
                label19.Text ="Sonuç: "+ sonuç.ToString();
            }
            if (radioButton4.Checked)
            {
                sonuç = sayı1 * sayı2;
                label19.Text = "Sonuç: "+sonuç.ToString();
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        void griddoldur()
        {
            bağlantı = new SqlConnection("server=ACER;Initial Catalog=C# bağlantısı;Integrated Security=SSPI");
            bağlantı.Open();
            da = new SqlDataAdapter("SELECT *FROM Not_defteri", bağlantı);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bağlantı.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {                                                                                                                        //sql not defteri
            string sorgu = "INSERT INTO Not_defteri(notlar) VALUES (@notlar)";
            komut = new SqlCommand(sorgu, bağlantı);
            komut.Parameters.AddWithValue("@Notlar", richTextBox1.Text);
            bağlantı.Open();
            komut.ExecuteNonQuery();
            bağlantı.Close();
            griddoldur();
        }
        

        private void button19_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Not_defteri WHERE Notlar=@Notlar";
            komut = new SqlCommand(sorgu, bağlantı);
            komut.Parameters.AddWithValue("@Notlar", richTextBox1.Text);
            bağlantı.Open();
            komut.ExecuteNonQuery();
            bağlantı.Close();
            griddoldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void timer6_Tick(object sender, EventArgs e)
        {                                                                                                                        //tarih
            label20.Text = DateTime.Now.ToString();
        }
        //////////////////////////////////////////////////////////////////////////////////////

    }
}
