namespace P01.StreamProgressInfo.Interfaces
{
    public interface IStreamable : ISource
    {
        int BytesSent { get; }
    }
}