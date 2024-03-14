using GaB_Auth.DbConnector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaB_Auth.Controllers.SystemControllerModels;

namespace GaB_Auth.Controllers
{
    /// <summary>
    /// Котроллер проверки работы системы
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// Получить миграции защищенной базы данных
        /// </summary>
        [HttpGet("GetDBMigrations")]
        public IEnumerable<string> GetProtectedDBMigrations()
        {
            return Program.GetContext().Database.GetMigrations();
        }

        /// <summary>
        /// Получить статус системы
        /// </summary>
        [HttpGet("Status")]
        public async Task<Status> Status()
        {
            return new Status {
                DateTime = new DateTime(),
                Version = typeof(Program).Assembly.GetName().Version.ToString(),
                DBVersion = Program.GetContext().Database.GetMigrations().ToList()[^1],
                CoreStatusResponse = await GetStatusCodeRequestCoreStatus()
            };
        }

        private async Task<string> GetStatusCodeRequestCoreStatus()
        {
            using (var client = new HttpClient(new HttpClientHandler(), false))
            {
                using var result = await client.GetAsync(Program.Configuration.GetValue<string>("CoreURL").TrimEnd('/').TrimEnd() + "/System/Status");
                return result.StatusCode.ToString();
            }
        }
    }
}
