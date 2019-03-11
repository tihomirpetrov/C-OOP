namespace P05.Mordor_sCruelPlan.Moods
{
    public class Angry : Mood
    {
        public override int From
        {
            get
            {
                return int.MinValue;
            }
        }
        public override int To
        {
            get
            {
                return -4;
            }
        }
    }
}