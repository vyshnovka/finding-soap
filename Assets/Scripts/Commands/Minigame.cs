using Naninovel;
using UnityEngine;

namespace Commands
{
    [CommandAlias("minigame")]
    public class Minigame : Command
    {
        [ParameterAlias("type"), RequiredParameter]
        public StringParameter gameType;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            switch (gameType.ToString()) 
            {
                case "Memory":
                    Debug.Log("Memory game");
                    break;
                default:
                    Debug.Log("Other game");
                    break;
            }

            return UniTask.CompletedTask;
        }
    }
}
