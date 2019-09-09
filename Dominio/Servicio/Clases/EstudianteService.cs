using Core.Interfaces;
using Modelo;
using Servicio.Generico;
using Servicio.Interfaz;
using System.Collections.Generic;

namespace Servicio.Clases
{
    public class EstudianteService : Service, IEstudianteService
    {
        public EstudianteService(IUnitOfWork uow):base(uow) { }
        public IEnumerable<EstudianteModel> GetAllEstudiantes()
        {
            return _IEstud.GetAllEstudiantes();
        }
        public EstudianteModel GetByIdEstudiante(int id)
        {
            return _IEstud.GetAById(id);
        }
        public void AddEdditEstudiante(bool newid, EstudianteModel estudiante)
        {
            _IEstud.AddEdditEstudiante(newid, estudiante);
        }
        public void DeleteEstudiante(int id)
        {
            _IEstud.DeleteEstudiante(id);
        }
    }
}
