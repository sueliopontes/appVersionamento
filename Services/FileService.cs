using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaVersionamento.Services
{
    class FileService
    {
        public List<string> Visualizar()
        {
            string local1 = @"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao";
            string local2 = @"C:\Users\Douglas\Desktop\Versionamento\Dev";
            string local3 = @"C:\Users\Douglas\Desktop\Versionamento\QA";
            string local4 = @"C:\Users\Douglas\Desktop\Versionamento\PP";
            string local5 = @"C:\Users\Douglas\Desktop\Versionamento\Prod";

            List<string> arquivos1 = Directory.GetFiles(local1).ToList();
            //List<string> arquivos2 = Directory.GetFiles(local2).ToList();
            //List<string> arquivos3 = Directory.GetFiles(local3).ToList();
            //List<string> arquivos4 = Directory.GetFiles(local4).ToList();
            //List<string> arquivos5 = Directory.GetFiles(local5).ToList();

            return arquivos1;
        }


       
    }
}
