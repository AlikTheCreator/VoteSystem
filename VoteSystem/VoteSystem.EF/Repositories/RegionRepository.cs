using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.Entities.RegionPolicyAggregate;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Repositories;

namespace VoteSystem.EF.Repositories
{
    class RegionRepository : IRegionRepository
    {
        public void CreateRegion(Region region)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Regions.Add(region);
                voteContext.SaveChangesAsync();
            }
        }

        public void UpdateRegion(Region region)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                Region regiontemp = voteContext.Regions.FirstOrDefault(r => r.Id == region.Id);
                regiontemp = region;
                voteContext.SaveChangesAsync();
            }
        }
    }
}
