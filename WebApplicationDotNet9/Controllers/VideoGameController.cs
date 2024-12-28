using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> _videoGames = new List<VideoGame>
        {
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
            new VideoGame { Id = 2, Title = "Super Mario Odyssey", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
            new VideoGame { Id = 3, Title = "The Witcher 3: Wild Hunt", Platform = "PlayStation 4", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGame { Id = 4, Title = "Red Dead Redemption 2", Platform = "PlayStation 4", Developer = "Rockstar Studios", Publisher = "Rockstar Games" },
            new VideoGame { Id = 5, Title = "The Last of Us Part II", Platform = "PlayStation 4", Developer = "Naughty Dog", Publisher = "Sony Interactive Entertainment" }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(_videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGame(int id)
        {
            var game = _videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
                return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();

            newGame.Id = _videoGames.Max(g => g.Id) + 1;
            _videoGames.Add(newGame);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var game = _videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var game = _videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
                return NotFound();

            _videoGames.Remove(game);
            return NoContent();
        }
    }
}
