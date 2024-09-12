using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Algoritmos
{
    public partial class Creator : Form
    {
        List<int> arregloInicial = new List<int>();
        int numAdd = -1;
        public Creator()
        {
            InitializeComponent();
        }

        private void boxAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Visible = true;
            numericBox.Visible = true;
            switch (boxAlgoritmo.SelectedIndex)
            {
                case -1:
                    btnAgregar.Visible = false;
                    numericBox.Visible = false;
                    break;
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            addNumber();
        }

        private void numericBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar == 13)
            {
                addNumber();
            }
        }

        private void addNumber()
        {
            numericBox.ResetText();
            numAdd = ((int)numericBox.Value);
            listInicial.Columns.Add(("" + numAdd), 40);
            arregloInicial.Add(numAdd);
            listInicial.Visible = true;
            btnProcesar.Visible = true;
        }

        private void cleanData()
        {
            listInicial.Columns.Clear();
            listInicial.Items.Clear();
            arregloInicial.Clear();
            btnAgregar.Visible = false;
            numericBox.Visible = false;
            listInicial.Visible = false;
            btnProcesar.Visible = false;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //List<int> list = new List<int> {5, 2, 10, 1, 8, 12, 7, 3};
            List<int> list = new List<int> { 2, -1, 23, -4, 2, 5, -2, 0, 5, 1, 5, -5, 8, 5, 3, -2, 1 };
            List<List<int>> listas = new List<List<int>>();
            switch (boxAlgoritmo.SelectedIndex)
            {
                case 0:
                    listas = PRAM.SumaEREW(list);
                    break;
                case 1:
                    listas = PRAM.SumaCREW(list);
                    break;
                case 2:
                    //PRAM.Broadcast(list, 50);
                    listas = PRAM.BusquedaEREW(list, 5);
                    break;
                case 3:
                    var ret = PRAM.BusquedaCRCW(list);
                    listas = ret.Item1;
                    break;
                case 4:
                    PRAM.OrdenamientoCRCW(list);
                    break;
                case 5:
                    PRAM.OrdenamientoEREW(list, 2);
                    break;
            }
            ShowList(listas);
        }

        private void listInicial_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(listInicial.SelectedItems.Count.ToString() + " + " + listInicial.SelectedItems[0]);
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //arregloInicial.Remove(0);
            }
        }

        // Método para mostrar la lista actual en el DataGridView
        public void ShowList(List<List<int>> listas)
        {
            int max = 0;
            Parallel.ForEach(listas, lista =>
            {
                int tamaño = lista.Count;
                if (tamaño > max)
                {
                    max = tamaño;
                }
                //max = lista.Count > max ? lista.Count: max;
            });

            DataGridOut.Rows.Clear();
            DataGridOut.Columns.Clear();
            // Crear una columna para cada elemento
            for (int i = 0; i < max; i++)
            {
                DataGridOut.Columns.Add($"Columna{i}", $"Índice {i}");
                DataGridOut.Columns[i].Width = 50;
            }

            foreach (List<int> lista in listas)
            {
                // Agregar la fila con los elementos de la lista
                var fila = new DataGridViewRow();
                fila.CreateCells(DataGridOut, lista.Select(item => (object)item).ToArray());
                DataGridOut.Rows.Add(fila);
            }
        }
    }
}
