using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;
using webapi.eventplus.Repositories;
using webapi.eventplus.ViewModel;

namespace webapi.eventplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModels usuario)
        {
            try
            {
                Usuario user = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);



                if (user == null)
                {
                    return StatusCode(404);
                }

                //Caso encontre prossegue para a criacao do token

                //Parte 1: Definir informacoes(Claims) que serao fornecidas no token(Payload)

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, user.Nome!),
                    new Claim(ClaimTypes.Role, user.TiposUsuario!.Titulo!),

                    //Existe a possibilidade de criar uma claim personalizada

                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                //Parte 2: Definir chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Jogos-chave-autenticacao-webapi-dev"));

                //Parte 3: Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Parte 4: Gerar token

                var token = new JwtSecurityToken
                (
                    //emissor do token 
                    issuer: "webapi.eventplus",

                    //Destinatario do token
                    audience: "webapi.eventplus",

                    //Dados definidos nas claims(informacoes)
                    claims: claims,

                    //Tempo de expiracao
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //Parte 5: Retornar um token 

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

            

            
        }
    }
}
