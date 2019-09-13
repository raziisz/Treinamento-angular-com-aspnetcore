using System.Collections.Generic;
using Project.Api.Models;

namespace Project.Api.Data
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
    Usuario Obter(string email, string senha);
    }
}