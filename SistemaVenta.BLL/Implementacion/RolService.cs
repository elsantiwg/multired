﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multired.BLL.Interfaces;
using Multired.DAL.Interfaces;
using SistemaVenta.Entity;

namespace Multired.BLL.Implementacion
{
    public class RolService : IRolService
    {

        private readonly IGerenericRepository<Rol> _repositorio;

        public RolService(IGerenericRepository<Rol> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Rol>> Lista()
        {
            
            IQueryable<Rol> query = await _repositorio.Consultar();

            return query.ToList();
        }
    }
}