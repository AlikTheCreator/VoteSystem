using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IPollRepository
    {
        void Create(Poll poll);
        void Update(Poll poll);
        Poll Get(int id);
        List<Poll> GetPolls(int id);
        string[] GetPollDetails(int id);
        Choice GetChoice(int choiceId);
    }
}
