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
            Loaded += CadastroEscola_Loaded;
        }
        public EscolaFormWindow(Escola escola)
        {
            InitializeComponent();
            Loaded += CadastroEscola_Loaded;
            _escola = escola;
        }
        private void CadastroEscola_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeEscola.Text = _escola.NomeFantasia;
            txtRazaosocial.Text = _escola.RazaoSocial;
            txtCnpj.Text = _escola.Cnpj;
            txtInscestadual.Text = _escola.Inscricao;
            if (_escola.Tipo == "Público")
            {
                rdbtPublica.IsChecked = true;
            }
            else
            {
                rdbtPrivada.IsChecked = true;
            }
            txtResponsavel.Text = _escola.Responsavel;
            txtTelefoneresp.Text = _escola.TelefoneResp;
            txtTelefone.Text = _escola.Telefone;
            txtEmail.Text = _escola.Email;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero;
            txtBairro.Text = _escola.Bairro;
            txtComplemento.Text = _escola.Complemento;
            txtCep.Text = _escola.Cep;
            txtCidade.Text = _escola.Cidade;
            txtEstado.Text = _escola.Estado;
            dtpCricao.SelectedDate = _escola.Data_Criacao;
            //radio button
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

                if (_escola.Id > 0)
                {
                    dao.Update(_escola);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_escola);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListaEscola_Click(object sender, RoutedEventArgs e)
        {
            EscolaListWindow view = new EscolaListWindow();
            view.ShowDialog();
        }
    }
}
