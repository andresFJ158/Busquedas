using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Busqueda
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> vectorDinamico = new List<int>();
        private List<int> vectorOrdenado = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Se obtiene el valor del textbox
                int valor = int.Parse(txtValor.Text);
                // se añade el valor a la lista dinamica
                vectorDinamico.Add(valor);
                // se resetea el valor de la list
                lstVectorDinamico.ItemsSource = null;
                // se añade el valor del vectorDinamico a la listaDinamica
                lstVectorDinamico.ItemsSource = vectorDinamico;
                // una vez añadido se limpia el textbox
                txtValor.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un valor entero");
            }
        }

        private void btnBuscarCentinela_Click(object sender, RoutedEventArgs e)
        {
            try { 
                int valorBuscar = int.Parse(txtValor.Text);
                vectorDinamico.Add(valorBuscar);
                int i = 0;
                while (vectorDinamico[i] != valorBuscar)
                {
                    i++;
                }
                if (i < vectorDinamico.Count - 1)
                    MessageBox.Show("El valor de " + valorBuscar + " se encuentra en el indice: " + i.ToString());
                else
                    MessageBox.Show("El valor de " + valorBuscar + " no se encuentra");

                vectorDinamico.RemoveAt(vectorDinamico.Count - 1);
            } catch (FormatException) { 
                MessageBox.Show("Ingresa un valor entero"); 
            }

        }

        private void btnBuscarSinCentinela_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int valorBuscar = int.Parse(txtValor.Text);
            int i = 0;
            while ( i < vectorDinamico.Count && vectorDinamico[i]!=valorBuscar)
            {
                i++;
            }
            if (i < vectorDinamico.Count)
                MessageBox.Show("El valor de "+valorBuscar+" se encuentra en el indice: "+ i.ToString());
            else
                MessageBox.Show("El valor de " + valorBuscar + " no se encuentra");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un valor entero");
            }
        }
        private void OrdenamientoInsercion()
        {
            int valorActual;
            for (int i = 1; i < vectorDinamico.Count; i++)
            {
                valorActual = vectorDinamico[i];
                int j = i - 1;
                while (j >= 0 && vectorDinamico[j] > valorActual)
                {
                    vectorDinamico[j + 1] = vectorDinamico[j];
                    j--;
                }
                vectorDinamico[j + 1] = valorActual;
            }
            vectorOrdenado.Clear();
            vectorOrdenado.AddRange(vectorDinamico);
            lstVectorDinamico.ItemsSource = vectorOrdenado;
        }
        private int BusquedaBinaria(int valor)
        {
            OrdenamientoInsercion();
            int izquierda = 0;
            int derecha = vectorDinamico.Count-1;
            while (izquierda <= derecha)
            {
                int mitad = izquierda + (derecha - izquierda) / 2;
                if (vectorDinamico[mitad] == valor)
                {
                    return mitad;
                }
                else if (vectorDinamico[mitad] < valor)
                    izquierda = mitad + 1;
                else
                    derecha = mitad - 1;
            }
            return -1;
        }

        private void btnBuscarBinaria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int valor = int.Parse(txtValor.Text);
                int resultado = BusquedaBinaria(valor);
                if(resultado == -1)
                {
                    MessageBox.Show("El valor de " + valor + " no se encuentra ");
                }
                else
                {
                    MessageBox.Show("El valor de " + valor + " se encuentra en el indice: " + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un valor entero");
            }
        }
    }

}
