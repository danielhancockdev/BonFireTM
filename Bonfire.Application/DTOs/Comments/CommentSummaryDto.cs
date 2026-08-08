using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Comments
{
    public class CommentSummaryDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
