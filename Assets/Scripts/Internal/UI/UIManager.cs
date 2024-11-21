using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.UI
{
    public class UIManager : MonoBehaviour
    {
        public static Action<string> OnUpdateQuestLog = null;
        public static Action OnToggleNavigation = null;
        public static Action<string> OnToggleButton = null;
        public static Action<bool> OnMinigameStart = null;

        [SerializeField]
        private GameObject questLog;
        [SerializeField]
        private TMP_Text questLogText;

        [SerializeField]
        private GameObject mapButton;
        [SerializeField]
        private List<Button> mapLocations;

        [SerializeField]
        private GameObject minigameCanvas;

        void OnEnable()
        {
            OnUpdateQuestLog += UpdateQuestLog;
            OnToggleNavigation += ToggleNavigation;
            OnToggleButton += ToggleButtonInt;
            OnMinigameStart += ToggleMinigameUI;
        }

        void OnDisable()
        {
            OnUpdateQuestLog -= UpdateQuestLog;
            OnToggleNavigation -= ToggleNavigation;
            OnToggleButton -= ToggleButtonInt;
            OnMinigameStart -= ToggleMinigameUI;
        }

        /// <summary>
        /// Update the message inquest log or disable quest log if no message is set.
        /// </summary>
        /// <param name="newQuestLog"></param>
        private void UpdateQuestLog(string newQuestLog)
        {
            if (!string.IsNullOrEmpty(newQuestLog))
            {
                questLogText.text = newQuestLog;
                questLog.SetActive(true);
            }
            else
            {
                questLog.SetActive(false);
            }
        }

        /// <summary>
        /// Toggle button to open the map.
        /// </summary>
        private void ToggleNavigation() => mapButton.SetActive(!mapButton.activeSelf);

        /// <summary>
        /// Toggle map location button via its name.
        /// </summary>
        /// <param name="buttonName">Button name.</param>
        private void ToggleButtonInt(string buttonName)
        {
            var buttonToToggle = mapLocations.FirstOrDefault(button => button.gameObject.name == buttonName);
            buttonToToggle.interactable = !buttonToToggle.interactable;
        }

        /// <summary>
        /// Toggle minigame UI.
        /// </summary>
        /// <param name="active">UI activity.</param>
        private void ToggleMinigameUI(bool active)
        {
            minigameCanvas.SetActive(active);
        }
    }
}
