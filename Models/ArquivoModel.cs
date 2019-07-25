using System;


namespace SignaVersionamento.Models
{
    public class ArquivoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public long Tamanho { get; set; }        
        public bool Status { get; set; }
        public LocalModel Local { get; set; }
    }
}