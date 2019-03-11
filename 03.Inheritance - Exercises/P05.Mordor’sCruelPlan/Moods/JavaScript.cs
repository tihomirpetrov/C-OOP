namespace P05.Mordor_sCruelPlan.Moods
{
    public class JavaScript : Mood
    {
        public override int From
        {
            get
            {
                return 16;
            }
        }
        public override int To
        {
            get
            {
                return int.MaxValue;
            }
        }
    }
}