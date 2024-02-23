using Anotacao_BLpg;
using Anotacao_BOpg;
using Anotacao_Consts;

internal class Program
{/// <summary>
/// 
/// </summary>
/// <param name="args"></param>
    private static void Main(string[] args)
    {
        Anotacao_BR gestaoAnotacao = new Anotacao_BR();
        
        Anotacao novo1 = gestaoAnotacao.NovaAnotacao("Teste1", "Retórica", Tipo.GrupoEstudo);

        Console.WriteLine("...a verficar os dados na BD...");

        VerificarAdiciona(gestaoAnotacao, novo1);
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste2", "Anatomia", Tipo.Aula, true));
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste3", "Biologia", Tipo.Seminario));
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste4", "Psicologia", Tipo.Leitura));
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste5", "Sistemas Imunitários", Tipo.Sessao, true));
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste6", "Sociologia", Tipo.Aula, true));
        VerificarAdiciona(gestaoAnotacao, gestaoAnotacao.NovaAnotacao("Teste7", "Filosofia", Tipo.Leitura, true));

        Console.WriteLine("Listar Objetos");
        MostrarLista(gestaoAnotacao.GetAnotacaoList());


        Console.WriteLine("Apagar objecto 'teste2' ");
        if (gestaoAnotacao.EliminarAnotacao(2))
            MostrarLista(gestaoAnotacao.GetAnotacaoList());


        //Console.WriteLine($"Verficar objeto {novo1.Id}");
        //if (gestaoAnotacao.ExisteAnotacao(novo1.Nome)) ;


        //Console.WriteLine($"Modificar o estado da entrada 1 ");
        //gestaoAnotacao.ModificarAnotacao(novo1.Aula = "Oratória");

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoAnotacao.GetAnotacaoList());

    }
    ///<summary>
    ///
    /// </summary>
    /// 

    private static void VerificarAdiciona(Anotacao_BR br, Anotacao novo)
    {
        if (novo!=null)
        {
            Anotacao? obj = null;
            if (!br.ExisteAnotacao(novo.Id, out obj))
            {
                br.AdicionarAnotacao(novo);
                Console.WriteLine($"Anotacao para {novo.Id} foi adicionado na BD");
            }
            else
            {
                Console.WriteLine($"Anotacao para {novo.Id} já existe na BD");
            }
        }
    }
    ///<summary>
    ///
    ///</summary>
    ///
    private static void MostrarLista(List<string> lista) 
    {
        foreach (var item in lista)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

