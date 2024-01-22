using Microsoft.AspNetCore.Mvc;

namespace GaB_Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Example : ControllerBase
    {
        public class Product
        {
            /// <summary>
            /// The name of the product
            /// </summary>
            /// <example>Men's basketball shoes</example>
            public string Name { get; set; }

            /// <summary>
            /// Quantity left in stock
            /// </summary>
            /// <example>10</example>
            public int AvailableStock { get; set; }

            /// <summary>
            /// The sizes the product is available in
            /// </summary>
            /// <example>["Small", "Medium", "Large"]</example>
            public List<string> Sizes { get; set; }
        }

        /// <summary>
        /// Рандомайзер погоды
        /// </summary>
        /// <param name="id">Рандомный параметр</param>
        /// <returns>
        /// Погода в Перми
        /// </returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(int id)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <response code="200">Product retrieved</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Oops! Can't lookup your product right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public Product GetById(int id) { return new Product(); }

        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Example> _logger;

        public Example(ILogger<Example> logger)
        {
            _logger = logger;
        }
        public class WeatherForecast
        {
            public DateOnly Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string? Summary { get; set; }
        }
    }
}
