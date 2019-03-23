namespace P01.Logger.Appenders.Contracts
{
    using P01.Logger.Layouts.Contracts;
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}