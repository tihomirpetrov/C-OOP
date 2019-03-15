namespace P05.BorderControl
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, long id)
        {
            this.model = model;
            this.Id = id;
        }

        public long Id
        {
            get; private set;           
        }
    }
}