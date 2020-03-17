using SegParcial.BLL;
using SegParcial.Entidades;
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

namespace SegParcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Llamadas llamada = new Llamadas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = llamada;
        }
        public void reCargar()
        {
            this.DataContext = null;
            this.DataContext = llamada;
        }
        private void Limpiar()
        {
            LlamadaIdtextblock.Text = "0";
            Despcripciontextblock.Text = string.Empty;
            Problemtextblock.Text = string.Empty;
            Soluciotextblock.Text = string.Empty;

        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(LlamadaIdtextblock.Text))
                paso = false;
            else
            {
                try
                {
                    int i = Convert.ToInt32(LlamadaIdtextblock.Text);
                }
                catch (FormatException)
                {
                    paso = false;

                }

            }

            if (string.IsNullOrWhiteSpace(Despcripciontextblock.Text))
                paso = false;
            else
            {
                foreach (var carater in Despcripciontextblock.Text)
                {
                    if (!char.IsLetter(carater))
                        paso = false;
                }

            }
            return paso;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas LlamadaAnterior = LlamadaBLL.Buscar(llamada.Llamadaid);

            if (LlamadaAnterior != null)
            {
                llamada = LlamadaAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadaBLL.Eliminar(llamada.Llamadaid))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar no existe");
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (llamada.Llamadaid == 0)
            {
                paso = LlamadaBLL.Guargar(llamada);
            }
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = LlamadaBLL.Modificar(llamada);
                else
                {
                    MessageBox.Show("No se puede modificar no existe");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }
        private bool existeEnLaBaseDeDatos()
        {
            Llamadas LlamadaAnterior = LlamadaBLL.Buscar(llamada.Llamadaid);

            return LlamadaAnterior != null;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
           if (LlamadaGrid.Items.Count > 1 && LlamadaGrid.SelectedIndex < LlamadaGrid.Items.Count - 1)
            {
                llamada.Telefono.RemoveAt(LlamadaGrid.SelectedIndex);
                reCargar();
            }


        }
        private void AgregaButton_Click(object sender, RoutedEventArgs e)
        {
            llamada.Telefono.Add(new LlamadasDetalles(Soluciotextblock.Text, Problemtextblock.Text));

            reCargar();

            Soluciotextblock.Focus();
            Problemtextblock.Focus();
        }

        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}