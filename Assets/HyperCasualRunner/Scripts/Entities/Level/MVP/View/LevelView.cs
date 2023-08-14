#region Defines
// #define VERBOSE_LEVEL
#endregion Defines

using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace.View
{
    public class LevelView
    {
        #region Public Methods

        public void DebugInfo(string infoToShow)
        {
#if VERBOSE_LEVEL
            Debug.Log(infoToShow);
#endif // VERBOSE_LEVEL
        }

        #endregion Public Methods
    }
}
