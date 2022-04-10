using System;
using System.IO;

namespace CSharp_Move_Delete_Rename
{
    class Program
    {
        static void Main(string[] args)
        {
            DeletaArquivos_pastaOrigem();
            MoveArquivos();
            TrocaNome_Arquivo();
        }


        // Move arquivos da pasta origem para destino
        public static void MoveArquivos()
        {

            string local = @"C:\educaciencia\";
            string destino = @"C:\destino_educaciencia\educaciencia\";


            string nomeDestino = "Archive_" + DateTime.Now.ToString("ddMMyyyy") + "" + DateTime.Now.ToString("HHmm") + "hs" + "" + DateTime.Now.ToString("ss") + "seg";
            string archive = destino + nomeDestino + "\\";
            DirectoryInfo dir = new DirectoryInfo(local);

            try
            {
                if (!Directory.Exists(archive))
                {
                    Directory.CreateDirectory(archive);
                    foreach (FileInfo arquivo in dir.GetFiles("."))
                    {
                        File.Move(arquivo.FullName, archive + arquivo.Name);
                    }
                    Console.WriteLine("EducaCiencia FastCode - Diretorio criado e arquivos movidos!");
                }
                else
                {
                    foreach (FileInfo arquivo in dir.GetFiles("."))
                    {
                        File.Move(arquivo.FullName, archive + arquivo.Name);
                    }
                    Console.WriteLine("EducaCiencia FastCode - arquivos movidos!");
                }

            }
            catch (Exception e)
            {
                throw new Exception($"EducaCiencia FastCode - Falha ao criar/mover arquivo:  {e} ");
            }
        }

        // Deleta arquivos
        public static void DeletaArquivos_pastaOrigem()
        {
            try
            {
                string path = @"C:\educaciencia\del";

                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                    Console.WriteLine("EducaCiencia FastCode - arquivo deletado");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"EducaCiencia FastCode - Falha ao deletar arquivo:  {e} ");
            }
        }

        public static void TrocaNome_Arquivo()
        {
            try
            {
                string path = @"C:\educaciencia\";
                string nomeAtual = path + "texto.txt";
                string nomeAtualizado = path + "texto_atualizado.txt";
                Console.WriteLine("EducaCiencia FastCode -  - alterações realizadas com sucesso.");
                System.IO.File.Move(nomeAtual, nomeAtualizado);

            }
            catch (Exception e)
            {
                throw new Exception($"EducaCiencia FastCode - Falha ao renomear arquivo:  {e} ");
            }
        }
    }
}
