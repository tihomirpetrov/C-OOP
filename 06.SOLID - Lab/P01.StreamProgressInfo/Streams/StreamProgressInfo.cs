namespace P01.StreamProgressInfo.Streams
{
    using Interfaces;

    public class StreamProgressInfo : StreamProgressor
    {
        public StreamProgressInfo(IStreamable file) : base(file)
        {
        }
    }
}