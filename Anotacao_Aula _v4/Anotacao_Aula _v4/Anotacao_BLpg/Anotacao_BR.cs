using Anotacao_BOpg;
using Anotacao_Consts;
using Anotacao_DALpg;
using Compromissos_Models2Api;
using Npgsql;
using System.Data;
using Anotacoes_Config;

namespace Anotacao_BLpg
{
    public class Anotacao_BR
    {
        private NpgsqlConnection _conn;
        private Anotacao_DAO _AnotacaoDao;



        public Anotacao_BR()
        {
            _conn = new NpgsqlConnection(GlobalConfig.Instancia.NpgsqlConnection);
            _AnotacaoDao = new Anotacao_DAO(_conn);
        }
        /// <summary>
        /// destrutor é necessário para terminar a ligação com a base de dados
        /// </summary>
        /// 
        ~Anotacao_BR() { if (_conn.State == ConnectionState.Open) _conn.Close(); _conn.Dispose(); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="aula"></param>
        /// <param name="tipo"></param>
        /// <param name="revisto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public Anotacao NovaAnotacao(string nome, string aula, Tipo tipo, bool revisto = false)
        {

            string? tNome = nome.Trim();
            if (tNome.Length == 0) throw new ArgumentNullException(nameof(tNome));
            string tAula = aula ?? throw new ArgumentNullException(nameof(aula));
            Tipo tTipo = tipo;
            bool tRevisto = revisto;
            return new Anotacao(tNome, tAula, tTipo, tRevisto);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anotacao"></param>
        /// <returns></returns>
        public bool AdicionarAnotacao(Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;
            return _AnotacaoDao.AdicionarAnotacao(anotacao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool EliminarAnotacao(int id)
        {
            return _AnotacaoDao.EliminarAnotacao(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetAnotacaoList()
        {
            return _AnotacaoDao.GetAnotacaoList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="anotacao"></param>
        /// <returns></returns>
        public bool ModificarAnotacao(int id, Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;
            return _AnotacaoDao.ModificarAnotacao(id, anotacao);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        // serviços para o API
        public List<AnotacaoRegistoResponse> GetCompromissoListResponse()
        {
            List<AnotacaoRegistoResponse> lista = new List<AnotacaoRegistoResponse>();
            foreach (var c in _AnotacaoDao.GetAnotacoes())
            {
                lista.Add(c.RegistoAnotacaoResponse());
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ExisteAnotacao(int id, out Anotacao? obj)
        {
            obj = null;
            return _AnotacaoDao.ExisteAnotacao(id, out obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnotacaoRegistoResponse? ObterCompromissoResponse(int id)
        {
            AnotacaoRegistoResponse? obj = null;
            Anotacao? anotacao = null;
            if (ExisteAnotacao(id, out anotacao))
            {
                obj = new AnotacaoRegistoResponse
                {
                    Id = anotacao.Id,
                    Nome = anotacao.Nome,
                    Aula = anotacao.Aula,
                    Tipo = anotacao.Tipo,
                    Revisto = anotacao.Revisto

                };
            }
            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AdicionarAnotacaoRequest(AnotacaoRegistoRequest request)
        {
            Anotacao anotacao = NovaAnotacao(
                request.Nome,
                request.Aula,
                request.Tipo,
                request.Revisto);



            return AdicionarAnotacao(anotacao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool ModificarCompromissoRequest(int id, AnotacaoRegistoRequest request)
        {
            Anotacao? obj = null;
            if (ExisteAnotacao(id, out obj))
            {
                obj.Nome = request.Nome;
                obj.Aula = request.Aula;
                obj.Tipo = request.Tipo;
                obj.Revisto = request.Revisto;

                return ModificarAnotacao(id, obj);
            }
            return false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(int id)
        {
            return _AnotacaoDao.EliminarAnotacao(id);
        }

        //public bool ExisteAnotacao(string nome)
        //{
        //    Anotacao? obj = null;
        //    return _AnotacaoDao.ExisteAnotacao(nome, out obj);
        //}

        //public bool ExisteAnotacao(string nome) //verifica se existe anotação pelo nome
        //{
        //    return _AnotacaoDao.ExisteAnotacao(nome);
        //}
    }

}
