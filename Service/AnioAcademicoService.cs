using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
namespace Service
{
    class AnioAcademicoService : IAnioAcademicoService
    {
        private IAñoAcademicoRepository _anioRepository;
        public AnioAcademicoService()
        {
            if (_anioRepository==null)
            {
                _anioRepository = new AnioAcademicoRepository();
            }
        }

        public void AddAnioAcademico(AnioAcademico anioAcademico)
        {
            _anioRepository.AddAnioAcademico(anioAcademico);
        }

        public void DeleteAnioAcademico(int anioAcademico)
        {
            _anioRepository.DeleteAnioAcademico(anioAcademico);
        }

        public AnioAcademico GetAnioAcademico(int id)
        {
            return _anioRepository.GetAnioAcademico(id);
        }

        public IEnumerable<AnioAcademico> GetAnioAcademicos(string criterio)
        {
            return _anioRepository.GetAnioAcademicos(criterio);
        }

        public void UpdateAnioAcademico(AnioAcademico aniAcademico)
        {
            _anioRepository.UpdateAnioAcademico(aniAcademico);
        }
    }
}
