
using BepInEx.Logging;

namespace SleepyGirl 
{

    public static class SleepTalk
    {
        private static ManualLogSource _log;
        private const string Signature = "Sleepy Girl .zZ >> ";

        internal static void Init(ManualLogSource logger)
        {
            _log = logger;
        }

        public static void Info(object data)
        {
            _log.LogInfo(Signature + data);
        }

        public static void Debug(object data)
        {
            _log.LogDebug(Signature + data);
        }

        public static void Warning(object data)
        {
            _log.LogWarning(Signature + data);
        }

        public static void Error(object data)
        {
            _log.LogError(Signature + data);
        }
    }
}