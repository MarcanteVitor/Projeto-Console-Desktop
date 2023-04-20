using System;

namespace ProjetoEntregar1
{
    class Program
    {
        static List<Documento> documentos = new List<Documento>();

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao cadastro de documentos!");

            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Cadastrar documento");
                Console.WriteLine("2 - Listar documentos");
                Console.WriteLine("3 - Pesquisar documento");
                Console.WriteLine("4 - Salvar documentos em arquivo");
                Console.WriteLine("0 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarDocumento();
                        break;

                    case 2:
                        ListarDocumentos();
                        break;

                    case 3:
                        PesquisarDocumento();
                        break;

                    case 4:
                        SalvarDocumentosEmArquivo();
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarDocumento()
        {
            Console.WriteLine("\nCadastro de documento:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("RG: ");
            string rg = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Habilitação: ");
            string habilitacao = Console.ReadLine();

            Console.Write("Título de eleitor: ");
            string tituloEleitor = Console.ReadLine();

            documentos.Add(new Documento(nome, rg, cpf, habilitacao, tituloEleitor));

            Console.WriteLine("Documento cadastrado com sucesso!");
        }

        static void ListarDocumentos()
        {
            Console.WriteLine("\nLista de documentos:");

            foreach (Documento documento in documentos)
            {
                Console.WriteLine(documento);
            }
        }

        static void PesquisarDocumento()
        {
            Console.WriteLine("\nPesquisa de documento:");

            Console.Write("Digite o CPF do documento a ser pesquisado: ");
            string cpf = Console.ReadLine();

            Documento documentoEncontrado = documentos.Find(d => d.CPF == cpf);

            if (documentoEncontrado != null)
            {
                Console.WriteLine(documentoEncontrado);
            }
            else
            {
                Console.WriteLine("Documento não encontrado!");
            }
        }

        static void SalvarDocumentosEmArquivo()
        {
            Console.WriteLine("\nSalvando documentos em arquivo...");

            using (StreamWriter sw = new StreamWriter("documentos.txt"))
            {
                foreach (Documento documento in documentos)
                {
                    sw.WriteLine($"{documento.Nome},{documento.RG},{documento.CPF},{documento.Habilitacao},{documento.TituloEleitor}");
                }
            }

            Console.WriteLine("Documentos salvos com sucesso!");
        }
    }

    class Documento
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Habilitacao { get; set; }
        public string TituloEleitor { get; set; }

        public Documento(string nome, string rg, string cpf, string habilitacao, string tituloEleitor)
        {
            Nome = nome;
            RG = rg;
            CPF = cpf;
            Habilitacao = habilitacao;
            TituloEleitor = tituloEleitor;
        }
    }

}