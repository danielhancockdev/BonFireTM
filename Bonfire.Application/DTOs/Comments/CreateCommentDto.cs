using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Comments
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid TaskItemId { get; set; }
    }
}
