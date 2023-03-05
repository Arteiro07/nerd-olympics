using NerdOlympics.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdOlympics.Data.Interfaces
{
    public interface IRecordRepository
    {
        Task<List<Record>> GetUserRecords(int userId);
        Task<List<Record>> GetCompetitionRecords(int competitionId);
        Task<Record> CreateUserRecord(Record record);
        Task<Record> UpdateUserRecord(Record record);
        Task<bool> DeleteUserRecord(int recordId);
        Task<bool> Exists(int recordId);
    }
}
