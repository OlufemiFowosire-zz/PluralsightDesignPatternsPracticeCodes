namespace NullObject.Entities
{
    public interface ILearner
    {
        public int Id { get; }
        public string UserName { get; }
        public int CoursesCompleted { get; }
    }
}