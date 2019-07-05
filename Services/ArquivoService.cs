using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaVersionamento.Models;


namespace SignaVersionamento.Services
{
    public class ArquivoService    
    {       
        public string LocalOrigem {get;set};
        public string LlocalDestino {get;set};

        public List<ArquivoModel> GetArquivos()
        {
            List<ArquivoModel> _arquivos = new List<ArquivoModel>();        

            _arquivos.Add(new ArquivoModel() { Nome = "Item1" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item2" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item3" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item4" });

            return _arquivos;
        }

        public List<ArquivoModel> GetArquivosFisico()
        {
            string localOrigem = @"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao";
            string localDestino = @"C:\Users\Douglas\Desktop\Versionamento\Dev";

            List<string> arquivosOrigem = Directory.GetFiles(localOrigem).ToList();    
            List<string> arquivosDestino = Directory.GetFiles(localDestino).ToList();    

            List<ArquivoModel> arquivoList = new List<ArquivoModel>();               

            Comparador comparador = new Comparador();

            foreach(string arquivo in arquivosDestino)
            {
                //if 
                FileInfo fileInfo1 = new FileInfo(arquivo); 
                DateTime creationTime1 = fileInfo1.CreationTime;       
                DateTime lastWriteTime1 = fileInfo1.LastWriteTime;
                FileStream fs1 = new FileStream(arquivo, FileMode.Open);

                ArquivoModel arquivoModel = new ArquivoModel();

                //arquivoModel.Id=1;
                arquivoModel.Nome=arquivo;
                arquivoModel.Tamanho=fs1.Length;
                arquivoModel.DateCreate=creationTime1;
                arquivoModel.DateUpdate=lastWriteTime1;
                arquivoModel.Status= comparador.isEquals(localOrigem,localDestino);
                arquivoList.Add(arquivoModel);
            }            

            return arquivoList;
        }
    }

}