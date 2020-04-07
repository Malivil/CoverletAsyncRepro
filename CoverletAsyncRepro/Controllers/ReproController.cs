using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoverletAsyncRepro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReproController : ControllerBase
    {
        private string ThisPropertyShouldBeIgnored { get; set; }

        /// <summary>
        /// Processes the specified capture file.
        /// </summary>
        /// <param name="file">The file.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await AsyncWait(100);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        private static async Task AsyncWait(int iterations)
        {
            await Task.Delay(iterations);
        }

        private static void ThisMethodIsNotUsed()
        {
            // But must be here to generate coverage for this class at all
        }
    }
}
