using DTT.MinigameMemory;
using Naninovel;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Internal.Gameplay
{
    public class MinigameManager : MonoBehaviour
    {
        public static Action OnMinigameStart = null;

        public static TaskCompletionSource<bool> minigameCompletionSource;

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

        /// <summary>
        /// Start minigame with specified settings.
        /// </summary>
        private void MinigameStart()
        {
            minigameCompletionSource = new TaskCompletionSource<bool>();

            UI.UIManager.OnMinigameStart(true);
            memoryGameManager.StartGame(settings);
        }

        public static async Task WaitForMinigameCompletion() => await minigameCompletionSource.Task;

        /// <summary>
        /// Finish minigame and decides whether it was successful or not.
        /// </summary>
        /// <param name="result">Result of the minigame.</param>
        private void MinigameFinish(MemoryGameResults result)
        {
            var failed = result.timeTaken > TimeSpan.FromSeconds(15);

            var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.SetVariableValue("Failed", failed ? "True" : "False");

            UI.UIManager.OnMinigameStart(false);

            minigameCompletionSource.TrySetResult(true);
        }
    }
}