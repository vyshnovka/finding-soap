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

        [SerializeField]
        private GameObject questLog;
        [SerializeField]
        private TMP_Text questLogText;

        [SerializeField]
        private GameObject mapButton;

        [SerializeField]
        private List<Button> mapLocations;

        void OnEnable()
        {
            OnUpdateQuestLog += UpdateQuestLog;
            OnToggleNavigation += ToggleNavigation;
            OnToggleButton += ToggleButtonInt;
        }

        void OnDisable()
        {
            OnUpdateQuestLog -= UpdateQuestLog;
            OnToggleNavigation -= ToggleNavigation;
            OnToggleButton -= ToggleButtonInt;
        }

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

        private void ToggleNavigation() => mapButton.SetActive(!mapButton.activeSelf);

        private void ToggleButtonInt(string buttonName)
        {
            var buttonToToggle = mapLocations.FirstOrDefault(button => button.gameObject.name == buttonName);
            buttonToToggle.interactable = !buttonToToggle.interactable;
        }
    }
}
