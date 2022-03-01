using RacingHub.Data;
using RacingHub.Models.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Services
{
    public class RaceService
    {
        private readonly Guid _userId;

        public RaceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRace(RaceCreate model)
        {
            var entity = new Race()
            {
                RaceId = model.RaceId,
                OwnerId = _userId,
                RaceName = model.RaceName,
                RaceDate = model.RaceDate,
                RaceDescription = model.RaceDescription,
                DriverLimit = model.DriverLimit,
                CreatedUtc = DateTime.UtcNow,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Races.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RaceListItem> GetRaces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Races
                    .Select(e => new RaceListItem
                    {
                        RaceId = e.RaceId,
                        RaceName = e.RaceName,
                        RaceDate = e.RaceDate,
                        DriverLimit = e.DriverLimit,
                    });
                return query.ToArray();
            }
        }

        public RaceDetails GetRaceById(int raceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Races
                    .Single(e => e.RaceId == raceId);
                return
                new RaceDetails
                {
                    RaceId = entity.RaceId,
                    RaceDescription = entity.RaceDescription,
                    RaceName = entity.RaceName,
                    DriverLimit = entity.DriverLimit,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdateRace(RaceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Races
                    .Single(e => e.RaceId == model.RaceId && e.OwnerId == _userId);
                entity.RaceName = model.RaceName;
                entity.RaceDescription = model.RaceDescription;
                entity.DriverLimit = model.DriverLimit;
                entity.RaceId = model.RaceId;
                entity.RaceDate = model.RaceDate;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteRace(int raceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Races
                    .Single(e => e.RaceId == raceId && e.OwnerId == _userId);

                ctx.Races.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
