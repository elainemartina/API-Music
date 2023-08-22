using Microsoft.EntityFrameworkCore;
using Musica_API.Data;
using Musica_API.Models;

namespace Musica_API.Services
{
    public class MusicService : IMusicService
    {
        private readonly DataContext _dataContext;
        public MusicService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET ALL MUSICS
        public async Task<List<MusicModel>> GetAllMusics()
        {
            var musics = await _dataContext.Musics.ToListAsync();
            return musics;
        }

        // GET MUSIC BY ID
        public async Task<MusicModel?> GetMusic(int id)
        {
            var music = await _dataContext.Musics.FindAsync(id);
            if(music is null)
                return null;

            return music;
        }

        // CREATE MUSIC
        public async Task<List<MusicModel>> CreateMusic(MusicModel music)
        {
            _dataContext.Musics.Add(music);
            await _dataContext.SaveChangesAsync();

            return await GetAllMusics();
        }

        // UPDATE MUSIC
        public async Task<List<MusicModel>> UpdateMusic(int id, MusicModel request)
        {
            var musicDb = await _dataContext.Musics.FindAsync(id);
            if (musicDb is null)
                return null;

            musicDb.Name = request.Name;
            musicDb.Artist = request.Artist;
            musicDb.Genre = request.Genre;
            musicDb.YearRelease = request.YearRelease;
            musicDb.Duration = request.Duration;
            musicDb.IsFavorite = request.IsFavorite;

            await _dataContext.SaveChangesAsync();
            return await GetAllMusics();
        }

        // DELETE MUSIC
        public async Task<List<MusicModel>> DeleteMusic(int id)
        {
            var musicDb = await _dataContext.Musics.FindAsync(id);
            if (musicDb is null)
                return null;

            _dataContext.Musics.Remove(musicDb);
            await _dataContext.SaveChangesAsync();

            return await GetAllMusics();
        }

        // MUSICS BY YEAR
        public async Task<List<MusicModel>> GetMusicByYear(int year)
        {
            var musics = await _dataContext.Musics.Where(m => m.YearRelease == year).ToListAsync();
            if (!musics.Any())
                return null;

            return musics;
        }

        // MUSICS BY ARTIST
        public async Task<List<MusicModel>> GetMusicByArtist(string artist)
        {
            var musics = await _dataContext.Musics.Where(m => m.Artist == artist).ToListAsync();
            if (!musics.Any())
                return null;

            return musics;
        }

        // MUSICS IS FAVORITE
        public async Task<List<MusicModel>> GetIsFavoriteMusic(bool option)
        {
            var musics = await _dataContext.Musics.Where(m => m.IsFavorite == option).ToListAsync();
            if (!musics.Any())
                return null;

            return musics;
        }

        // MUSIC BY GENRE
        public async Task<List<MusicModel>> GetMusicByGenre(string genre)
        {
            var musics = await _dataContext.Musics.Where(m => m.Genre == genre).ToListAsync();
            if (!musics.Any())
                return null;

            return musics;
        }
    }
}
