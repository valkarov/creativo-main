using creativo_API.Models;
using creativo_API.Services;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ForumController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;

        // GET api/forum
        public IEnumerable<ForumDto> Get()
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            List<Forum> forums = db.Forums.ToList();
           List<ForumDto> forumDtos = new List<ForumDto>();
            foreach (Forum forum in forums) {
                ForumDto forumDto = ForumDto.mapToForumDto(forum, userId);
                forumDto.Usuario = forum.User.UserName;
                forumDtos.Add(forumDto);
            }
            return forumDtos;
        }

        // GET api/forum/5
        public ForumDto Get(int id)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);

            Forum forum = db.Forums.FirstOrDefault(e => e.Id == id);
            if(forum == null)
            {
                return null;
            }
            return ForumDto.mapToForumDto(forum, userId);
        }

        // POST api/forum
        public void Post([FromBody] ForumDto forumdto)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            Forum forum = ForumDto.mapToForum(forumdto);
            forum.User = user;
            forum.AuthorId = user.Id;
            db.Forums.Add(forum);
            db.SaveChanges();
        }

        // PUT api/forum/5
        public void Put(int id, [FromBody] Forum forum)
        {
            Forum entity = db.Forums.FirstOrDefault(e => e.Id == id);
            entity.Title = forum.Title;
            entity.Description = forum.Description;
            db.SaveChanges();
        }

        // DELETE api/forum/5
        public void Delete(int id)
        {
            Forum forum = db.Forums.FirstOrDefault(e => e.Id == id);
            db.ForumComments.RemoveRange(forum.ForumComments);
            db.Forums.Remove(forum);
            db.SaveChanges();
        }
        [HttpPost]
        [Route("api/forum/{id}/comment")]
        public void CreateComment(int id, [FromBody] forumCommentRequestDto comment)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            Forum forum = db.Forums.Find(id);
            ForumComment newComment = new ForumComment();
            newComment.Comment = comment.Comment;
            newComment.User = user;
            newComment.Forum = forum;
            newComment.Date = DateTime.Now;
            db.ForumComments.Add(newComment);
            db.SaveChanges();

        }
        [HttpDelete]
        [Route("api/forum/comment/{commentId}")]
        public void DeleteComment(int commentId)
        {
            ForumComment comment = db.ForumComments.FirstOrDefault(e => e.Id == commentId);
            db.ForumComments.Remove(comment);
            db.SaveChanges();
        }
    }
}
