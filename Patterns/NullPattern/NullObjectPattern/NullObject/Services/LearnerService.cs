using NullObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullObject.Services
{
    public class LearnerService
    {
        public ILearner GetCurrentLearner()
        {
            int learnerId = -1;
            var learner = LearnerRepo.Repo.GetLearner(learnerId);
            if (learner == null)
                return new NullLearner();

            return learner;
        }

        internal sealed class LearnerRepo
        {
            private readonly IList<ILearner> learners = new List<ILearner>();
            private static readonly Lazy<LearnerRepo> repo = new Lazy<LearnerRepo>(() => new LearnerRepo());

            public static LearnerRepo Repo => repo.Value;
            private LearnerRepo()
            {
                learners.Add(new Learner(1, "David", 86));
                learners.Add(new Learner(2, "Julie", 72));
                learners.Add(new Learner(3, "Scott", 92));
            }
            public ILearner GetLearner(int learnerId)
            {
                bool learnerExist = learners.Any(learner => learner.Id == learnerId);
                if (learnerExist)
                    return learners.FirstOrDefault<ILearner>(Learner => Learner.Id == learnerId);
                return null; 
            }
        }
    }
}
