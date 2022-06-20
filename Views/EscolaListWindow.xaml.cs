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
using System.Windows.Shapes;
using SystemEscola.Models;
using SystemEscola.Views;

namespace SystemEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaListWindow.xaml
    /// </summary>
    public partial class EscolaListWindow : Window
    {
        public EscolaListWindow()
        {
            InitializeComponent();
            Loaded += EscolaListWindow_Loaded;
        }
        private void EscolaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExcluirEscola_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGridEscola.SelectedItem as Escola;

            var result = MessageBox.Show($"Deseja realmente excluir a Escola '{escolaSelected.NomeFantasia}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelected);
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnAtualizarEscola_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGridEscola.SelectedItem as Escola;
            var view = new EscolaFormWindow(escolaSelected);
            view.ShowDialog();
            CarregarListagem();
        }
    }
}
