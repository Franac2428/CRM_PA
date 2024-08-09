using System.Collections.Generic;
using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json;

namespace CRM.Helpers.Interfaces
{
    public class MovimientoHelper : IMovimientosHelper
    {
        IServiceRepository ServiceRepository;

        public MovimientoHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }

        public MovimientosViewModel Convertir(MovimientosModel movimientos)
        {
            return new MovimientosViewModel
            {
                IdMovimiento = movimientos.IdMovimiento,
                IdTipoMovimiento = movimientos.IdTipoMovimiento,
                IdEstadoMovimiento = movimientos.IdEstadoMovimiento,
                Monto = movimientos.Monto,
                FechaCreacion = movimientos.FechaCreacion,
                IdUsuarioCreacion = movimientos.IdUsuarioCreacion,
                FechaModificacion = movimientos.FechaModificacion,
                IdUsuarioModificacion = movimientos.IdUsuarioModificacion,
                Comentario = movimientos.Comentario,
                Imagen = movimientos.Imagen
            };
        }

        public MovimientosModel Convertir(MovimientosViewModel movimientos)
        {
            return new MovimientosModel
            {
                IdMovimiento = movimientos.IdMovimiento,
                IdTipoMovimiento = movimientos.IdTipoMovimiento,
                IdEstadoMovimiento = movimientos.IdEstadoMovimiento,
                Monto = movimientos.Monto,
                FechaCreacion = movimientos.FechaCreacion,
                IdUsuarioCreacion = movimientos.IdUsuarioCreacion,
                FechaModificacion = movimientos.FechaModificacion,
                IdUsuarioModificacion = movimientos.IdUsuarioModificacion,
                Comentario = movimientos.Comentario,
                Imagen = movimientos.Imagen
            };
        }

        public MovimientosViewModel AddSalEnt(MovimientosViewModel movimientos)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/movimiento", Convertir(movimientos));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new MovimientosViewModel();
        }

        public MovimientosViewModel GetMovimientoByID(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/movimiento/{id}");
            MovimientosModel result = new MovimientosModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<MovimientosModel>(content);
                return Convertir(result);
            }
            else
            {
                return new MovimientosViewModel();
            }
        }

        public List<MovimientosViewModel> GetMovimientos()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/movimiento");
            List<MovimientosViewModel> listado = new List<MovimientosViewModel>();
            List<MovimientosModel> result = new List<MovimientosModel>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<MovimientosModel>>(content);
            }

            foreach (var item in result)
            {
                listado.Add(Convertir(item));
            }

            return listado;
        }

        public MovimientosViewModel UpdateMovimiento(MovimientosViewModel movimientos)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/movimiento/{movimientos.IdMovimiento}", Convertir(movimientos));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new MovimientosViewModel();
        }

        public List<TipoEstadoMovimiento> GetTipoEstado()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/EstadoMovimiento");
            List<TipoEstadoMovimiento> result = new List<TipoEstadoMovimiento>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<TipoEstadoMovimiento>>(content);
                return result;
            }
            else
            {
                return new List<TipoEstadoMovimiento>();
            }
        }
    }
}
