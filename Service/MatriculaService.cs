using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
namespace Service
{
    public class MatriculaService : IMatriculaService
    {
        private IMatriculaRepository _matriculaRepository;
        public MatriculaService()
        {
            if (_matriculaRepository==null)
            {
                _matriculaRepository = new MatriculaRepository();
            }
        }
        public void AddMatricula(Matricula matricula)
        {
            _matriculaRepository.AddMatricula(matricula);
        }

        public void DeleteMatricula(int matricula)
        {
            _matriculaRepository.DeleteMatricula(matricula);
        }

        public IEnumerable<Alumno> GetAlumnos(int seccionId)
        {
            return _matriculaRepository.GetAlumnos(seccionId);

        }

        

        public Matricula GetMatricula(int? id)
        {
            return _matriculaRepository.GetMatricula(id);
        }

        public IEnumerable<Matricula> GetMatriculas(string criterio)
        {
            return _matriculaRepository.GetMatriculas(criterio);
        }

        public void UpdateMatricula(Matricula matricula)
        {
            _matriculaRepository.UpdateMatricula(matricula);
        }
    }
}
