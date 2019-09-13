using System;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Data;
using Project.Api.Models;

namespace Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _repo;

        public UsuariosController(IUsuarioRepository repo)
        {
            _repo = repo;

        }
        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario(Usuario u)
        {
            try
            {
                var usuarioReturn = _repo.Obter(u.Email, u.Senha);
                if (usuarioReturn != null)
                    return Ok(usuarioReturn);

                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}