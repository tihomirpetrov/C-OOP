namespace P05.Mordor_sCruelPlan.Moods
{
    public class Sad : Mood
    {
        public override int From
        {
            get
            {
                return -5;
            }
        }
        public override int To
        {
            get
            {
                return 0;
            }
        }
    }
}