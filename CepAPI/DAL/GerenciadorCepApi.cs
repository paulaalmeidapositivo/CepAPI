using System.Collections.Generic;
using System.Linq;

namespace CepAPI.DAL
{
    public class GerenciadorCepApi
    {
        public List<CEP> Listar()
        {
            List<CEP> ceps = null;
            using (var db = new CepApiContext())
            {
                ceps = db.Ceps.ToList();
            }

            return ceps;
        }

        public CEP Listar(string cepConsultar)
        {
            CEP cep = null;
            using (var db = new CepApiContext())
            {
                cep = db.Ceps.Where(x => x.Cep.Equals(cepConsultar)).FirstOrDefault();
            }

            return cep;
        }

        public CEP Cadastrar(CEP novo)
        {
            using (var db = new CepApiContext())
            {
                db.Add(novo);
                db.SaveChanges();
            }

            return novo;
        }

        public CEP Alterar(CEP alterar)
        {
            CEP cep = null;

            using (var db = new CepApiContext())
            {
                cep = db.Ceps.Where(x => x.ID == alterar.ID).FirstOrDefault();
                if (cep != null)
                {
                    cep.Alterar(alterar.Cep, alterar.Logradouro, alterar.Complemento, alterar.Bairro, alterar.UF);
                    db.Update(cep);
                    db.SaveChanges();
                }

            }

            return cep;
        }

        public void Deletar(int id)
        {
            using (var db = new CepApiContext())
            {
                CEP cep = db.Ceps.Where(x => x.ID == id).FirstOrDefault();
                if (cep != null)
                {
                    db.Remove(cep);
                    db.SaveChanges();
                }
            }
        }
    }
}
