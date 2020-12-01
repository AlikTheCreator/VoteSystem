using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.UserPolicyAggregate
{
    public class UserPolicy
    {
        public int Id { get; set; }
        public User user { get; set; }
        public int? PollId { get; set; }
    }
}

