using System.Collections.Generic;
using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json;

namespace CRM.Helpers.Implementations
{
    public class MovimientoHelper : IMovimientosHelper
    {
        IServiceRepository ServiceRepository;

        public MovimientoHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        MovimientosViewModel Convertir(MovimientosModel movimientos)
        {
            return new MovimientosViewModel
            {
                IdMovimiento = movimientos.IdMovimiento,
                IdTipoMovimiento = movimientos.IdTipoMovimiento,
                IdEstadoMovimiento = movimientos.IdEstadoMovimiento,
                Monto = movimientos.Monto,
                Comentario = movimientos.Comentario
            };
        }

        MovimientosModel Convertir(MovimientosViewModel movimientos)
        {
            return new MovimientosModel
            {
                IdMovimiento = movimientos.IdMovimiento,
                IdTipoMovimiento = movimientos.IdTipoMovimiento,
                IdEstadoMovimiento = movimientos.IdEstadoMovimiento,
                Monto = movimientos.Monto,
                Comentario = movimientos.Comentario
            };
        }

        public MovimientosViewModel AddSalEnt(MovimientosViewModel movimientos)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/Movimiento", Convertir(movimientos));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new MovimientosViewModel();
        }

        public MovimientosViewModel GetMovimientoByID(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/Movimiento/{id}");
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

        public MovimientosViewModel Update(MovimientosViewModel movimientoss)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/Movimiento/{movimientoss.IdMovimiento}", Convertir(movimientoss));

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
