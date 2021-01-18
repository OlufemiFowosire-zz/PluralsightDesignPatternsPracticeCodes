using System;
using System.Collections.Generic;
using System.Text;

namespace NullObject.Entities
{
    public class Learner : ILearner
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public int CoursesCompleted { get; private set; }
        public Learner(int id, string userName, int coursesCompleted)
        {
            Id = id;
            UserName = userName;
            CoursesCompleted = coursesCompleted;
        }
    }
}
