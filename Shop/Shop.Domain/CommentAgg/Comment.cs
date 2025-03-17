using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        private Comment() { }
        public long UserId { get; private set; }
        public string Text { get; private set; }
        public long ProductId { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public CommentStatus Status { get; private set; }

        public Comment(long userId, string text, long productId)
        {
            Guard(text);

            UserId = userId;
            Text = text;
            ProductId = productId;
            Status = CommentStatus.Pennding;
        }

        public void Edit(string text)
        {
            Guard(text);

            Text = text;
            UpdateDate = DateTime.Now;
        }
        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }
        public void Guard(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
        }
    }
}
