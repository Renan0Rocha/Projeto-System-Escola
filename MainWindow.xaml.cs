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
using SystemEscola.Views;

namespace SystemEscola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCadEscola_Click(object sender, RoutedEventArgs e)
        {
            EscolaFormWindow view = new EscolaFormWindow();
            view.ShowDialog();
        }

        private void btnCadCurso_Click(object sender, RoutedEventArgs e)
        {
            CursoFormWindow view = new CursoFormWindow();
            view.ShowDialog();
        }

        private void btnListaCurso_Click(object sender, RoutedEventArgs e)
        {
            CursoListWindow view = new CursoListWindow();
            view.ShowDialog();
        }

        private void btnListaEscola_Click(object sender, RoutedEventArgs e)
        {
            EscolaListWindow view = new EscolaListWindow();
            view.ShowDialog();
        }
    }
}
