using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaVersionamento.Services
{
    class ComparadorService
    {
        public bool FileCompareTamanho(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);


            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();

                return false;
            }

            fs1.Close();
            fs2.Close();

            return true;
        }


        public bool FileCompareConteudo(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1) && (file2byte != -1));

            fs1.Close();
            fs2.Close();

            if ((file1byte == file2byte))
            {
                return true;
            }
            return false;
        }


        public bool FileCompareDateCreate(string file1, string file2)
        {
            FileInfo fileInfo1 = new FileInfo(file1);
            FileInfo fileInfo2 = new FileInfo(file2);

            // local times
            DateTime creationTime1 = fileInfo1.CreationTime;

            // UTC times
            //DateTime creationTimeUtc1 = fileInfo1.CreationTimeUtc;          


            // local times
            DateTime creationTime2 = fileInfo2.CreationTime;

            // UTC times
            //DateTime creationTimeUtc2 = fileInfo2.CreationTimeUtc;            

            //Console.WriteLine("\n Arquivo 1: " + creationTime1);
            //Console.WriteLine("\n Arquivo 2: " + creationTime2);

            if (creationTime1 == creationTime2)
            {
                return true;
            }

            return false;

        }

        public bool FileCompareDateLastWrite(string file1, string file2)
        {
            FileInfo fileInfo1 = new FileInfo(file1);
            FileInfo fileInfo2 = new FileInfo(file2);

            // local times           
            DateTime lastWriteTime1 = fileInfo1.LastWriteTime;

            // UTC times            
            //DateTime lastWriteTimeUtc1 = fileInfo1.LastWriteTimeUtc;           


            // local times            
            DateTime lastWriteTime2 = fileInfo2.LastWriteTime;


            // UTC times            
            //DateTime lastWriteTimeUtc2 = fileInfo2.LastWriteTimeUtc;


            //Console.WriteLine("\n Arquivo 1: " + lastWriteTime1);
            //Console.WriteLine("\n Arquivo 2: " + lastWriteTime2);

            if (lastWriteTime1 == lastWriteTime2)
            {
                return true;
            }
            return false;
        }

        public bool isEquals(string arquivoOrigem, string arquivoDestino)
        {
            if (this.FileCompareTamanho(arquivoOrigem, arquivoDestino) == true) &&
            (this.FileCompareConteudo(arquivoOrigem, arquivoDestino) == true) &&
            (this.FileCompareDateLastWrite(arquivoOrigem, arquivoDestino) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
