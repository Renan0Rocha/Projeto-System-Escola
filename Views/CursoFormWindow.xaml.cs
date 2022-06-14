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
    /// Lógica interna para CursoFormWindow.xaml
    /// </summary>
    public partial class CursoFormWindow : Window
    {
        private Curso _curso = new Curso();   
        public CursoFormWindow()
        {
            InitializeComponent();
        }

        private void btnSalvarCurso_Click(object sender, RoutedEventArgs e)
        {
            _curso.NomeCurso = txtNomeCurso.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Turno = txtTurno.Text;
            _curso.Descricao = txtDescricao.Text;

            try
            {
                var dao = new CursoDAO();
                dao.Insert(_curso);

                MessageBox.Show("Registro Salvo");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListaCurso_Click(object sender, RoutedEventArgs e)
        {
            CursoListWindow view = new CursoListWindow();
            view.ShowDialog();
        }
    }
}
