using BD;
using Entity;
using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPuestoService
    {
        Task<DBEntity> Create(PuestosEntity entity);
        Task<DBEntity> Delete(PuestosEntity entity);
        Task<IEnumerable<PuestosEntity>> Get();
        Task<PuestosEntity> GetById(PuestosEntity entity);
        Task<DBEntity> Update(PuestosEntity entity);
    }

    public class PuestoService : IPuestoService
    {
        private readonly IDataAccess sql;
        public PuestoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<PuestosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PuestosEntity>("PuestosObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PuestosEntity> GetById(PuestosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestosEntity>("PuestosObtener", new
                {
                    entity.Id_Puesto
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Create(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosInsertar", new
                {
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosActualizar", new
                {
                    entity.Id_Puesto,
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                }
                );
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<DBEntity> Delete(PuestosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PuestosEliminar", new
                {
                    entity.Id_Puesto
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}