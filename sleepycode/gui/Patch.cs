using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using SleepyGirl.GUI;
using SleepyGirl;

namespace SleepyGirl.GUI
{
    [HarmonyPatch(typeof(PanelScript))]
    public static class PanelScriptPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("LoadStartupScreen")]
        public static void Postfix_LoadStartupScreen(PanelScript __instance)
        {
            SleepTalk.Debug("PanelScript.LoadStartupScreen Postfix: Initiating SleepyGirl button setup from GUI Patches.");
            try
            {
                Transform morePanel = __instance.MorePanel.transform;
                if (morePanel == null)
                {
                    SleepTalk.Error("MorePanel not found! Cannot add SleepyGirl button.");
                    return;
                }
                Transform buttonsContainer = morePanel.Find("Buttons");
                if (buttonsContainer == null)
                {
                    SleepTalk.Error("Buttons container not found within MorePanel! Cannot add SleepyGirl button.");
                    return;
                }
                SleepyGirlMenuUI.InitializeMenuButton(buttonsContainer);
            }
            catch (System.Exception ex)
            {
                SleepTalk.Error($"Failed to add SleepyGirl button from GUI Patches: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}