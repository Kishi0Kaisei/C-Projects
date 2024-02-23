using Anotacao_BO;
using System.Xml.Serialization;
using Anotacao_Consts;
using SerializeTools;
using ToolBox;

namespace Anotacao_DAL

{
    public class Anotacao_DAO
    {


        [XmlRoot(ElementName = "Anotacoes")]
        public class AnotacoesBD
        {
            public AnotacoesBD()
            {
                Items = new List<RegistoAnotacao>();
            }

            [XmlElement(ElementName = "Anotacao")]
            public List<RegistoAnotacao> Items { get; set; }
        }
        private AnotacoesBD _anotacaoList;
        public Anotacao_DAO()
        {
            _anotacaoList = new AnotacoesBD();
        }

        public bool AdicionarAnotacao(Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;
            _anotacaoList.Items.Add(anotacao.RegistoAnotacao());
            return true;
        }

        public bool ModificarAnotacao(int id, Anotacao anotacao)
        {
            if (ReferenceEquals(anotacao, null)) return false;
            int tIndex = _anotacaoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                _anotacaoList.Items[tIndex] = anotacao.RegistoAnotacao();
                return true;
            }
            return false;
        }

        public bool EliminarAnotacao(int id)
        {
            int tIndex = _anotacaoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                _anotacaoList.Items.RemoveAt(tIndex);
                return true;
            }
            return false;

        }

        public bool ExisteAnotacao(int id, out Anotacao? obj)
        {
            obj = null;
            int tIndex = _anotacaoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                obj = new Anotacao(_anotacaoList.Items[tIndex]);
                return true;
            }
            return false;
        }

        public List<string> GetAnotacaoList()
        {
            List<string> list = new List<string>();
            foreach (RegistoAnotacao a in _anotacaoList.Items)
            {
                list.Add(a.ToString());
            }
            return list;
        }
        public void ExportarDados()
        {
            string ficheiro = System.IO.Path.Combine(System.AppContext.BaseDirectory, Constantes.NomeXmlAnotacoes);
            if (!File.Exists(ficheiro))
            {
                try
                {
                    ExportarXml(ficheiro);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public bool ExportarXml(string ficheiro)
        {
            if (ficheiro != null)
            {
                try
                {
                    XmlMethods.SerializeToXml<AnotacoesBD>(_anotacaoList, ficheiro);

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        public bool ImportarDados()
        {
            string ficheiro = System.IO.Path.Combine(System.AppContext.BaseDirectory, Constantes.NomeXmlAnotacoes);
            return ImportarXml(ficheiro);
        }

        public bool ImportarXml(string ficheiro)
        {
            if (ficheiro != null && File.Exists(ficheiro))
            {
                try
                {
                    _anotacaoList = XmlMethods.DeserializeXmlToObject<AnotacoesBD>(ficheiro);

                    if (_anotacaoList.Items.Count > 0)
                    {
                        int tId = _anotacaoList.Items[0].Id;
                        foreach (RegistoAnotacao r in _anotacaoList.Items)
                        {
                            if (r.Id > tId) tId = r.Id;
                        }
                        GetNewId.Instancia.ResetProximo(tId);
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        // serviços para o API
        public List<Anotacao> GetAnotacoes()
        {
            List<Anotacao> list = new List<Anotacao>();
            foreach (RegistoAnotacao c in _anotacaoList.Items)
            {
                list.Add(new Anotacao(c));
            }
            return list;
        }
    }
}