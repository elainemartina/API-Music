using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musica_API.Models;
using Musica_API.Services;
using System.IO;

namespace Musica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService filmeService)
        {
            _musicService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MusicModel>>> GetAllMusics()
        {
            return await _musicService.GetAllMusics();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicModel>> GetSingleMusic(int id)
        {
            var result = await _musicService.GetMusic(id);
            if (result is null)
                return NotFound("Music not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<MusicModel>>> AddMusic(MusicModel music)
        {
            var result = await _musicService.CreateMusic(music);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<MusicModel>>> UpdateFilme(int id, MusicModel request)
        {
            var result = await _musicService.UpdateMusic(id, request);
            if (result is null)
                return NotFound("Music not found");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<MusicModel>> DeleteMusic(int id)
        {
            var result = await _musicService.DeleteMusic(id);
            if (result is null)
                return NotFound("Music not found");

            return Ok(result);
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<List<MusicModel>>> GetMusicByYear(int year)
        {
            var musics = await _musicService.GetMusicByYear(year);
            if (musics is null)
                return NotFound("Music not found");

            return Ok(musics);
        }


        [HttpGet("artist/{artist}")]
        public async Task<ActionResult<List<MusicModel>>> GetMusicByArtist(string artist)
        {
            var musics = await _musicService.GetMusicByArtist(artist);
            if (musics is null)
                return NotFound("Music not found");

            return Ok(musics);
        }

        [HttpGet("isFavorite/")]
        public async Task<ActionResult<List<MusicModel>>> GetIsFavoriteMusic(bool option)
        {
            var musics = await _musicService.GetIsFavoriteMusic(option);
            if (musics is null)
                return NotFound("Music not found");

            return Ok(musics);
        }       

        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<List<MusicModel>>> GetMusicByGenre(string genre)
        {
            var musics = await _musicService.GetMusicByGenre(genre);
            if (musics is null)
                return NotFound("Music not found");

            return Ok(musics);
        }
    }
}
