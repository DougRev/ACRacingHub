using RacingHub.Data;
using RacingHub.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        { 
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                PostId = model.PostId,
                OwnerId = _userId,
                PostName = model.PostName,
                PostBody = model.PostBody,
                CreatedUtc = DateTime.UtcNow,
                RaceId = model.RaceId,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

            public IEnumerable<PostListItem> GetPosts()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query = ctx.Posts
                        .Select(e => new PostListItem
                        {
                            PostId = e.PostId,
                            PostName = e.PostName,
                            CreatedUtc = e.CreatedUtc,
                            RaceName = e.Race.RaceName,

                        });
                    return query.ToArray();
                }
            }

            public PostDetails GetPostById(int postId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Posts
                        .Single(e => e.PostId == postId);
                    return
                    new PostDetails
                    {
                        PostId = entity.PostId,
                        OwnerId = entity.OwnerId,
                        PostName= entity.PostName,
                        PostBody = entity.PostBody,
                        CreatedUtc = entity.CreatedUtc,
                        RaceName = entity.Race.RaceName,
                    };
                }
            }

            public bool EditPost(PostEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.OwnerId == _userId);
                    entity.PostName = model.PostName;
                    entity.PostBody = model.PostBody;
                    entity.RaceId = model.RaceId;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }

            }
            public bool DeletePost(int postId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.OwnerId == _userId);

                    ctx.Posts.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
