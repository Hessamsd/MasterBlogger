﻿using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.Comment.agg;

namespace MB.Domain.Comment.Agg
{
    public class Commentt : DomainBase<int>
    {


        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; } // New = 0 , Confirmed = 1, Canceled = 2
        public int ArticleId { get; private set; }
        public Article Article { get; private set; }


        protected Commentt()
        {

        }

        public Commentt(string name, string email, string message, int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = Statuses.New;
        }

        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }

        public void Canceled()
        {
            Status = Statuses.Canceled;
        }
    }
}
