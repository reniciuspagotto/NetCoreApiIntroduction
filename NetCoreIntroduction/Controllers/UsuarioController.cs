using Microsoft.AspNetCore.Mvc;
using NetCoreIntroduction.Context;
using NetCoreIntroduction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreIntroduction.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _ctx;

        public UsuarioController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public void Salvar(Usuario usuario)
        {
            _ctx.Usuarios.Add(usuario);
            _ctx.SaveChanges();
        }

        [HttpPut]
        public void Atualizar(Usuario usuario)
        {
            _ctx.Usuarios.Update(usuario);
            _ctx.SaveChanges();
        }

        [HttpGet]
        public object Obter()
        {
            var sd = _ctx.Usuarios.ToList();
            return sd;
        }

        [HttpGet("{id}")]
        public object Obter(string id)
        {
            var sd = _ctx.Usuarios.FirstOrDefault(p => p.Id == Guid.Parse(id));
            return sd;
        }
    }
}
