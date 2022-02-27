using RacingHub.Data;
using RacingHub.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Services
{
    public class TeamServices
    {
        private readonly Guid _userId;

        public TeamServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity = new Team()
            {
                TeamId = model.TeamId,
                OwnerId = _userId,
                TeamName = model.TeamName,
                TeamDescription = model.TeamDescription,
                CreatedUtc = DateTime.UtcNow,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Teams
                    .Select(e => new TeamListItem
                    {
                        TeamId = e.TeamId,
                        TeamName = e.TeamName,
 
                    });
                return query.ToArray();
            }
        }

        public TeamDetails GetTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId);
                return
                new TeamDetails
                {
                    TeamId = entity.TeamId,
                    TeamDescription = entity.TeamDescription,
                    TeamName = entity.TeamName,
                    CreatedUtc = entity.CreatedUtc,
                    
                };
            }
        }

        public bool EditTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);
                entity.TeamName = model.TeamName;
                entity.TeamDescription = model.TeamDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId && e.OwnerId == _userId);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
