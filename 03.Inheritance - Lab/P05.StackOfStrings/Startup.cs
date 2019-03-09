namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            CustomStack stack = new CustomStack();

            stack.AddRange("1", "2", "3");
        }
    }
}