using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskForLasmart.Data.Ef.Data;
using TaskForLasmart.Domain.Entities;
using TaskForLasmart.Domain.IRepositories;

namespace TaskForLasmart.Data.Ef.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly EfDbContext _context;

        public PointRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Point>> GetAllPoints()
        {
            var points = await _context.Points.ToListAsync();
            
            foreach (var item in points)
            {
                item.Comments = await GetCommentsByPoint(item.Id);
            }
            
            return points;
        }

        public async Task<bool> DeletePointById(int id)
        {
            var point = await _context.Points.FirstOrDefaultAsync(p => p.Id == id);
            
            if (point == null)
            {
                return false;
            }
            
            _context.Points.Remove(point);
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<Comment>> GetCommentsByPoint(int pointId)
        {
            var comments = await _context.Comments.Where(c => 
                c.PointId == pointId).ToListAsync();
            
            return comments;
        }
    }
}