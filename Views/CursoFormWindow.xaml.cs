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
            Loaded += CadastroCurso_Loaded;
        }

        public CursoFormWindow(Curso curso)
        {
            InitializeComponent();
            Loaded += CadastroCurso_Loaded;
            _curso = curso;
        }

        private void CadastroCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCurso.Text = _curso.NomeCurso;
            txtCargaHoraria.Text = _curso.Descricao;
            txtTurno.Text = _curso.CargaHoraria;
            txtDescricao.Text = _curso.Turno;
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

                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListaCurso_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
