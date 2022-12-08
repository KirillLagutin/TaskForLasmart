using System.Collections.Generic;
using System.Threading.Tasks;
using TaskForLasmart.Domain.Entities;

namespace TaskForLasmart.Domain.IRepositories
{
    public interface IPointRepository
    {
        Task<IReadOnlyList<Point>> GetAllPoints();
        Task<bool> DeletePointById(int id);
        Task<IReadOnlyList<Comment>> GetCommentsByPoint(int pointId);
    }
}