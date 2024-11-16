using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class ForumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int AuthorId { get; set; }
        public List<ForumCommentDto> ForumComments { get; set; }
        public string Usuario { get; set; }
        public bool IsYours { get; set; }
        internal static Forum mapToForum(ForumDto forumDto)
        {
            return new Forum()
            {
                Id = forumDto.Id,
                Title = forumDto.Title,
                Description = forumDto.Description,
                Date = forumDto.Date,
                Location = forumDto.Location,
                AuthorId = forumDto.AuthorId
            };
        }
        internal static ForumDto mapToForumDto(Forum forum, int userId)
        {
            List<ForumCommentDto> forumCommentDtos = new List<ForumCommentDto>();
            foreach (ForumComment forumComment in forum.ForumComments)
            {
                ForumCommentDto forumCommentDto = ForumCommentDto.mapToForumCommentDto(forumComment, userId);
                forumCommentDto.Usuario = forumComment.User.UserName;
                forumCommentDtos.Add(forumCommentDto);
            }
            return new ForumDto()
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ForumComments = forumCommentDtos,
                Date = forum.Date,
                Location = forum.Location,
                AuthorId = forum.AuthorId,
                IsYours = forum.AuthorId == userId
            };
        }
    }

    public class ForumCommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int ForumId { get; set; }
        public int AuthorId { get; set; }
        public string Usuario { get; set; }
        public bool IsYours { get; set; }
        internal static ForumComment mapToForumComment(ForumCommentDto forumCommentDto)
        {
            return new ForumComment()
            {
                Id = forumCommentDto.Id,
                Comment = forumCommentDto.Comment,
                Date = forumCommentDto.Date,
                ForumId = forumCommentDto.ForumId,
                AuthorId = forumCommentDto.AuthorId
            };
        }
        internal static ForumCommentDto mapToForumCommentDto(ForumComment forumComment, int userId)
        {
            return new ForumCommentDto()
            {
                Id = forumComment.Id,
                Comment = forumComment.Comment,
                Date = forumComment.Date,
                ForumId = forumComment.ForumId,
                AuthorId = forumComment.AuthorId,
                IsYours = forumComment.AuthorId == userId
            };
        }
    }
    public class forumCommentRequestDto
    {
        public string Comment { get; set; }
    }
}