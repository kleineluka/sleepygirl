using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using SleepyGirl;

namespace SleepyGirl.GUI
{
    public static class SleepyGirlMenuUI
    {
        private static Button _sleepyGirlButton;

        // parentTransform = The Transform of the container where the button should be added (e.g., the "Buttons" container on the More tab)
        internal static void InitializeMenuButton(Transform parentTransform)
        {
            if (parentTransform == null)
            {
                SleepTalk.Error("ParentTransform is null! Cannot initialize SleepyGirl menu button.");
                return;
            }
            Transform templateButton = parentTransform.Find("Memory Album Button");
            if (templateButton == null)
            {
                SleepTalk.Error("Template button 'Memory Album Button' not found! Cannot create SleepyGirl button.");
                return;
            }
            GameObject newButtonGO = (GameObject)GameObject.Instantiate(templateButton.gameObject, parentTransform);
            newButtonGO.name = "SleepyGirlMenuButton";
            _sleepyGirlButton = newButtonGO.GetComponent<Button>();
            Text buttonText = newButtonGO.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = "SleepyGirl Menu";
                if (buttonText.text.Length > 15)
                {
                    buttonText.fontSize = 12;
                }
            }
            _sleepyGirlButton.onClick.RemoveAllListeners();
            _sleepyGirlButton.onClick.AddListener(OnSleepyGirlButtonClicked);

            SleepTalk.Info("SleepyGirl menu button added and initialized.");
        }

        private static void OnSleepyGirlButtonClicked()
        {
            SleepTalk.Info("Opening SleepyGirl's super secret GUI menu! Shhh!");
            if (GameObject.FindObjectOfType<DebugCanvasController>() != null)
            {
                GameObject.FindObjectOfType<DebugCanvasController>().ShowTemporaryFeedbackPopup(
                    "SleepyGirl Menu",
                    "You found SleepyGirl's secret menu!",
                    3f,
                    0f
                );
            }
        }
        
    }
}