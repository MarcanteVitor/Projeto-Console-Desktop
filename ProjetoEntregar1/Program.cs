using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;

namespace ProjetoEntregar1
{
    class Program
    {
        static List<Documento> documentos = new List<Documento>();
        public static int larguraTela = Console.WindowWidth;
        public  static int meioLinha = (larguraTela / 2);

        static void Main(string[] args)
        {
            while (true)
            {
                mainMenu();
            }
        }

        static void mainMenu()
        {
            headerMenu();
            ConsoleKey opcaoSelecionadaMain;
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("F1 - Cadastrar documento");
            Console.WriteLine("F2 - Pesquisar documento");
            Console.WriteLine("F3 - Listar documentos");

            Console.WriteLine("F7 - Carregar Documentos");
            Console.WriteLine("F8 - Salvar documentos em arquivo");
            Console.WriteLine("F9 - Sair");

            opcaoSelecionadaMain = Console.ReadKey(true).Key;
            switch (opcaoSelecionadaMain)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    CadastrarDocumento();
                    Console.Clear();
                    mainMenu();
                    break;
                case ConsoleKey.F2:
                    Console.Clear();
                    PesquisarDocumento();
                    break;
                case ConsoleKey.F3:
                    Console.Clear();
                    ListarDocumentos();
                    break;
                case ConsoleKey.F7:
                    Console.Clear();
                    SalvarDocumentosEmArquivo();
                    break;
                case ConsoleKey.F8:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                case ConsoleKey.F9:
                    closeMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!\n\n");
                    break;
            }
        }

        static void headerMenu()
        {
            Console.Write("SisQuinta");
            Console.SetCursorPosition(meioLinha - 12, Console.CursorTop);
            Console.Write("Cadastro de documentos");

            DateTime dataAtual = DateTime.Now;
            Console.SetCursorPosition(larguraTela - 11, Console.CursorTop);
            Console.WriteLine(dataAtual.ToString("dd/MM/yyyy"));
            escreveEqualLine();

        }


        static void footerMenu()
        {
            escreveEqualLine();
            Console.WriteLine("Usuario: User1");
            Console.SetCursorPosition(meioLinha - 12, 27);
            Console.Write("Terminal: Terminal da Piazada");
            Console.SetCursorPosition(larguraTela - 12, 27);
            Console.WriteLine("Nivel: user");
            Console.WriteLine(" Msg/opção: ");           
        }

        static void footerOptions()
        {
            ConsoleKey opcaoSelecionadaFooter;
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("<F4> Menu Inicial      <F9> Sair");
            opcaoSelecionadaFooter = Console.ReadKey(true).Key;
            switch (opcaoSelecionadaFooter)
            {
                case ConsoleKey.F4:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                case ConsoleKey.F9:
                    closeMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            
        }

        static void closeMenu()
        {
            Console.WriteLine("\n Deseja finalizar o sistema ?");
            Console.WriteLine("<S> - Sim");
            Console.WriteLine("<N> - Não");

            ConsoleKey opcaoSelecionadaClose;
            opcaoSelecionadaClose = Console.ReadKey(true).Key;
            switch (opcaoSelecionadaClose)
            {
                case ConsoleKey.S:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.N:
                    mainMenu();
                    break;
                default:
                    mainMenu();
                    break;
            }

        }

        static void escreveEqualLine()
        {
            string textoIgualLine = "";

            for (int i = 0; i < larguraTela; i++)
            {
                textoIgualLine += "=";

            }
            Console.Write(textoIgualLine);

        }

        static void CadastrarDocumento()
        {
            headerMenu();
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
            footerOptions();
            footerMenu();
        }

        static void ListarDocumentos()
        {
            if (documentos.Count == 0)
            {
                Console.WriteLine("A lista de documentos está vazia :(");
            }
            else
            {
                Console.WriteLine("\nLista de documentos:");
                foreach (Documento documento in documentos)
                {
                    Console.WriteLine(documento.ToString());
                }
            }

        }

        static void PesquisarDocumento()
        {
            Console.Clear();
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

            footerMenu();
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
        public override string ToString()
        {
            return $"Nome: {Nome}, RG: {RG}, CPF: {CPF}, Habilitação: {Habilitacao},Titulo de Eleitor: {TituloEleitor}";
        }

    }

}