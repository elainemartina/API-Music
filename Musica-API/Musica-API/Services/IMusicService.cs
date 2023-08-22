using Musica_API.Models;

namespace Musica_API.Services
{
    public interface IMusicService
    {
        Task<List<MusicModel>> GetAllMusics();
        Task<MusicModel?> GetMusic(int id);
        Task<List<MusicModel>> CreateMusic(MusicModel music); 
        Task<List<MusicModel>> UpdateMusic(int id, MusicModel request); 
        Task<List<MusicModel>> DeleteMusic(int id);
        Task<List<MusicModel>> GetMusicByYear(int year);
        Task<List<MusicModel>> GetMusicByArtist(string artist);
        Task<List<MusicModel>> GetIsFavoriteMusic(bool option);
        Task<List<MusicModel>> GetMusicByGenre(string genre);

    }
}
