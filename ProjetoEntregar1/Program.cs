using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection.Metadata;

namespace ProjetoEntregar1
{
    class Program
    {
        const string FILEPATH = @"..\Cadastros.dat";
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
            Console.Clear();
            headerMenu();
            ConsoleKey opcaoSelecionadaMain;
            Console.WriteLine("\n\nEscolha uma opção:");
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
                    ReadFile(FILEPATH);
                    break;
                case ConsoleKey.F8:
                    Console.Clear();
                    SalvarDocumentosEmArquivo(documentos, FILEPATH);
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
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            escreveEqualLine();
            Console.Write("Usuario: User1");
            Console.SetCursorPosition(meioLinha - 12, Console.CursorTop);
            Console.Write("Terminal: Terminal da Piazada");
            Console.SetCursorPosition(larguraTela - 11, Console.CursorTop);
            Console.WriteLine("Nivel: user");     
            Console.Write("msg/opcao:");

        }

        static void footerOptions()     
        {
            ConsoleKey opcaoSelecionadaFooter;
            Console.Write("<F4> Menu Inicial  <F9> Sair       ");
            opcaoSelecionadaFooter = Console.ReadKey(true).Key;
            Console.Clear();
            switch (opcaoSelecionadaFooter)
            {
                case ConsoleKey.F9:
                    closeMenu();
                    break;
                case ConsoleKey.F4:
                    mainMenu();
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

        static void CadastrarDocumento(string mensagem = "")
        {
            Console.Clear();
            headerMenu();

            Console.WriteLine(mensagem);

            Console.WriteLine("\nGerenciar de documento:");


            int docsLength = documentos.Count;
            string listaCount = docsLength.ToString();
            int atual = (docsLength - 1);
            if (docsLength ==  0)
            {
                atual = 0;
                listaCount = "<N>";
            }
            Console.Write("Registro.....:" + atual + " de " + listaCount);
            camposDocumento();
            /*
                        Console.CursorLeft = 0;
                        Console.CursorTop = 5;
                        Console.Write("Nome........:");

                        Console.CursorLeft = 0;
                        Console.CursorTop = 6;
                        Console.Write("RG..........:");

                        Console.CursorLeft = 0;
                        Console.CursorTop = 7;
                        Console.Write("CPF.........:");

                        Console.CursorLeft = 0;
                        Console.CursorTop = 8;
                        Console.Write("Habilitação.:");

                        Console.CursorLeft = 0;
                        Console.CursorTop = 9;
                        Console.Write("Tit. Eleitor:");*/


            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.WriteLine("<F1> Insere novo <F4> Menu <F9> Sair");

            footerMenu();
            ConsoleKey opcaoSelecionadaDocumento;
            opcaoSelecionadaDocumento = Console.ReadKey(true).Key;
            switch (opcaoSelecionadaDocumento)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    saveDocumento();
                    break;
                case ConsoleKey.F2:
                    Console.Clear();
                    previusDocumento(atual);
                    break;
                case ConsoleKey.F4:
                    mainMenu();
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

        static void camposDocumento()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 5;
            Console.Write("Nome........:");

            Console.CursorLeft = 0;
            Console.CursorTop = 6;
            Console.Write("RG..........:");

            Console.CursorLeft = 0;
            Console.CursorTop = 7;
            Console.Write("CPF.........:");

            Console.CursorLeft = 0;
            Console.CursorTop = 8;
            Console.Write("Habilitação.:");

            Console.CursorLeft = 0;
            Console.CursorTop = 9;
            Console.Write("Tit. Eleitor:");
        }

        static void saveDocumento()
        {
            Console.Clear();
            headerMenu();
            Console.WriteLine("\nNovo documento:");
            camposDocumento();
            Console.CursorLeft = 13;
            Console.CursorTop = 5;
            string nome = Console.ReadLine();

            Console.CursorLeft = 13;
            Console.CursorTop = 6;
            string rg = Console.ReadLine();

            Console.CursorLeft = 13;
            Console.CursorTop = 7;
            string cpf = Console.ReadLine();

            Console.CursorLeft = 13;
            Console.CursorTop = 8;
            string habilitacao = Console.ReadLine();

            Console.CursorLeft = 13;
            Console.CursorTop = 9;
            string tituloEleitor = Console.ReadLine();

            documentos.Add(new Documento(nome, rg, cpf, habilitacao, tituloEleitor));

            Console.WriteLine("Documento cadastrado com sucesso!");
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.WriteLine("<F1> Insere novo <F4> Menu <F9> Sair");

            footerMenu();
            ConsoleKey opcaoSelecionadaDocumento;
            opcaoSelecionadaDocumento = Console.ReadKey(true).Key;
            switch (opcaoSelecionadaDocumento)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    saveDocumento();
                    break;
                case ConsoleKey.F4:
                    mainMenu();
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

        static void previusDocumento(int index)
        {
            Console.Clear();
            headerMenu();
            if (index == 0 )
            {
                Console.WriteLine("Não há documentos anteriores");
            }
            else
            {
                Console.WriteLine("\nDocumento Anterior:");
                camposDocumento();
                Console.CursorLeft = 13;
                Console.CursorTop = 5;
                Console.WriteLine(documentos[index - 1].Nome);

                Console.CursorLeft = 13;
                Console.CursorTop = 6;
                Console.WriteLine(documentos[index - 1].RG);

                Console.CursorLeft = 13;
                Console.CursorTop = 7;
                Console.WriteLine(documentos[index - 1].CPF);

                Console.CursorLeft = 13;
                Console.CursorTop = 8;
                Console.WriteLine(documentos[index - 1].Habilitacao);

                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                Console.WriteLine(documentos[index - 1].TituloEleitor);
            }

            
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.WriteLine("<F1> Insere novo <F2> Anterior <F3> Próximo <F5> Editar <F9> Sair");

            footerMenu();
            ConsoleKey opcaoSelecionadaDocumento;
            opcaoSelecionadaDocumento = Console.ReadKey(true).Key;
           /* switch (opcaoSelecionadaDocumento)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    saveDocumento();
                    break;
                case ConsoleKey.F2:
                    previusDocumento(atual);
                    break;
                case ConsoleKey.F3:
                    nextDocumentos(atual);
                    break;
                case ConsoleKey.F9:
                    Console.WriteLine("Saindo...");
                    closeMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }*/
        }

        static void nextDocumentos(int index)
        {
            Console.Clear();
            headerMenu();
            int indexLista = index + 1;

            if (indexLista == documentos.Count)
            {
                indexLista = index;
                Console.WriteLine("\nNão há proximo documento, exibindo o ultimo documento");
            }

            Console.WriteLine("\nDocumento Anterior:" + indexLista);
            camposDocumento();
            Console.CursorLeft = 13;
            Console.CursorTop = 5;
            Console.WriteLine(documentos[indexLista].Nome);

            Console.CursorLeft = 13;
            Console.CursorTop = 6;
            Console.WriteLine(documentos[indexLista].RG);

            Console.CursorLeft = 13;
            Console.CursorTop = 7;
            Console.WriteLine(documentos[indexLista].CPF);

            Console.CursorLeft = 13;
            Console.CursorTop = 8;
            Console.WriteLine(documentos[indexLista].Habilitacao);

            Console.CursorLeft = 13;
            Console.CursorTop = 9;
            Console.WriteLine(documentos[indexLista].TituloEleitor);
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
                    Console.WriteLine("\nDocumento: [" + index + "]");
                    Console.WriteLine(documento.ToString());
                    index = index + 1;
                }
            }
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

            Console.WriteLine("Lista de documento salvo com sucesso");

        }

        static void ReadFile(string filePath)
        {
            Console.Clear();
            headerMenu();
            string[] linhas = File.ReadAllLines(filePath);


            if (linhas.Length < 1)
            {
                Console.WriteLine("Arquivo Vazio");
     
            }
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                documentos.Add(new Documento(campos[0], campos[1], campos[2], campos[3], campos[4]));
                Console.WriteLine("Nome:" + campos[0] + " RG:" + campos[1] + " CPF:" + campos[2] + " Habilitação:" + campos[3] + " Tit. Eleitor:" + campos[4]);
            }

            Console.WriteLine("");
            footerMenu();
            footerOptions();
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
            return $"Nome: {Nome}, RG: {RG}, CPF: {CPF}, Habilitação: {Habilitacao}, Titulo de Eleitor: {TituloEleitor};";
        }
      
    }

}