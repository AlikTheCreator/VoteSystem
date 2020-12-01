using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Data.Entities.VoteAggregate
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime voteStart { get; set; }
        public DateTime voteEnd { get; set; }
        public User user { get; set; }
        public Choice choice { get; set; }
    }
}
