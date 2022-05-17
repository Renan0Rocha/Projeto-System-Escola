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
                var conexao = new Conexao();
                var comando = conexao.Query();


                comando.CommandText = "insert into Escola Values (null, @nome, @razao, @cnpj, @inscricao, @tipo, @data_criacao, @resp, @resp_tel," +
                    "@email, @telefone, @rua, @numero, @bairro, @complemento, @cep, @cidade, @estado);";

                //null, CAIXA ESCOLAR DA CARLOS D. ESCOLA, 89.451.772/0001-53," +
                //" 63237482279945, Estadual, 1975-10-18, Severino Julio Elias Vieira, (69) 98329-1840, severinojuliovieira@hawk.com.br," +
                //" (69) 999210254, Rua das Mangueiras, 499, Jardim Presidencial, Prédio, 76901-042, Ji-Paraná, RO);";

                comando.Parameters.AddWithValue("@nome", nomeFantasia);
                comando.Parameters.AddWithValue("@razao", razaoSocial);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@inscricao", inscricao);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@data_criacao", data_criacao);
                comando.Parameters.AddWithValue("@resp", responsavel);
                comando.Parameters.AddWithValue("@resp_tel", telefoneResp);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@rua", rua);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@complemento", cep);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Registro Salvo");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
