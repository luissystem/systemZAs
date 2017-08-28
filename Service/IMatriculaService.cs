using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
  public  interface IMatriculaService
    {
        IEnumerable<Matricula> GetMatriculas(string criterio);

        Matricula GetMatricula(Int32? id);

        void AddMatricula(Matricula matricula);

        void UpdateMatricula(Matricula matricula);

        void DeleteMatricula(Int32 matricula);

        IEnumerable<Alumno> GetAlumnos(Int32 seccionId);

        //IEnumerable<Alumno> GetAlumnosNotas(Int32 seccionId, Int32 cursoId);

    }
}
