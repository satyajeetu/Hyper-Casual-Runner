using UnityEngine;
using UnityEngine.InputSystem;

using HyperCasualRunner.Input.Presenter;
using Custom.Generics;

namespace HyperCasualRunner.Input
{
    [DefaultExecutionOrder(-1)]
    public class InputMVP : Singleton<InputMVP>
    {
        #region Public Properties

        public event PrimaryTouchEventHandler PrimaryFingerPosition;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        private InputPresenter _inputPresenter;
        private CoreGameplay _coreGameplayInput;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            _inputPresenter = new InputPresenter();
            _coreGameplayInput = new CoreGameplay();
        }

        private void OnEnable()
        {
            _coreGameplayInput.Enable();

            _inputPresenter.PrimaryFingerPosition += InputPresenter_PrimaryFingerPosition;
            _coreGameplayInput.Touch.PrimaryTouchPositionInScreenSpace.performed += CoreGameplayInput_OnPrimaryTouchPositionInScreenSpace;
        }

        private void OnDisable()
        {
            _coreGameplayInput.Disable();

            _inputPresenter.PrimaryFingerPosition -= InputPresenter_PrimaryFingerPosition;
            _coreGameplayInput.Touch.PrimaryTouchPositionInScreenSpace.performed -= CoreGameplayInput_OnPrimaryTouchPositionInScreenSpace;
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void InputPresenter_PrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            PrimaryFingerPosition?.Invoke(currentFingerPosition);
        }

        private void CoreGameplayInput_OnPrimaryTouchPositionInScreenSpace(InputAction.CallbackContext context)
        {
            _inputPresenter.OnPrimaryTouchPositionInScreenSpace(context);
        }

        #endregion Event Handlers
    }
}