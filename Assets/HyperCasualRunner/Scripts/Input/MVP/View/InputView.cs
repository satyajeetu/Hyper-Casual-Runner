#region Defines

// #define VERBOSE_INPUT

#endregion Defines

using UnityEngine;

namespace HyperCasualRunner.Input.View
{
    public class InputView
    {
        #region Public Methods

        public void Log(string output)
        {

#if VERBOSE_INPUT
            Debug.Log(output);
#endif // VERBOSE_INPUT

        }

        #endregion Public Methods
    }
}