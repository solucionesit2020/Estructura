using Core.Interfaces;
using Repositorio.Clases;
using Repositorio.Interfaces;

namespace Servicio.Generico
{
    public abstract class Service
    {
        protected IEstudianteRep _EstService;
        protected IUnitOfWork _uow;

        public Service(IUnitOfWork uow)
        {
            _uow = uow;
        }
        protected IEstudianteRep _IEstud
                  => _EstService ?? (_EstService = new EstudianteRep(_uow));
    }
}

