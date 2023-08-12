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

        public event PrimaryTouchEventHandler ContinuesPrimaryFingerPosition;
        public event PrimaryTouchEventHandler FirstPrimaryFingerPosition;

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

            _inputPresenter.ContinuesPrimaryFingerPosition += InputPresenter_PrimaryFingerPosition;
            _inputPresenter.FirstPrimaryFingerPosition += InputPresenter_FirstPrimaryFingerPosition;

            _coreGameplayInput.Touch.PrimaryTouch.performed += CoreGamePlayInput_PrimaryTouchPerformed;
            _coreGameplayInput.Touch.PrimaryTouch.started += CoreGameplayInput_PrimaryTouchStarted;
        }

        private void OnDisable()
        {
            _coreGameplayInput.Disable();

            _inputPresenter.ContinuesPrimaryFingerPosition -= InputPresenter_PrimaryFingerPosition;
            _inputPresenter.FirstPrimaryFingerPosition -= InputPresenter_FirstPrimaryFingerPosition;

            _coreGameplayInput.Touch.PrimaryTouch.performed -= CoreGamePlayInput_PrimaryTouchPerformed;
            _coreGameplayInput.Touch.PrimaryTouch.started -= CoreGameplayInput_PrimaryTouchStarted;
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void InputPresenter_PrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            ContinuesPrimaryFingerPosition?.Invoke(currentFingerPosition);
        }

        private void InputPresenter_FirstPrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            FirstPrimaryFingerPosition?.Invoke(currentFingerPosition);
        }

        private void CoreGameplayInput_PrimaryTouchStarted(InputAction.CallbackContext context)
        {
            _inputPresenter.OnFirstPrimaryFingerPosition(context);
        }

        private void CoreGamePlayInput_PrimaryTouchPerformed(InputAction.CallbackContext context)
        {
            _inputPresenter.OnContinuesPrimaryTouchPositionInScreenSpace(context);
        }

        #endregion Event Handlers
    }
}