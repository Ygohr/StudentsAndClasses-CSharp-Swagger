using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DesafioTecnicoMarlin.Model;
using DesafioTecnicoMarlin.Context;
using DesafioTecnicoMarlin.Services;

namespace DesafioTecnicoMarlin.Controller
{
   
    public class LoginController : ControllerBase
    {
        private readonly DesafioContext _DesafioContext;

        public LoginController(DesafioContext DesafioContext)
        {
            _DesafioContext = DesafioContext;
        }
        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Login login)
        {
            var user = _DesafioContext.t_Login.SingleOrDefault(l => l.login == login.login);

            if (user == null)
            {
                return BadRequest(new { message = "O login utilizado não foi encontrado" });
            }

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
