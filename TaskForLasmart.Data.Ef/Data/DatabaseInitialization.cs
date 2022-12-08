using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskForLasmart.Domain.Entities;

namespace TaskForLasmart.Data.Ef.Data
{
    public static class DatabaseInitialization
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EfDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<EfDbContext>>());

            if (context.Points.Any())
            {
                return;
            }
            
            context.Points.AddRange(
                new Point
                {
                    Id = 1,
                    PositionX = 100,
                    PositionY = 15,
                    Radius = 9,
                    Color = "LightGrey"
                },
                new Point
                {
                    Id = 2,
                    PositionX = 400,
                    PositionY = 30,
                    Radius = 18,
                    Color = "Red"
                });

            context.Comments.AddRange(
                new Comment
                {
                    Id = 1,
                    Text = "comment 1",
                    TextBackgroundColor = null,
                    PointId = 1
                },
                new Comment
                {
                    Id = 2,
                    Text = "comment 2",
                    TextBackgroundColor = "Yellow",
                    PointId = 1
                },
                new Comment
                {
                    Id = 3,
                    Text = "comment 3",
                    TextBackgroundColor = null,
                    PointId = 2
                },
                new Comment
                {
                    Id = 4,
                    Text = "comment 4",
                    TextBackgroundColor = "LightGrey",
                    PointId = 2
                },
                new Comment
                {
                    Id = 5,
                    Text = "comment 5",
                    TextBackgroundColor = null,
                    PointId = 2
                },
                new Comment
                {
                    Id = 6,
                    Text = "comment 6 looooooooooooong comment",
                    TextBackgroundColor = "Yellow",
                    PointId = 2
                },
                new Comment
                {
                    Id = 7,
                    Text = "comment 7",
                    TextBackgroundColor = "LightGrey",
                    PointId = 2
                },
                new Comment
                {
                    Id = 8,
                    Text = "comment 8",
                    TextBackgroundColor = null,
                    PointId = 2
                }
            );
            
            context.SaveChanges();
        }
    }
}