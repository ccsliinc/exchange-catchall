﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Exchange.CatchAll.Properties;

namespace Exchange.CatchAll
{
    class Logger
    {
        private static EventLog logger = null;


        public static void LogInformation(string message, int id = 0)
        {
            if (Settings.Default.LogLevel >= 3)
                LogEntry(message, id, EventLogEntryType.Information);
        }

        public static void LogWarning(string message, int id = 0)
        {
            if (Settings.Default.LogLevel >= 2)
                LogEntry(message, id, EventLogEntryType.Warning);
        }

        public static void LogError(string message, int id = 0)
        {
            if (Settings.Default.LogLevel >= 1)
                LogEntry(message, id, EventLogEntryType.Error);
        }

        private static void LogEntry(string message, int id, EventLogEntryType logType)
        {
            if (logger == null)
            {
                logger = new EventLog();
                logger.Source = "Exchange CatchAll";
                if (!EventLog.SourceExists(logger.Source))
                {
                    EventLog.CreateEventSource(logger.Source,"Application");
                }
            }
            logger.WriteEntry(message, logType, id);

        }
    }
}