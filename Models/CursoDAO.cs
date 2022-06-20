using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEscola.Database;
using SystemEscola.Helpers;
using MySql.Data.MySqlClient;

namespace SystemEscola.Models
{
    internal class CursoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert (Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Curso VALUES " +
                "(null, @nome_curso, @carga_horaria, @turno, @descricao);";

                comando.Parameters.AddWithValue("@nome_curso", curso.NomeCurso);
                comando.Parameters.AddWithValue("@carga_horaria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Curso> List()
        {
            try
            {
                var lista = new List<Curso>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Curso";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();

                    curso.Id = reader.GetInt32("id_cur");
                    curso.NomeCurso = DAOHelper.GetString(reader, "nome_cur");
                    curso.CargaHoraria = DAOHelper.GetString(reader, "carga_horaria_cur");
                    curso.Turno = DAOHelper.GetString(reader, "turno_cur");
                    curso.Descricao = DAOHelper.GetString(reader, "descricao_cur");

                    lista.Add(curso);

                }
                reader.Close();
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Curso t)
        {
            
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "delete from Curso where id_cur = @id";

                comando.Parameters.AddWithValue("@id", t.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                    throw new Exception("Registro não removido da base de dados." +
                        "Verifique e tente novamente");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Curso SET " +
                    "nome_cur = @nome, carga_horaria_cur = @cargaHoraria, turno_cur = @turno, descricao_cur = @descricao" +
                    " Where id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);
                comando.Parameters.AddWithValue("@nome", curso.NomeCurso);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
