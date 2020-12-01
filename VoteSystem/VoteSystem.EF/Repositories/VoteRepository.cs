using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VoteSystem.Data.Entities.VoteAggregate;
using VoteSystem.Data.Repositories;

namespace VoteSystem.EF.Repositories
{
    class VoteRepository : IVoteRepository
    {
        public void Create(Vote vote)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Votes.Add(vote);
                ctx.SaveChanges();
            }
        }

        public List<Vote> GetAllForUser(int userId)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Votes.Where(u => u.userId == userId)
                    .Where(vote => vote.voteStart>DateTime.Now)
                    .Where(vote => vote.voteEnd< DateTime.Now)
                    .ToList();
            }
        }

        public Dictionary<int, int> GetResultInVote(int voteId)
        {
            throw new NotImplementedException();
        }

        public Vote GetVote(int voteId)
        {
            using (var ctx = new VoteContext())
            {
                Vote vote = ctx.Votes.FirstOrDefault(vote => vote.Id == voteId);
                if (vote == null)
                    return null;
                return vote;
            }
        }

        public void Update(Vote vote)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).voteStart = vote.voteStart;
                ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).voteEnd = vote.voteEnd;
                ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).choiceId = vote.choiceId;
            }
        }
    }
}
