using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskForLasmart.Domain.Entities;
using TaskForLasmart.Domain.IRepositories;


namespace TaskForLasmart.Web.Controllers
{
    public class PointController : Controller
    {
        private readonly IPointRepository _repository; 
        
        public PointController(IPointRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Task()
        {
            return View();
        }
        
        public async Task<ActionResult<IReadOnlyList<Point>>> GetPoints()
        {
            try
            {
                var points = await _repository.GetAllPoints();
                return Ok(points);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        
        public async Task<ActionResult<bool>> DeletePoint(int id)
        {
            try
            {
                var flag = await _repository.DeletePointById(id);
                return Ok(flag);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        
        public async Task<ActionResult<IReadOnlyList<Comment>>> GetComments(int pointId)
        {
            try
            {
                var points = await _repository.GetCommentsByPoint(pointId);
                return Ok(points);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}