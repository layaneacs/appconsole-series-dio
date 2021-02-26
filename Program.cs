using System;

namespace Dio.Series
{   
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {       
            Console.WriteLine("Hi");
            string opcaoUsuario = ObterOpcao();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcao();
            };

            Console.WriteLine("Bye");
        }

        private static void ListaSerie(){
            var lista = repositorio.Lista();

            Console.WriteLine("Lista das Séries");

            if(lista.Count == 0) {
                Console.WriteLine("Nenhuma Série encontrada");
                return;
            }

            foreach (var item in lista)
            {
                var exluido = item.RetornaExluido();
                // if(!exluido){
                //     Console.WriteLine("#ID {0}: - {1}", item.retornaId(), item.retornaTitulo());
                // }
                Console.WriteLine("#ID {0}: - {1} {2}", item.retornaId(), item.retornaTitulo(), (exluido ? "- Excluido":""));
                
            }
        }
        private static void  InserirSerie(){

            Console.WriteLine("Inserir nova Série");
            foreach (int e in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}" ,e , Enum.GetName(typeof(Genero), e));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(
                repositorio.ProximoId(),
                (Genero)entradaGenero, 
                entradaTitulo, 
                entradaDescricao, 
                entradaAno);            
            
            repositorio.Insere(serie);
        }

        private static void  AtualizarSerie(){
            ListaSerie();
            Console.WriteLine("Digite o ID da Sériee ");
            int entradaId = int.Parse(Console.ReadLine());
            
            foreach (int e in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}" ,e , Enum.GetName(typeof(Genero), e));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(
                entradaId,
                (Genero)entradaGenero, 
                entradaTitulo, 
                entradaDescricao, 
                entradaAno);            

            repositorio.Atualizar(entradaId, serie);
            
        }

        
        private static void ExcluirSerie(){
            ListaSerie();
            Console.WriteLine("Digite o ID da Série que deseja excluir: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exluir(entradaId);
            
        }        
        private static void VisualizarSerie(){
            ListaSerie();
            Console.WriteLine("Digite o ID da Série que deseja visualizar: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId).ToString();
            Console.WriteLine(serie);
            
        }

        private static string ObterOpcao(){

            Console.WriteLine();
            Console.WriteLine("DIO Series");
            Console.WriteLine("Informe a Opção Desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir uma nova serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
