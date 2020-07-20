using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CepAPI.DAL
{
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer
    //Install-Package Microsoft.EntityFrameworkCore.Tools
    //Code First
    //Add-Migration InitialCreate
    //Update-Database
    public class CepApiContext : DbContext
    {
        public DbSet<CEP> Ceps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Integrated Security=true;Initial Catalog=CepApi;");
            }
        }
    }

    public class CEP
    {
        [JsonPropertyName("enderecoId")]
        public int ID { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; }

        public void Alterar(string cep, string logradouro, string complemento, string bairro, string uf)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.UF = uf;
        }
    }
}
