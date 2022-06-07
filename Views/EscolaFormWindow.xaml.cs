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
using MySql.Data.MySqlClient;
using SystemEscola.Database;
using SystemEscola.Models;

namespace SystemEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaFormWindow.xaml
    /// </summary>
    public partial class EscolaFormWindow : Window
    {
        private Escola _escola = new Escola();

        public EscolaFormWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //if ((bool) rdbtPublica.IsChecked

            _escola.NomeFantasia = txtNomeEscola.Text;
            _escola.RazaoSocial = txtRazaosocial.Text;
            _escola.Cnpj = txtCnpj.Text;
            _escola.Inscricao = txtInscestadual.Text;
            _escola.SetTipo((bool)rdbtPublica.IsChecked);
            _escola.Responsavel = txtResponsavel.Text;
            _escola.TelefoneResp = txtTelefoneresp.Text;
            _escola.Telefone = txtTelefone.Text;
            _escola.Email = txtEmail.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = txtNumero.Text;
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            _escola.Cep = txtCep.Text;
            _escola.Cidade = txtCidade.Text;
            _escola.Estado = txtEstado.Text;
            _escola.Data_Criacao = dtpCricao.SelectedDate;

            try
            {
                var dao = new EscolaDAO();
                dao.Insert(_escola);

                MessageBox.Show("Registro Salvo");

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
