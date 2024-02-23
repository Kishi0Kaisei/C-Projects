using Anotacao_BOpg;
using Anotacao_Consts;
using Npgsql;
using System.Data;

namespace Anotacao_DALpg
{
    public class Anotacao_DAO
    {
        private NpgsqlConnection _conn;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_conn"></param>

        public Anotacao_DAO(NpgsqlConnection _conn)
        {
            this._conn = _conn;
        }
        /// <summary>
        /// 
        /// </summary>
        public NpgsqlConnection Db => _conn;
        /// <summary>
        /// 
        /// </summary>
        public void DbOpen()
        {
            if (Db.State != ConnectionState.Open) Db.Open();
        }
        /// <summary>
        /// 
        /// </summary>
        public void DbClose()
        {
            if (Db.State == ConnectionState.Open) Db.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="anotacao"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AdicionarAnotacao(Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;

            // ATENÇÃO: não deve incluir o ID na expressão SQL porque será gerado automaticamente...

            string sqltxt = "INSERT INTO public.anotacoes" + "(nome, aula, tipo, revisto) " + "VALUES (@nome, @aula, @tipo, @revisto);";

            NpgsqlTransaction? tr = null;

            try
            {
                DbOpen(); tr = Db.BeginTransaction();
                NpgsqlCommand ano1 = new NpgsqlCommand(sqltxt, Db);
                ano1.Parameters.AddWithValue("@nome", anotacao.Nome);
                ano1.Parameters.AddWithValue("@aula", anotacao.Aula);
                ano1.Parameters.AddWithValue("@tipo", (int)anotacao.Tipo);
                ano1.Parameters.AddWithValue("@revisto", anotacao.Revisto);
                int resultado = ano1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                ano1.Dispose();
                return resultado != 1;
            }

            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }

                throw new Exception("Erro ao adicionar compromisso!", ex);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="anotacao"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public bool ModificarAnotacao(int id, Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;

            string sqltxt = "UPDATE public.anotacao " +
                "SET nome=@nome, aula=@aula, tipo=@tipo, revisto=@revisto" +
                "WHERE id=@id;";

            NpgsqlTransaction? tr = null;

            try
            {
                DbOpen();
                tr = Db.BeginTransaction();
                NpgsqlCommand ano1 = new NpgsqlCommand(sqltxt, Db);

                ano1.Parameters.AddWithValue("@id", anotacao.Id);
                ano1.Parameters.AddWithValue("@nome", anotacao.Nome);
                ano1.Parameters.AddWithValue("@aula", anotacao.Aula);
                ano1.Parameters.AddWithValue("@tipo", (int)anotacao.Tipo);
                ano1.Parameters.AddWithValue("@revisto", anotacao.Revisto);

                int resultado = ano1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                ano1.Dispose();
                return resultado == 1;
            }

            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw new Exception("Erro ao modificar a anotacao", ex);
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>


        public bool EliminarAnotacao(int id)
        {
            string sqltxt = "DELETE FROM public.anotacoes WHERE id=@id;";
            NpgsqlTransaction? tr = null;

            try
            {
                DbOpen();
                tr = Db.BeginTransaction();
                NpgsqlCommand ano1 = new NpgsqlCommand(sqltxt, Db); ano1.Parameters.AddWithValue("@id", id);

                int resultado = ano1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                ano1.Dispose();
                return resultado != -1;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw new Exception("Erro ao apagar anotacao!", ex);
            }

        }

        //public bool ExisteAnotacao(string nome) //existe anotação pelo nome
        //{
        //    Anotacao? obj = null;
        //    return ExisteAnotacao(nome, out obj);
        //}

        //public bool ExisteAnotacao(string nome, out Anotacao? obj)
        //{
        //    obj = null;
        //    return ExisteAnotacao(nome);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ExisteAnotacao(int id, out Anotacao? obj)
        {
            bool resultado = false;
            obj = null;
            string sqltxt = "SELECT id, nome, aula, tipo, revisto FROM public.anotacoes WHERE id=@id; ";

            try
            {
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                qry1.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader res1 = qry1.ExecuteReader();

                if (res1.HasRows && res1.Read())
                {
                    string tmpNome = res1["nome"].ToString();
                    string tmpAula = res1["aula"].ToString();
                    Tipo tmpTipo = (Tipo)res1.GetByte(res1.GetOrdinal("tipo")); ;
                    bool tmpRevisto = res1.GetBoolean(res1.GetOrdinal("revisto"));
                    res1.Close();
                    obj = new Anotacao(id, tmpNome, tmpAula, tmpTipo, tmpRevisto);

                    resultado = true;
                }

                if (!res1.IsClosed) res1.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter anotacao por id", ex);
            }

            return resultado;
        }

        public List<string> GetAnotacaoList()
        {
            List<string> list = new List<string>();
            string sqltxt = "SELECT id, nome, aula, tipo, revisto FROM public.anotacoes;";
            try
            {
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                NpgsqlDataReader res1 = qry1.ExecuteReader();
                if (res1.HasRows)
                {
                    while (res1.Read())
                    {
                        int tmpId = res1.GetInt32(res1.GetOrdinal("id"));
                        string tmpNome = res1["nome"].ToString();
                        string tmpAula = res1["aula"].ToString();
                        list.Add($"{tmpId}\t{tmpNome}, {tmpAula}"); 

                    }

                }
                if (!res1.IsClosed) res1.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter lista<string> de anotacoes", ex);
            }
            return list;
        }

        public List<Anotacao> GetAnotacoes()
        {
            List<Anotacao> list = new List<Anotacao>();
            string sqltxt = "SELECT id,nome,aula,tipo,revisto FROM public.anotacoes;";
            try
            {
                //passo1
                List<int> ListaIds = new List<int>();
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                NpgsqlDataReader res1 = qry1.ExecuteReader();

                if (res1.HasRows)
                {
                    while (res1.Read())
                    {
                        int tmpId = res1.GetInt32(res1.GetOrdinal("id"));
                        ListaIds.Add(tmpId);
                    }
                }
                if (!res1.IsClosed) res1.Close();

                //passo2
                Anotacao? obj;

                foreach (int id in ListaIds)
                {
                    if (ExisteAnotacao(id, out obj))
                    {
                        list.Add(obj);
                    }
                }



            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter lista<string> de anotacoes", ex);
            }
            return list;
        }
       
    }
}