using Internal.Gameplay;
using Naninovel;
using UnityEngine;

namespace Commands
{
    [CommandAlias("minigame")]
    public class Minigame : Command
    {
        [ParameterAlias("type"), RequiredParameter]
        public StringParameter gameType;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            switch (gameType.ToString()) 
            {
                case "Memory":
                    MinigameManager.OnMinigameStart.Invoke();
                    break;
                default:
                    Debug.Log("Other game");
                    break;
            }

            await MinigameManager.WaitForMinigameCompletion();
        }
    }
}
