namespace P01.Logger.Core
{
    using P01.Logger.Appenders.Contracts;
    using P01.Logger.Core.Contracts;
    using P01.Logger.Loggers.Enums;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        public void AddAppender(string[] args)
        {
            string typeAppender = args[0];
            string typeLayout = args[1];
            ReportLevel reportLevel = ReportLevel.Info;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }


        }

        public void AddReport(string[] args)
        {
            throw new System.NotImplementedException();
        }

        public void PrintInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}