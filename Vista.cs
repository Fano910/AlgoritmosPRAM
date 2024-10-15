using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

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

        private void BoxAlgoritmo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (BoxAlgoritmo.SelectedIndex >= 0 && CheckBoxIsByDefault.Checked)
            {
                int tamaño = PRAM.GetRand(2, 32);
                CleanData();
                NumericBoxAgregar.Value = 1;
                for (int i = 0; i <= tamaño; i++)
                {
                    Thread.Sleep(70);
                    AddNumber(true);
                };
                NumericBoxAgregar.Value--;
            }
            BtnAgregar.Visible = true;
            NumericBoxAgregar.Visible = true;
            NumericBoxBusqueda.Visible = (BoxAlgoritmo.SelectedIndex == 2);
            NumericBoxAgregar.Focus();
            NumericBoxAgregar.Select(0, NumericBoxAgregar.Value.ToString().Length);
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            AddNumber(false);
            //System.Windows.Forms.TextBox nuevoTextBox = new System.Windows.Forms.TextBox
            //{
            //    Text = "5",
            //    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            //};

            //// Agregar el TextBox al TableLayoutPanel en la primera fila y la nueva columna
            //TableLayoutIn.Controls.Add(nuevoTextBox, TableLayoutIn.ColumnCount - 1, 0);
        }

        private void NumericBoxAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar == 13)
            {
                AddNumber(false);
            }
        }

        private void AddNumber(bool IsIA)
        {
            numAdd = IsIA ? PRAM.GetRand(0, 100) : (int)NumericBoxAgregar.Value;
            NumericBoxAgregar.Value++;
            ListInicial.Columns.Add(("" + numAdd), 40);
            arregloInicial.Add(numAdd);
            ListInicial.Visible = true;
            btnProcesar.Visible = arregloInicial.Count > 1;
            String text = NumericBoxAgregar.Value.ToString();
            NumericBoxAgregar.Select(0, text.Length);
        }

        private void CleanData()
        {
            ListInicial.Columns.Clear();
            ListInicial.Items.Clear();
            arregloInicial.Clear();
            BtnAgregar.Visible = false;
            NumericBoxAgregar.Visible = false;
            ListInicial.Visible = false;
            btnProcesar.Visible = false;
            BtnLimpiar.Visible = false;
            DataGridOut.Rows.Clear();
            DataGridOut.Columns.Clear();
            LblResultado.Text = "Seleccióna un algoritmo.";

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"new Objetivo={string.Join(", ", arregloInicial)} en Índice=NA");
            //List<int> list = new List<int> { 95, 10, 6, 15 };
            //List<int> list = new List<int> { 5, 2, 10, 1, 8, 12, 7, 3, 5 };
            //List<int> list = new List<int> { 2, -1, 23, -4, 2, 5, -2, 0, 5, 1, 5, -5, 8, 5, 3, -2, 1};
            List<List<int>> listas = new List<List<int>>();
            String objetivo = "Objetivo no encontrado";
            var retorno = (listas, objetivo);
            switch (BoxAlgoritmo.SelectedIndex)
            {
                case 0:
                    retorno = PRAM.SumaEREW(new List<int>(arregloInicial));
                    break;
                case 1:
                    retorno = PRAM.SumaCREW(new List<int>(arregloInicial));
                    break;
                case 2:
                    retorno = PRAM.BusquedaEREW(new List<int>(arregloInicial), (int)NumericBoxBusqueda.Value);
                    break;
                case 3:
                    retorno = PRAM.BusquedaCRCW(new List<int>(arregloInicial));
                    break;
                case 4:
                    retorno = PRAM.OrdenamientoCRCW(new List<int>(arregloInicial));
                    break;
                case 5:
                    //List<List<int>> arrays = new List<List<int>>();
                    int n = arregloInicial.Count;
                    PRAM.ReStructure(n, arregloInicial, false);
                    //arregloInicial = ret.Item1;
                    //n = ret.Item2;
                    retorno = PRAM.OrdenamientoEREW(new List<int>(arregloInicial), arregloInicial.Count);
                    break;
            }
            listas = retorno.listas;
            objetivo = retorno.objetivo;
            ShowList(listas, objetivo);
            BtnLimpiar.Visible = true;
            LblResultado.Visible = true;
        }

        private void listInicial_MouseClick(object sender, MouseEventArgs e)
        {
            //// Verifica si hay un elemento seleccionado
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    // Elimina el primer elemento seleccionado
            //    listView1.Items.Remove(listView1.SelectedItems[0]);
            //}
            //else
            //{
            MessageBox.Show("Por favor, selecciona un elemento para eliminar.");
            //}

            Console.WriteLine(ListInicial.SelectedItems.Count.ToString() + " + " + ListInicial.SelectedItems[0]);
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //arregloInicial.Remove(0);
            }
        }

        // Método para mostrar la lista actual en el DataGridOut y el objetivo en el campo especificado.
        private void ShowList(List<List<int>> listas, String Objetivo)
        {
            LblResultado.Text = Objetivo;
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private void listInicial_Click(object sender, EventArgs e)
        {
            //// Verifica si hay un elemento seleccionado
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    // Elimina el primer elemento seleccionado
            //    listView1.Items.Remove(listView1.SelectedItems[0]);
            //}
            //else
            //{
            //}

        }

        private void ListInicial_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            MessageBox.Show("Por favor, selecciona un elemento para eliminar.");

        }

        private void ListInicial_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Salio");
            if (ListInicial.SelectedItems.Count > 0)
            {
                ListInicial.Items.Remove(ListInicial.SelectedItems[0]);
            }
        }

        private void BtnMult_Click(object sender, EventArgs e)
        {
            int n = 2; // Tamaño de la matriz (asumiendo n es una potencia de 2)
            int[,] A = {
                { 1, 2},
                { 3, 4}
                };

            int[,] B = {
                { 1, 2},
                { 3, 4}
                };

            int[,] result = PRAM.MatMultCREW(A, B, n);

            PRAM.PrintMatrix(result, "Resultado de la multiplicación de matrices:");
        }

        private void BtnSegundo_Click(object sender, EventArgs e)
        {

        }
    }
}
