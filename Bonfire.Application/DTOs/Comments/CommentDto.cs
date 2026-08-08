using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Comments
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskItemId { get; set; }
    }
}
