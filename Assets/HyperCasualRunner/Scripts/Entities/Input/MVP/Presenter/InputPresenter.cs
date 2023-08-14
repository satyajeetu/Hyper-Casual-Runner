#region Defines

// #define VERBOSE_INPUT

#endregion Defines

using UnityEngine;
using UnityEngine.InputSystem;

using HyperCasualRunner.InputSpace.Model;
using HyperCasualRunner.InputSpace.View;

namespace HyperCasualRunner.InputSpace.Presenter
{
    #region Namespace Specific Properties

    public delegate void PrimaryTouchEventHandler(Vector2 currentFingerPosition);

    #endregion Namespace Specific Properties

    //------------------------------------------------------------------------------------------------------------

    public class InputPresenter
    {
        #region Public Properties

        public event PrimaryTouchEventHandler ContinuesPrimaryFingerPosition;
        public event PrimaryTouchEventHandler FirstPrimaryFingerPosition;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        private readonly InputModel _inputModel;
        private readonly InputView _inputView;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intitalization

        public InputPresenter()
        {
            _inputModel = new InputModel();
            _inputView = new InputView();
        }

        #endregion Intitalization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void OnContinuesPrimaryTouchPositionInScreenSpace(InputAction.CallbackContext context)
        {
            Vector2 value = _inputModel.OnContinuesPrimaryTouchPositionInScreenSpace(context);

#if VERBOSE_INPUT
            _inputView.Log(value.ToString());
#endif

            ContinuesPrimaryFingerPosition?.Invoke(value);
        }

        public void OnFirstPrimaryFingerPosition(InputAction.CallbackContext context)
        {
            Vector2 value = _inputModel.OnFirstPrimaryFingerPosition(context);

#if VERBOSE_INPUT
            _inputView.Log(value.ToString() + "First");
#endif

            FirstPrimaryFingerPosition?.Invoke(value);
        }

#endregion Public Methods
    }
}
