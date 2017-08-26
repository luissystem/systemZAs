﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public  interface IAñoAcademicoRepository
    {

        IEnumerable<AnioAcademico> GetAnioAcademicos(String criterio);

        AnioAcademico GetAnioAcademico(Int32? id);

        void AddAnioAcademico(AnioAcademico anioAcademico);

        void UpdateAnioAcademico(AnioAcademico aniAcademico);

        void DeleteAnioAcademico(Int32 anioAcademico);

    }
}
