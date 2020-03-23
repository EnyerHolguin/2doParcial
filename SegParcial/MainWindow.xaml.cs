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
            LlamadaIdtextblock.Text = "0";
        }
        public void reCargar()
        {
            this.DataContext = null;
            this.DataContext = llamada;
        }
        private void Limpiar()
        {
            /* LlamadaIdtextblock.Text = "0";
             Despcripciontextblock.Text = string.Empty;
             Problemtextblock.Text = string.Empty;
             Soluciotextblock.Text = string.Empty;j*/
            llamada = new Llamadas();
            LlamadaGrid.ItemsSource = new List<LlamadasDetalles>();
            reCargar();

        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(LlamadaIdtextblock.Text))
            {
                paso = false;
                MessageBox.Show("EL Campo llamadaID No debe Estar Vacío");
                LlamadaIdtextblock.Focus();
            }

            else
            {
                try
                {
                    int i = Convert.ToInt32(LlamadaIdtextblock.Text);
                }
                catch (FormatException)
                {
                    paso = false;
                    MessageBox.Show("Campo LlamadaId Invalido");
                    LlamadaIdtextblock.Focus();

                }

            }

            if (string.IsNullOrWhiteSpace(Despcripciontextblock.Text))
            {
                paso = false;
                MessageBox.Show("El Campo No debe estar Vacío");
                Despcripciontextblock.Focus();

            }
            else
            {
                foreach (var carater in Despcripciontextblock.Text)
                {
                    if (!char.IsLetter(carater)&& !char.IsWhiteSpace(carater)&& !char.IsDigit(carater))
                    {
                        paso = false;
                        MessageBox.Show("No debe de Contener Caracteres Expeciales");
                        Despcripciontextblock.Focus();
                    }
                }

            }
            return paso;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas LlamadaAnterior = LlamadaBLL.Buscar(Convert.ToInt32(LlamadaIdtextblock.Text));

            if (LlamadaAnterior != null)
            {
                llamada = LlamadaAnterior;
                reCargar();
            }
            else
            {

                Limpiar();
                MessageBox.Show("Persona no encontrada");
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadaBLL.Eliminar(Convert.ToInt32(LlamadaIdtextblock.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar no existe");
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

            if (LlamadaIdtextblock.Text == "0")
            {
                paso = LlamadaBLL.Guargar(llamada);
            }
            else
            {
                if (existeEnLaBaseDeDatos())
                {

                    MessageBox.Show("No se puede modificar no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    paso = LlamadaBLL.Modificar(llamada);
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se Pudo Guardar porque debe de haber agregado una llamada");

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
        private bool ValidarAgregar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(Problemtextblock.Text))
                paso = false;

            if (string.IsNullOrWhiteSpace(Soluciotextblock.Text))
                paso = false;

            if (paso == false)
                MessageBox.Show("Debes de Agregar un Problema y su Solucion al detalle");

            return paso;
        }
       private void AgregaButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<LlamadasDetalles>();
            if (ValidarAgregar())
                return;

            llamada.Telefono.Add(new LlamadasDetalles

            (
            llamada.Llamadaid,
            Problemtextblock.Text,
            Soluciotextblock.Text
            )
            );

            reCargar();
            Problemtextblock.Clear();
            Soluciotextblock.Clear();
            Problemtextblock.Focus();

            LlamadaGrid.ItemsSource= null;
            LlamadaGrid.ItemsSource = listado;
        }

        private void NuevobButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

     
    } 
}
