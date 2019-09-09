using Core.Entidades;
using Core.Estructura;
using Core.Interfaces;
using Modelo;
using Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;

namespace Repositorio.Clases
{
    public class EstudianteRep: IEstudianteRep
    {
        private  IUnitOfWork _uow;
        private Repository<Estudiante> _studtRepository;
        public EstudianteRep(IUnitOfWork uow)
        {
            _uow = uow;
            _studtRepository = _uow.Repository<Estudiante>();
           // Mapper.Initialize(cfg => cfg.CreateMap(typeof(EstudianteModel), typeof(Estudiante)));
        }

        public IEnumerable<EstudianteModel> GetAllEstudiantes()
        {
            var estudiantes = _studtRepository.Table.AsEnumerable().Select(s => new EstudianteModel
            {
                Id = s.Id,
                NombreCompleto = $"{s.PrimerNombre} {s.PrimerApellido}",
                Email = s.Email,
                NoIdentificacion = s.NoIdentificacion
            });

            return estudiantes;
        }

        public EstudianteModel GetAById(int id)
        {
            var est = _studtRepository.GetById(id);
            var model = new EstudianteModel
            {
                PrimerNombre     = est.PrimerNombre,
                PrimerApellido   = est.PrimerApellido,
                Email            = est.Email,
                NoIdentificacion = est.NoIdentificacion
            };
            return model;
        }

        public void AddEdditEstudiante(bool isnew,EstudianteModel estudiante)
        {
            var model = new Estudiante { PrimerNombre     = estudiante.PrimerNombre,
                                         PrimerApellido   = estudiante.PrimerApellido,
                                         Email            = estudiante.Email,
                                         NoIdentificacion = estudiante.NoIdentificacion
                                       };
            if (isnew)
            {
                model.AddedDate = DateTime.UtcNow;
                model.ModifiedDate = DateTime.UtcNow;
                _studtRepository.Insert(model);
            }
            else
            {
                var upestudiante              = _studtRepository.GetById((int)estudiante.Id);
                upestudiante.ModifiedDate     = DateTime.UtcNow;
                upestudiante.PrimerNombre     = estudiante.PrimerNombre;
                upestudiante.PrimerApellido   = estudiante.PrimerApellido;
                upestudiante.Email            = estudiante.Email;
                upestudiante.NoIdentificacion = estudiante.NoIdentificacion;
                _studtRepository.Update(upestudiante);
            }
        }

        public void DeleteEstudiante(int id)
        {
            var estudiante = _studtRepository.GetById(id);
            _studtRepository.Delete(estudiante);
        }
    }
}
