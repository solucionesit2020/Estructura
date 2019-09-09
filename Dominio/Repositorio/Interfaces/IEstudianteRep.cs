using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IEstudianteRep
    {
        IEnumerable<EstudianteModel> GetAllEstudiantes();
        EstudianteModel GetAById(int id);
        void AddEdditEstudiante(bool id, EstudianteModel estudiante);
        void DeleteEstudiante(int id);
    }
}
