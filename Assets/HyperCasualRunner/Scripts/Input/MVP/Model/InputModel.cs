#region Defines

// #define VERBOSE_INPUT

#endregion Defines

using UnityEngine;
using UnityEngine.InputSystem;

namespace HyperCasualRunner.Input.Model
{
    public class InputModel
    {
        #region Public Methods

        public Vector2 OnPrimaryTouchPositionInScreenSpace(InputAction.CallbackContext context)
        {
            return context.ReadValue<Vector2>();
        }

        #endregion Public Methods
    }
}
