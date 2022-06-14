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
    }
}
