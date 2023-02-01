using Data.Models;

namespace NerdOlympicsAPI.Interfaces
{
    public interface ICompetitionsService
    {
        Task<List<Competition>> GetCompetitions();
    }
}
