using Naninovel;
using UnityEngine;

namespace Internal.Gameplay
{
    public class NovelEventsManager : MonoBehaviour
    {
        /// <summary>
        /// Set next game location for the map.
        /// </summary>
        /// <param name="location">Next location.</param>
        public void SetNextLocation(string location)
        {
            var variableManager = Engine.GetService<ICustomVariableManager>();
            variableManager.SetVariableValue("Location", location);
        }

        /// <summary>
        /// Stop all background music.
        /// </summary>
        public void StopBGMusic()
        {
            var audioManager = Engine.GetService<IAudioManager>();
            audioManager.StopAllBgmAsync().Forget();
        }
    }
}
