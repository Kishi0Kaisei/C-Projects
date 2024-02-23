using Anotacao_BO;
using Anotacao_Consts;
using Anotacao_DAL;
using Compromissos_Models2Api;

namespace Anotacao_BL;

//public class Anotacao_BR
//{
//    private Anotacao_DAO _Anotacao_DAO;

//    public Anotacao_BR()
//    {
//        _Anotacao_DAO = new Anotacao_DAO();
//    }
//    public Anotacao NovaAnotacao(string nome, string aula, Tipo tipo, bool revisto = false)
//    {

//        string tNome = nome ?? throw new ArgumentNullException(nameof(nome));
//        string tAula = aula ?? throw new ArgumentNullException(nameof(aula));


//        return new Anotacao(tNome, tAula, tipo, revisto);

//    }

//    public bool AdicionarAnotacao(Anotacao anotacao)
//    {
//        if (ReferenceEquals(anotacao, null)) return false;

//        return _Anotacao_DAO.AdicionarAnotacao(anotacao);
//    }

//    public bool ModificarAnotacao(int id, Anotacao anotacao)
//    {
//        if (ReferenceEquals(anotacao, null)) return false;

//        return _Anotacao_DAO.ModificarAnotacao(id, anotacao);
//    }

//    public bool EliminarAnotacao(int id)
//    {
//        return _Anotacao_DAO.EliminarAnotacao(id);
//    }

//    public List<string> GetAnotacaoList()
//    {
//        return _Anotacao_DAO.GetAnotacaoList();
//    }
//    public void ExportarDados()
//    {
//        _Anotacao_DAO.ExportarDados();
//    }

//    public bool ImportarDados()
//    {
//        return _Anotacao_DAO.ImportarDados();
//    }
//}

public class Anotacao_BR
{
    private Anotacao_DAO _AnotacaoDao;
    /// <summary>
    /// 
    /// </summary>
    public Anotacao_BR()
    {
        _AnotacaoDao = new Anotacao_DAO();
    }
    
    public Anotacao NovaAnotacao(string nome, string aula, Tipo tipo, bool revisto = false)
    {
        
        string? tNome = nome.Trim();
        if (tNome.Length == 0) throw new ArgumentNullException(nameof(tNome));
        string tAula = aula ?? throw new ArgumentNullException(nameof(aula));
        Tipo tTipo = tipo;
        bool tRevisto = revisto;
        return new Anotacao(tNome, tAula, tTipo ,tRevisto);

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
  
    public List<string> GetAnotacaoList()
    {
        return _AnotacaoDao.GetAnotacaoList();
    }

    public bool ModificarAnotacao(int id, Anotacao anotacao)
    {
        if (ReferenceEquals(anotacao, null)) return false;
        return _AnotacaoDao.ModificarAnotacao(id, anotacao);
    }

   
    public void ExportarDados()
    {
        _AnotacaoDao.ExportarDados();
    }

    public bool ImportarDados()
    {
        return _AnotacaoDao.ImportarDados();
    }

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

    public bool ExisteCompromisso(int id, out Anotacao? obj)
    {
        obj = null;
        return _AnotacaoDao.ExisteAnotacao(id, out obj);
    }
    public AnotacaoRegistoResponse? ObterCompromissoResponse(int id)
    {
        AnotacaoRegistoResponse? obj = null;
        Anotacao? anotacao = null;
        if (ExisteCompromisso(id, out anotacao))
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

    public bool AdicionarAnotacaoRequest(AnotacaoRegistoRequest request)
    {
        Anotacao anotacao = NovaAnotacao(
            request.Nome,
            request.Aula,
            request.Tipo,
            request.Revisto);

        

        return AdicionarAnotacao(anotacao);
    }
    public bool ModificarCompromissoRequest(int id, AnotacaoRegistoRequest request)
    {
        Anotacao? obj = null;
        if (ExisteCompromisso(id, out obj))
        {
            obj.Nome = request.Nome;
            obj.Aula = request.Aula;
            obj.Tipo = request.Tipo;
            obj.Revisto = request.Revisto;
            
            return ModificarAnotacao(id, obj);
        }
        return false;

    }
    public bool ApagarCompromisso(int id)
    {
        return _AnotacaoDao.EliminarAnotacao(id);
    }
}
