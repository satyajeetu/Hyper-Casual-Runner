#region Defines

// #define VERBOSE_INPUT

#endregion Defines

using UnityEngine;
using UnityEngine.InputSystem;

using HyperCasualRunner.Input.Model;
using HyperCasualRunner.Input.View;

namespace HyperCasualRunner.Input.Presenter
{
    #region Namespace Specific Properties

    public delegate void PrimaryTouchEventHandler(Vector2 currentFingerPosition);

    #endregion Namespace Specific Properties

    //------------------------------------------------------------------------------------------------------------

    public class InputPresenter
    {
        #region Public Properties

        public event PrimaryTouchEventHandler PrimaryFingerPosition;

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

        public void OnPrimaryTouchPositionInScreenSpace(InputAction.CallbackContext context)
        {
            Vector2 value = _inputModel.OnPrimaryTouchPositionInScreenSpace(context);
            _inputView.Log(value.ToString());

            PrimaryFingerPosition?.Invoke(value);
        }

        #endregion Public Methods
    }
}
