using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace HKTranslator
{
    static class LogHandler
    {
        #region init
        public static void InitHelper()
        {
            File.Create(Path.Combine(Application.persistentDataPath, "TRANS_HelperLog.txt")).Dispose();
        }

        public static void InitTracker()
        {
            File.Create(Path.Combine(Application.persistentDataPath, "TRANS_TrackerLog.txt")).Dispose();
        }

        public static void InitSpoiler()
        {
            File.Create(Path.Combine(Application.persistentDataPath, "TRANS_SpoilerLog.txt")).Dispose();
        }

        public static void InitCondensedSpoiler()
        {
            File.Create(Path.Combine(Application.persistentDataPath, "TRANS_CondensedSpoiler.txt")).Dispose();
        }
        #endregion

        public static void LogHelper(string message)
        {
            if (message.StartsWith("Current scene:")) // Helper log is written in 1 go, so we can detect this dump by checking the first line.
            {
                bool transitions = false, items = false;
                foreach (string line in message.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.StartsWith("Current scene:")) { InternalLogHelper($"Current Scene: {DictHandler.TranslateSceneName(line.Substring(15))}"); }
                    else if (line.StartsWith("Last randomized transition:"))
                    {
                        InternalLogHelper($"Last Randomized transition: {DictHandler.TranslateTransitionPair(line.Substring(28))}");
                    }
                    else if (line == "REACHABLE ITEM LOCATIONS")
                    {
                        transitions = false;
                        items = true;
                    }
                    else if (line == "REACHABLE TRANSITIONS")
                    {
                        items = false;
                        transitions = true;
                    }
                    else if (line == "CHECKED ITEM LOCATIONS")
                    {
                        transitions = false;
                        items = true;
                    }
                    else if (transitions)
                    {
                        if (line == "") { /* do nothing */ }
                        else if (line.StartsWith(" - ")) { InternalLogHelper($" - {DictHandler.TranslateTransitionName(line.Substring(3))}"); }
                        else { InternalLogHelper(DictHandler.TranslateSceneName(line)); }
                    }
                    else if (items)
                    {
                        InternalLogHelper(line); //TODO: add item translation
                    }
                    else
                    {
                        InternalLogHelper(line);
                    }
                }
            }
        }

        public static void LogTracker(string message)
        {
            if (message.StartsWith("TRANSITION"))
            {
                string[] splitMessage = message.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (splitMessage.Length == 1)
                {
                    InternalLogTracker(DictHandler.TranslateTransitionPair(message.Substring(message.IndexOf("{")))); // god help me
                }
                else
                {
                    InternalLogTracker(DictHandler.TranslateTransitionPair(splitMessage[0].Substring(message.IndexOf("{"))) + splitMessage[1]); // i have committed warcrimes
                }
                return;
            }
            else if (message.StartsWith("ITEM"))
            {
                // TODO - add item translation
            }
            InternalLogTracker(message);
            return;
        }

        public static void LogSpoiler(string message)
        {
            InternalLogSpoiler(message);
        }

        public static void LogCondensedSpoiler(string message)
        {
            InternalLogCondensedSpoiler(message);
        }

        public static void InternalLogHelper(string message)
        {
            File.AppendAllText(Path.Combine(Application.persistentDataPath, "TRANS_HelperLog.txt"), message + Environment.NewLine);
        }

        public static void InternalLogTracker(string message)
        {
            File.AppendAllText(Path.Combine(Application.persistentDataPath, "TRANS_TrackerLog.txt"), message + Environment.NewLine);
        }

        public static void InternalLogSpoiler(string message)
        {
            File.AppendAllText(Path.Combine(Application.persistentDataPath, "TRANS_SpoilerLog.txt"), message + Environment.NewLine);
        }

        public static void InternalLogCondensedSpoiler(string message)
        {
            File.AppendAllText(Path.Combine(Application.persistentDataPath, "TRANS_CondensedSpoiler.txt"), message + Environment.NewLine);
        }
    }
}
