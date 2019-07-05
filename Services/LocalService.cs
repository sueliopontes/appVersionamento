using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaVersionamento.Context;
using SignaVersionamento.Models;

namespace SignaVersionamento.Services
{
    public class LocalService
    {
        private readonly LocalContext _context;

        /*
        public  LocalController(LocalContext context)
        {
          
            _context = context;

            if (_context.Local.Count() == 0)
            {                
                _context.Local.Add(new LocalModel { Id=1,Ambiente = "PacotesVersao",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=2,Ambiente = "Dev",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\Dev"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=3,Ambiente = "QA",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\QA"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=4,Ambiente = "PP",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\PP"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=5,Ambiente = "Prod",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\Prod"});
                _context.SaveChanges();
            }
          
        } 
        */       
    
    }

}