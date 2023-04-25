using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetoEntregar1
{
    class Program
    {
        static List<Documento> documentos = new List<Documento>();
        public static int larguraTela = Console.WindowWidth;
        public static int meioLinha = (larguraTela / 2);

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
                    LerArquivoDat();
                    break;
                case ConsoleKey.F8:
                    Console.Clear();
                    SalvarDocumentosEmArquivo(documentos, "teste.dat");
                    break;
                case ConsoleKey.F9:
                    Console.WriteLine("Saindo...");
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
            Console.WriteLine("Terminal: Terminal da Piazada");
            Console.WriteLine("Nivel: user");        
        }

        static void footerOptions()
        {
            ConsoleKey opcaoSelecionadaFooter;
            Console.WriteLine("\n\n<F1> Novo Documento <F2>Pesquisar documento <F3> Listar documento ");
            Console.WriteLine("<F4> Menu Inicial <F7> Carregar Arquivo <F8> Salvar Arquivo <F9> Sair");
            Console.WriteLine(" Msg/opção: ");
            opcaoSelecionadaFooter = Console.ReadKey(true).Key;
            Console.Clear();
            switch (opcaoSelecionadaFooter)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    CadastrarDocumento();
                    break;
                case ConsoleKey.F2:
                    Console.Clear();
                    PesquisarDocumento();
                    break;
                case ConsoleKey.F3:
                    Console.Clear();
                    ListarDocumentos();
                    break;
                case ConsoleKey.F4:
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                case ConsoleKey.F7:
                    LerArquivoDat();
                    Console.Clear();
                    break;
                case ConsoleKey.F8:
                    SalvarDocumentosEmArquivo(documentos, "teste.dat");
                    break;
                case ConsoleKey.F9:
                    Console.WriteLine("Saindo...");
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
            Console.Clear();
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

            Console.SetCursorPosition(0, 25);
            footerMenu();
            footerOptions();
        }

        static void ListarDocumentos()
        {
            Console.Clear();
            headerMenu();
            if (documentos.Count == 0)
            {
                Console.WriteLine("\n\nA lista de documentos está vazia :(");
            }
            else
            {
                Console.WriteLine("\nLista de documentos:\n");
                int index = 0;
                foreach (Documento documento in documentos)
                {
                    Console.WriteLine("Documento: [" + index + "]\n");
                    Console.WriteLine(documento.ToString());
                    index = index + 1;
                }
            }
            //Console.SetCursorPosition(0, 10);
            footerMenu();
            footerOptions();

        }

        static void PesquisarDocumento()
        {
            Console.Clear();
            headerMenu();
            Console.WriteLine("\n\nPesquisa de documento:");

            Console.Write("\nDigite o CPF do documento a ser pesquisado: ");
            string cpf = Console.ReadLine();

            Documento documentoEncontrado = documentos.Find(d => d.CPF == cpf);

            if (documentoEncontrado != null)
            {
                Console.WriteLine(documentoEncontrado);
            }
            else
            {
                Console.WriteLine("\nDocumento não encontrado!");
            }
            Console.SetCursorPosition(0, 25);
            footerMenu();
            footerOptions();
        }

        /*static void SalvarDocumentosEmArquivo()
        {
            Console.Clear();
            Console.WriteLine("\nSalvando documentos em arquivo...");

            using (StreamWriter sw = new StreamWriter("C:\\Users\\Vitor Marcante\\Desktop\\Nova pasta (2)\\texto.dat"))
            {
                foreach (Documento documento in documentos)
                {
                    sw.WriteLine($"Nome: {documento.Nome}, \nRG: {documento.RG}, \nCPF: {documento.CPF}, \nHabilitação: {documento.Habilitacao},\nTitulo de Eleitor: {documento.TituloEleitor}");
                }
            }
            Console.Clear();
            Console.WriteLine("Documentos salvos com sucesso!");
        }*/

        public static void SalvarDocumentosEmArquivo(List<Documento> documentos, string nomeDoArquivo)
        {
            

            using (StreamWriter writer = File.CreateText(nomeDoArquivo))
            {
                foreach (Documento documento in documentos)
                {
                    writer.Write(documento.Nome + ",");
                    writer.Write(documento.RG + ",");
                    writer.Write(documento.CPF + ",");
                    writer.Write(documento.Habilitacao + ",");
                    writer.WriteLine(documento.TituloEleitor);
                }
            }
            Console.WriteLine("Documentos salvos com sucesso");

        }

        public static List<Documento> LerArquivoDat()
        {

            List<Documento> documentos = new List<Documento>();

            string nomeDoArquivo = @"..\teste.dat";
            char[] arr = { ',' };
            try
            {
                var linhas = File.ReadAllLines(nomeDoArquivo);
                string[] dados = linhas.Split(arr);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado: ");
            }
            catch (IOException)
            {
                Console.WriteLine("Erro de E/S ao ler o arquivo: ");
            }

            return documentos;
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
            return $"Nome: {Nome}, \nRG: {RG}, \nCPF: {CPF}, \nHabilitação: {Habilitacao},\nTitulo de Eleitor: {TituloEleitor}";
        }
      
    }

}