using NullObject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject.View
{
    public class LearnerView
    {
        private readonly ILearner learner;

        public LearnerView(ILearner learner)
        {
            //if (learner == null) throw new ArgumentNullException();
            //if (learner.UserName == null) throw new ArgumentNullException();
            this.learner = learner;
        }
        public void RenderView()
        {
            Console.WriteLine("User Name: " + learner.UserName);
            Console.WriteLine("Courses Completed: " + learner.CoursesCompleted);
        }
    }
}
