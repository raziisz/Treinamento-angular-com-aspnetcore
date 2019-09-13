using System;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Data;
using Project.Api.Models;

namespace Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repo;
        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Adicionar(Produto p) 
        {
            if (p == null)
                BadRequest("Você deve criar um produto");
            
            _repo.Adicionar(p);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetProdutos()
        {
            try
            {
                var produtos = _repo.ObterTodos();
                return Ok(produtos);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}