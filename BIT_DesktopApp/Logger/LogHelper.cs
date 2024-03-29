﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Logger
{
    public static class LogHelper
    {
        public enum LogTarget
        {
            File, Database, EventLog
        }

        private static LogBase logger = null;

        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;

                case LogTarget.Database:
                    logger = new DBLogger();
                    logger.Log(message);
                    break;

                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
            }
        }

    }
}
