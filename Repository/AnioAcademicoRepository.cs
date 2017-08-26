using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class AnioAcademicoRepository : MasterRepository, IAñoAcademicoRepository
    {
        public void AddAnioAcademico(AnioAcademico anioAcademico)
        {
            Context.anioAcademicos.Add(anioAcademico);
            Context.SaveChanges();
        }

        public void DeleteAnioAcademico(int anioAcademico)
        {

            var anio = Context.anioAcademicos.Find(anioAcademico);
            if (anio != null)
            {
                Context.anioAcademicos.Remove(anio);
                Context.SaveChanges();
            }


        }

        public AnioAcademico GetAnioAcademico(int? id)
        {
            return Context.anioAcademicos.Find(id);
        }

        public IEnumerable<AnioAcademico> GetAnioAcademicos(string criterio)
        {
            var query = from p in Context.anioAcademicos
                        select p;

            if (!string.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where
                              p.Anio.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }
            return query;
        }

        public void UpdateAnioAcademico(AnioAcademico aniAcademico)
        {
            Context.Entry(aniAcademico).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
