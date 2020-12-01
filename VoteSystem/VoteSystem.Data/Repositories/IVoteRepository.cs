using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Entities.VoteAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IVoteRepository
    {
        void Create(Vote vote);
        void Update(Vote vote);
        Vote GetVote(int voteId);
        List<Vote> GetAllForUser(int userId);
        Dictionary<int, int> GetResultInVote(int voteId);
    }
}
