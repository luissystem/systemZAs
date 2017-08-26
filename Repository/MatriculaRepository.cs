using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace Repository
{
    public class MatriculaRepository : MasterRepository, IMatriculaRepository
    {
        public void AddMatricula(Matricula matricula)
        {
            Context.matriculas.Add(matricula);
            Context.SaveChanges();
        }

        public void DeleteMatricula(int matricula)
        {
            var mat = Context.matriculas.Find(matricula);

            if (mat != null)
            {
                Context.matriculas.Remove(mat);
                Context.SaveChanges();
            }

        }

        public IEnumerable<Alumno> GetAlumnos(int seccionId)
        {

            var actual = DateTime.Now.Year;
            var matriculados = from a in Context.matriculas.Include("AnioAcademico")
                               where a.SeccionId.Equals(seccionId) && a.AnioAcademico.Anio.Equals(actual.ToString())
                               select a.AlumnoId;

            var alumnos = from a in Context.alumnos
                          where matriculados.Contains(a.AlumnoId)
                          select a;

            return alumnos;

        }

        public IEnumerable<Alumno> GetAlumnosNotas(int seccionId, int cursoId)
        {
            var matriculados = from a in Context.matriculas
                               where a.SeccionId.Equals(seccionId)
                               select a.AlumnoId;

            var alumnos = from a in Context.alumnos
                          where matriculados.Contains(a.AlumnoId)
                          select a;

            return alumnos;

        }

        public Matricula GetMatricula(int? id)
        {
            return Context.matriculas.Find(id);
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio)
        {
            var query = from c in Context.matriculas.Include("Alumno").Include("Apoderado")
                      .Include("Seccion").Include("Seccion.Grado").Include("Seccion.Grado.Nivel").Include("AnioAcademico")
                        select c;

            if (!string.IsNullOrEmpty(criterio))
            {
                query = from c in query.Include("Alumno").Include("Apoderado")
                        .Include("Seccion").Include("Seccion.Grado").Include("Seccion.Grado.Nivel").Include("AnioAcademico")
                        where c.Alumno.Nombres.ToUpper().Contains(criterio.ToUpper()) || c.Alumno.Apellidos.ToUpper().Contains(criterio.ToUpper()) ||
                              
                              (c.Alumno.Nombres + " " + c.Alumno.Apellidos ).ToUpper().Contains(criterio.ToUpper())
                        select c;
            }

            return query;

        }

        public void UpdateMatricula(Matricula matricula)
        {
            Context.Entry(matricula).State = EntityState.Modified;
            Context.SaveChanges();

        }
    }
}
