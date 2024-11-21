using Naninovel;
using UnityEngine;

namespace Internal.Gameplay
{
    public class NovelEventsManager : MonoBehaviour
    {
        public void SetNextLocation(string location)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.SetVariableValue("Location", location);
        }

        public void StopBGMusic()
        {
            var audioManager = Engine.GetService<IAudioManager>();
            audioManager.StopAllBgmAsync().Forget();
        }
    }
}
