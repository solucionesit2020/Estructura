using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaz
{
    public interface IEstudianteService
    {
        IEnumerable<EstudianteModel> GetAllEstudiantes();
        EstudianteModel GetByIdEstudiante(int id);
        void AddEdditEstudiante(bool id, EstudianteModel estudiante);
        void DeleteEstudiante(int id);
    }
}
