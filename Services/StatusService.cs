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

         private ArquivoModel CompararArquivoAmbiente(string arquivo,ArquivoModel arquivoModel, List<AmbienteModel> ambientes,int ambienteRef)
        {
            string ambienteRef = ambientes(x=> x.id=ambienteRef).ambiente.ToString();
            
            foreach (AmbienteModel ambiente in ambientes){





           }
            
            
           return arquivos;           
        }




        public List<ArquivoModel> GetArquivosFisico()
        {
            List<AmbienteModel> ambientes = new List<AmbienteModel>();

            ambientes.Add(new AmbienteModel() { Id= 1,Ambiente="Prod",Localizacao = @"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao"});

            ambientes.Add(new AmbienteModel() { Id= 1,Ambiente="Dev",Localizacao = @"C:\Users\Douglas\Desktop\Versionamento\Dev"});

            List<string> arquivos = CarregarListaArquivos(ambientes);            

            List<ArquivoModel> arquivoList = new List<ArquivoModel>();

            ComparadorService comparador = new ComparadorService();

            int contador=1;

            foreach(string arquivo in arquivos)
            {
                ArquivoModel arquivoModel = new ArquivoModel();

                arquivoModel.Id=contadsor;               
                arquivoModel.Nome=arquivo;
                arquivoModel= this.CompararAquivoAmbiente(arquivo,arquivoModel,ambientes);                
                arquivoList.Add(arquivoModel);            }            

                comparador ++;
            }

            return arquivoList;
        }
    }

}