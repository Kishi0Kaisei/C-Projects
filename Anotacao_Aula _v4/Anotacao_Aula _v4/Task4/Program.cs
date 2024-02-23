using Anotacao_BL;
using Anotacao_BO;
using Anotacao_Consts;

internal class Program
{
    private static void Main(string[] args)
    {
        Anotacao_BR gestaoAnotacao = new Anotacao_BR();
        Anotacao novo1 = gestaoAnotacao.NovaAnotacao("Teste0","Retórica",Tipo.GrupoEstudo,false);
        if (!gestaoAnotacao.ImportarDados())
        {
            Console.WriteLine("Os dados não foram carregados.");
            Console.WriteLine();
            Console.WriteLine("Adicionar as entradas");
            gestaoAnotacao.AdicionarAnotacao(novo1);
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste1", "Anatomia", Tipo.Aula,true));
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste2", "Biologia", Tipo.Seminario, true));
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste3", "Psicologia", Tipo.Leitura));
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste4", "Sistemas Imunitários", Tipo.Sessao, true));
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste5", "Sociologia", Tipo.Aula));
            gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste6", "Filosofia", Tipo.Leitura));


        }
        else
        {
            Console.WriteLine("Dados carregados!");
        }

        Console.WriteLine("Apagar a entrada Seminario ");
        if (gestaoAnotacao.EliminarAnotacao(1))
            MostrarLista(gestaoAnotacao.GetAnotacaoList());
       
     
        Console.WriteLine("Adicionar nova entrada");
        gestaoAnotacao.AdicionarAnotacao(gestaoAnotacao.NovaAnotacao("Teste7","TIC",Tipo.GrupoEstudo,true));

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoAnotacao.GetAnotacaoList());

        Console.WriteLine("Serializar a lista");
        gestaoAnotacao.ExportarDados();

        Console.WriteLine("Listar os objetos");
        MostrarLista(gestaoAnotacao.GetAnotacaoList());

        foreach (var item in gestaoAnotacao.GetAnotacaoList())
        {
            Console.WriteLine(item.ToString());
        }
       
        static void MostrarLista(List<string> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}

