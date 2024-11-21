using DTT.MinigameMemory;
using Internal.UI;
using Naninovel;
using System;
using UnityEngine;

namespace Internal.Gameplay
{
    public class MinigameManager : MonoBehaviour
    {
        public static Action OnMinigameStart = null; 
        [SerializeField]
        private MemoryGameSettings settings;

        [SerializeField]
        private MemoryGameManager memoryGameManager;

        void OnEnable()
        {
            OnMinigameStart += MinigameStart;
            memoryGameManager.Finish += MinigameFinish;
        }

        void OnDisable()
        {
            OnMinigameStart -= MinigameStart;
            memoryGameManager.Finish -= MinigameFinish;
        }

        private void MinigameStart()
        {
            UI.UIManager.OnMinigameStart(true);
            memoryGameManager.StartGame(settings);
        }

        private void MinigameFinish(MemoryGameResults result)
        {
            var failed = result.timeTaken > TimeSpan.FromSeconds(15);

            var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.SetVariableValue("Failed", failed.ToString());

            UI.UIManager.OnMinigameStart(false);
        }
    }
}