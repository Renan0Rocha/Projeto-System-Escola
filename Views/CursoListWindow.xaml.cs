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
    /// Lógica interna para CursoListWindow.xaml
    /// </summary>
    public partial class CursoListWindow : Window
    {
        public CursoListWindow()
        {
            InitializeComponent();
            Loaded += CursoListWindow_Loaded;
        }

        private void CursoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new CursoDAO();
                List<Curso> listaCursos = dao.List();

                dataGridCurso.ItemsSource = listaCursos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExcluirCurso_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelected = dataGridCurso.SelectedItem as Curso;

            var result = MessageBox.Show($"Deseja realmente excluir o curso '{cursoSelected.NomeCurso}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if(result == MessageBoxResult.Yes)
                {
                    var dao = new CursoDAO();
                    dao.Delete(cursoSelected);
                    CarregarListagem();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAtualizarCurso_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelected = dataGridCurso.SelectedItem as Curso;
            var view = new CursoFormWindow(cursoSelected);
            view.ShowDialog();
            CarregarListagem();
        }
    }
}
