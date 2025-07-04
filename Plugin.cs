using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace SleepyGirl
{
    [BepInPlugin("moe.luka.sleepy_girl", "Just A Sleepy Girl", "0.0.1")]
    public class SleepyGirlPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private static Harmony _harmony;
        internal static short? ForcedEventID = null;

        private void Awake()
        {
            Log = Logger;
            SleepTalk.Init(Log);
            _harmony = new Harmony("moe.luka.sleepy_girl");
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
            SleepTalk.Info("Huh? Did somebody wake me up? I was having such a nice dream...");
        }

        private void OnDestroy()
        {
            _harmony.UnpatchSelf();
            SleepTalk.Info("Sleepy Girl is going to sleep. Harmony unpatched.");
        }

        internal static void OpenSleepyGirlMenu()
        {
            SleepTalk.Info("Opening SleepyGirl's super secret menu! Shhh!");
        }
    }
}