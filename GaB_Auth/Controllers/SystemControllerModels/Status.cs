namespace GaB_Auth.Controllers.SystemControllerModels
{
    /// <summary>
    /// Статус системы
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Текущее время на машине
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Версия Auth
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Возможность подключения к базе данных
        /// </summary>
        public string DBVersion { get; set; }

        /// <summary>
        /// Возможность подключения к базе данных
        /// </summary>
        public string CoreStatusResponse { get; set; }
    }
}
