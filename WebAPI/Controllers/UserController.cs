using Core.Business;
using Core.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Authorize("Bearer")]
    [Authorize(AuthenticationSchemes = "CustomAuth")]
    [Route("[controller]")]
    [Tags("Utilizadores")]
    [ApiController]
    public class UserController(IUserBusiness userBusiness) : ControllerBase
    {
        private readonly IUserBusiness _userBusiness = userBusiness;

        /// <summary>
        /// Buscar Perfis
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        [HttpGet("Profiles")]
        [SwaggerResponse(200, "Informações", typeof(List<ProfileDto>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        [EnableQuery]
        public async Task<IActionResult> GetAllProfilesAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetAllProfilesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | GetAllProfilesAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar Utilizadores
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(200, "Informações", typeof(List<UserDto>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        [EnableQuery]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | GetAllAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar Utilizador Por Id
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="id">Id do Utilizador</param> 
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Informações", typeof(UserDto))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        [EnableQuery]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                return Ok(await _userBusiness.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | GetAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Criar Utilizador
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="model">Modelo de Criar Utilizador</param>         
        [HttpPost]
        [SwaggerResponse(200, "Informações", typeof(UserDto))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto model)
        {
            try
            {
                return Ok(await _userBusiness.CreateAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | CreateAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Atualizar Utilizador
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="model">Modelo de Atualizar Utilizador</param>         
        [HttpPut]
        [SwaggerResponse(200, "Informações", typeof(UserDto))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateDto model)
        {
            try
            {
                return Ok(await _userBusiness.UpdateAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | UpdateAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Deletar Utilizador
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="islogical">Exclusão lógica</param> 
        /// <param name="id">Id do Utilizador</param>         
        [HttpDelete("{islogical}/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteAsync([FromRoute] bool islogical, int id)
        {
            try
            {
                await _userBusiness.DeleteAsync(islogical, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | DeleteAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Lixo
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        [HttpGet("Trash")]
        [SwaggerResponse(200, "Informações", typeof(List<UserDto>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        [EnableQuery]
        public async Task<IActionResult> GetAllTrashAsync()
        {
            try
            {
                return Ok(await _userBusiness.GetAllTrashAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | GetAllTrashAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Restaurar Lixo
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="id">Id do Utilizador</param>         
        [HttpPut("RestoreTrash/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> RestoreTrashAsync([FromRoute] int id)
        {
            try
            {
                await _userBusiness.RestoreTrashAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | RestoreTrashAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Atualizar Foto do Utilizador
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="model">Modelo de Atualizar Foto</param> 
        [HttpPut("Photo")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> UpdatePhotoAsync([FromBody] UserPhotoUpdateDto model)
        {
            try
            {
                await _userBusiness.UpdatePhotoAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | UpdatePhotoAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Atualizar Senha do Utilizador
        /// </summary>
        /// <remarks>
        /// Antes de chamar este método, é necessário autenticar o usuário e obter um token de autenticação válido.
        /// 
        /// Para fazer isso, faça uma chamada POST para o endpoint `/Auth/SignIn` com as credenciais do usuário.
        /// 
        /// O token de autenticação deve ser fornecido no cabeçalho da solicitação usando o esquema Bearer.
        /// 
        /// Certifique-se de incluir o cabeçalho `Authorization: Bearer {token}` nesta solicitação.
        /// 
        /// Ou
        /// 
        /// Certifique-se de incluir o cabeçalho `Token: {token}` nesta solicitação. 
        /// 
        /// Somente usuários autenticados terão permissão para acessar este endpoint.
        /// </remarks>
        /// <param name="model">Modelo de Atualizar Senha</param> 
        [HttpPut("Password")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UserPasswordUpdateDto model)
        {
            try
            {
                await _userBusiness.UpdatePasswordAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"UserController | UpdatePasswordAsync | {ex.Message}");
            }
        }
    }
}
