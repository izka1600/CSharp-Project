using Domowe_Wydatki.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domowe_Wydatki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoWithComboBoxAutor();
            DoWithComboBoxKategoria();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Visible = false;
            label6.Visible = false;
            btnPokaz.Visible = false;
        }

        int IDAutora;
        int IDKategorii;
        int IDPodkategorii;
        string kwota;
        DateTime data;
        int DTPMonth;
        int DTPYear;


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Autor autor = new Autor();
            autor.Id = Convert.ToInt32(((ComboboxItem)comboBox1.SelectedItem).Value);
            IDAutora = autor.Id;
            autor.Imie = ((ComboboxItem)comboBox1.SelectedItem).Text.ToString();
        }

        public void DoWithComboBoxAutor()
        {
            try
            {
                AutorzyModel rezult = new AutorzyModel();
                List<List<string>> wynik = rezult.PodajWszystkichAutorow();
                for (int i = 0; i < wynik.Count(); i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = wynik[i][0];
                    item.Text = wynik[i][1];
                    comboBox1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with loading ComboBox Autor");
            }
        }

        public void DoWithComboBoxKategoria()
        {
            try
            {
                KategorieModel rezult = new KategorieModel();
                List<List<string>> wynik = rezult.PodajWszystkieKategorie();
                for (int i = 0; i < wynik.Count(); i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = wynik[i][0];
                    item.Text = wynik[i][1];
                    comboBox2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with loading ComboBox Kategoria");
            }
        }

        public void DoWithComboBoxPodkategoria()
        {
            try
            {
                comboBox3.Items.Clear();
                PodkategorieModel rezult = new PodkategorieModel();
                List<List<string>> wynik = rezult.PodajWszystkiePodkategorie(IDKategorii);
                for (int i = 0; i < wynik.Count(); i++)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = wynik[i][0];
                    item.Text = wynik[i][2];
                    comboBox3.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with loading ComboBox Podkategoria");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategorie kategoria = new Kategorie();
            kategoria.Id = Convert.ToInt32(((ComboboxItem)comboBox2.SelectedItem).Value);
            IDKategorii = kategoria.Id;
            kategoria.Kategoria = ((ComboboxItem)comboBox2.SelectedItem).Text.ToString();
            DoWithComboBoxPodkategoria();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Podkategorie podkategoria = new Podkategorie();
            podkategoria.Id = Convert.ToInt32(((ComboboxItem)comboBox3.SelectedItem).Value);
            IDPodkategorii = podkategoria.Id;
            podkategoria.Podkategoria = ((ComboboxItem)comboBox3.SelectedItem).Value.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kwota = textBox1.Text;
            kwota = kwota.Replace(",", ".");
        }

        public void btnDodaj_Click(object sender, EventArgs e)
        {
            if (data > DateTime.Parse("2018-01-01"))
            {
                if (IDAutora == 0 || IDKategorii == 0 || IDPodkategorii == 0 || kwota == "0")
                {
                    MessageBox.Show("Niepoprawnie wprowadzone dane");
                    return;
                }
                else
                {
                    ZestawienieModel zestawienie = new ZestawienieModel();
                    zestawienie.Wstaw(data, IDAutora, IDKategorii, IDPodkategorii, kwota);
                    WyswietlTabelke wyswietl = new WyswietlTabelke();
                    wyswietl.Wyswietl(dataGridView1);
                }
            }
            else
            {
                MessageBox.Show("Niepoprawnie wprowadzone dane");
                return;
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker1.Value;
        }


        private void btnUsun_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                var confirmResult = MessageBox.Show("Na pewno chcesz to usunąć ?",
                                     "Usuwanie wiersza",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int i = 0;
                    string[] value = new string[5];
                    foreach (DataGridViewCell cell in item.Cells)
                    {
                        value[i] = cell.Value.ToString();
                        i++;
                    }
                    UsunWiersz usunwiersz = new UsunWiersz();
                    usunwiersz.Usun(value[0], value[4]);
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
                else
                {
                    break;
                }
            }
            
        }

        private void FillChartTest(int month, int year)
        {
            Arkusz_WydatkiEntities db = new Arkusz_WydatkiEntities();

            var ZestawienieIza = db.Zestawienie.Where(a => a.IdAutora == 1 && a.Data.Value.Year==year && a.Data.Value.Month == month).OrderByDescending(a=>a.Data);

            foreach (var item in ZestawienieIza)
            {
                chart1.Series["Iza"].Points.AddXY(item.Data, item.Kwota);
            }

            var ZestawieniePiotr = db.Zestawienie.Where(a => a.IdAutora == 2).OrderByDescending(a => a.Data); ;

            foreach (var item in ZestawieniePiotr)
            {
                chart1.Series["Piotr"].Points.AddXY(item.Data, item.Kwota);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex==1)
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                FillChartTest(month,year);
                btnUsun.Visible = false;
                dateTimePicker2.Visible = true;
                dateTimePicker2_ValueChanged(null, null);
                label6.Visible = true;
                btnPokaz.Visible = true;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                btnUsun.Enabled = true;
                dateTimePicker2.Visible = false;
                label6.Visible = false;
                btnPokaz.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WyswietlTabelke wyswietl = new WyswietlTabelke();
            wyswietl.Wyswietl(dataGridView1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/yyyy";
            dateTimePicker2.ShowUpDown = true;
            DTPMonth = dateTimePicker2.Value.Month;
            DTPYear = dateTimePicker2.Value.Year;
        }

        private void btnPokaz_Click(object sender, EventArgs e)
        {
            FillChartTest(DTPMonth, DTPYear);
        }
    }
}
