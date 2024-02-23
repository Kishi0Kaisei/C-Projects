using Compromissos_Models2Api;
using Newtonsoft.Json;  

    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                string a = "https://localhost:7259";
                string b = $"{a}/api/Anotacoes";
                using HttpResponseMessage response = await client.GetAsync(b);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                List<AnotacaoRegistoResponse> lista =
                    JsonConvert.DeserializeObject<List<AnotacaoRegistoResponse>>(responseBody);
                if (lista != null && lista.Count > 0)
                {
                    foreach (var item in lista)
                    {
                        Console.WriteLine($"{item.Id}\t{item.Nome}\t{item.Tipo}\t{item.Revisto}");
                    }
                }
                else
                {
                    Console.WriteLine("Lista vazia!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
