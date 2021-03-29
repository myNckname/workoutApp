namespace Core.Dtos
{
    public class UserWorkoutDto 
    {
        public int WorkoutId { get; set; }
        public string Title { get; set; }
        public int SpentTime { get; set; }
        public int SpentCalories { get; set; }
    }
}
