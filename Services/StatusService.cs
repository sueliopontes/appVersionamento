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
    public class StatusService    
    {       
       
        public List<ArquivoModel> GetArquivos()
        {
            List<ArquivoModel> _arquivos = new List<ArquivoModel>();        

            _arquivos.Add(new ArquivoModel() { Nome = "Item1" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item2" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item3" });
            _arquivos.Add(new ArquivoModel() { Nome = "Item4" });

            return _arquivos;
        }

        private DateTime GetArquivoDateCreate(string arquivo)
        {
            FileInfo fileInfo1 = new FileInfo(arquivo); 
            DateTime creationTime1 = fileInfo1.CreationTime;                               

            return creationTime1;
        }

        private DateTime GetArquivoDateUpdate(string arquivo)
        {
            FileInfo fileInfo1 = new FileInfo(arquivo);             
            DateTime lastWriteTime1 = fileInfo1.LastWriteTime;
            
            return lastWriteTime1;
        }

        private long GetArquivoTamanho(string arquivo)
        {
            FileStream fs = new FileStream(arquivo, FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            long tamanho=fs.Length;
            fs.Close();
            
            return tamanho;
        }

        private String isExistArquivo(string arquivo,string local)
        {
           string nome = Path.GetFileName(arquivo.ToString());
           string caminhoCompleto =  Path.Combine(local,nome);

           if (File.Exists(caminhoCompleto)){               
               return caminhoCompleto;
           }
           else{
               return null;
           }
        }

         private List<string> CarregarListaArquivos(List<AmbienteModel> ambientes)
        {
           
            List<string> arquivos = new List<string>();

            List<string> arquivosSource = new List<string>();

            foreach(AmbienteModel ambiente in ambientes)
            {
                arquivosSource = Directory.GetFiles(ambiente.Localizacao).ToList();    

                foreach(string arquivo in arquivosSource)
                {
                    if (!arquivos.Contains(arquivo))
                    {
                        arquivos.Add(arquivo);
                    }           
                }
                arquivosSource.DefaultIfEmpty();
            }
            
           return arquivos;           
        }


        public List<ArquivoModel> GetArquivosFisico()
        {
            List<AmbienteModel> ambientes = new List<AmbienteModel>();

            ambientes.Add(new AmbienteModel() { Id= 1,Ambiente="Prod",Localizacao = @"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao"});

            ambientes.Add(new AmbienteModel() { Id= 1,Ambiente="Dev",Localizacao = @"C:\Users\Douglas\Desktop\Versionamento\Dev"});

            List<string> arquivos = CarregarListaArquivos(ambientes);            

            List<ArquivoModel> 
            

            

            ComparadorService comparador = new ComparadorService();

            foreach(string arquivo in arquivosDestino)
            {
                ArquivoModel arquivoModel = new ArquivoModel();

                //arquivoModel.Id=1;               

                arquivoModel.Nome=arquivo;
                arquivoModel.Tamanho=this.GetArquivoTamanho(arquivo);
                arquivoModel.DateCreate=this.GetArquivoDateCreate(arquivo);
                arquivoModel.DateUpdate=this.GetArquivoDateUpdate(arquivo);
                if (this.isExistArquivo(arquivo,localOrigem) != null){
                    arquivoModel.Status= comparador.isEquals(arquivo,this.isExistArquivo(arquivo,localOrigem));
                }
                else{
                    arquivoModel.Status= false;
                }                
                arquivoList.Add(arquivoModel);            }            

            return arquivoList;
        }
    }

}