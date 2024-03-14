using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static GaB_Auth.Controllers.Example;

namespace GaB_Auth.Controllers
{
    /// <summary>
    /// Контроллер аутентификации клиента
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="phoneNumber">Телефонный номер в виде числа</param>
        /// <param name="regionCodeId">Id регионального кода</param>
        /// <response code="200"></response>
        /// <response code="423"></response>
        [HttpGet("RequestForAuthentication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Nullable), 423)]
        public async Task<Guid?> RequestForAuthentication(Int16 regionCodeId, long phoneNumber)
        {
            //TODO пока тут просто заглушка
            using (var client = new HttpClient(new HttpClientHandler(), false))
            {
                using var result = await client.GetAsync(Program.Configuration.GetValue<string>("CoreURL").TrimEnd('/').TrimEnd() + $"/Auth/GetClientId?regionCodeId={regionCodeId}&phoneNumber={phoneNumber}");
                var strGuid = JsonConvert.DeserializeObject<string>(await result.Content.ReadAsStringAsync());
                Console.WriteLine(strGuid);
                return Guid.Parse(strGuid);
            }
        }
    }
}
