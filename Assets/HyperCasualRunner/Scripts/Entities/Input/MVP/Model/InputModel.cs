#region Defines

// #define VERBOSE_INPUT

#endregion Defines

using UnityEngine;
using UnityEngine.InputSystem;

namespace HyperCasualRunner.InputSpace.Model
{
    public class InputModel
    {
        #region Public Methods

        public Vector2 OnContinuesPrimaryTouchPositionInScreenSpace(InputAction.CallbackContext context)
        {
            return context.ReadValue<Vector2>();
        }

        public Vector2 OnFirstPrimaryFingerPosition(InputAction.CallbackContext context)
        {
            return context.ReadValue<Vector2>();
        }

        #endregion Public Methods
    }
}
