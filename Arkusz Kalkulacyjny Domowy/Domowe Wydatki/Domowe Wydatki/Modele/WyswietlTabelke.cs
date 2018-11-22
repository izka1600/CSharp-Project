using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domowe_Wydatki.Modele
{
    class WyswietlTabelke
    {
        public void Wyswietl(DataGridView data)
        {
            WyswietlZestawienie wyswietlzestawienie = new WyswietlZestawienie();
            BindingSource bsource = wyswietlzestawienie.Wyswietl();
            data.DataSource = bsource;
            data.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
            data.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
