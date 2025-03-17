using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Models;

namespace RubiksCubeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubiksCubeController : ControllerBase
    {
        private static RubiksCube _cube = new RubiksCube();

        [HttpGet("state")]
        public IActionResult GetCubeState()
        {
            return Ok(_cube.GetCubeState());
        }

        [HttpPost("rotate/{face}")]
        public IActionResult RotateCube(string face, [FromQuery] string direction)
        {
            if (Enum.TryParse(face, true, out RubikCubeFaceEnum faceEnum))
            {
                if (direction.ToLower() == "clockwise")
                {
                    _cube.RotateFaceClockwise(faceEnum);
                }
                else if (direction.ToLower() == "anticlockwise")
                {
                    _cube.RotateFaceAntiClockwise(faceEnum);
                }
                else
                {
                    return BadRequest("Invalid rotation direction. Use 'clockwise' or 'anticlockwise'.");
                }

                return Ok(_cube.GetCubeState());
            }

            return BadRequest("Invalid face name. Use 'front', 'right', 'up', 'back', 'left', or 'down'.");
        }
    }
}

