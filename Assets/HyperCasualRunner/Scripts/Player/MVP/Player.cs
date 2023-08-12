using UnityEngine;

using HyperCasualRunner.Player.MVP.Model;
using HyperCasualRunner.Player.MVP.View;
using HyperCasualRunner.Player.MVP.Presenter;
using HyperCasualRunner.Input;
using UnityEngine.Assertions;
using System;

namespace HyperCasualRunner.Player.MVP
{
    public class Player : MonoBehaviour
    {
        #region Private Fields

        [Header("Elements")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Transform _runnersParent;

        private PlayerPresenter _playerPresenter;
        private PlayerModel _playerModel;
        private InputMVP _touchInput;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            Assert.IsNotNull(_playerView);
            Assert.IsNotNull(_runnersParent);

            _playerView.Intialize(transform, _runnersParent);

            _playerModel = new PlayerModel(transform, _runnersParent);
            _playerPresenter = new PlayerPresenter(_playerModel, _playerView);
            _touchInput = InputMVP.Instance;
        }

        private void OnEnable()
        {
            _touchInput.ContinuesPrimaryFingerPosition += InputMVP_OnPrimaryFingerPosition;
            _touchInput.FirstPrimaryFingerPosition += InputMVP_OnFirstPrimaryFingerPosition;
        }

        private void OnDisable()
        {
            _touchInput.ContinuesPrimaryFingerPosition -= InputMVP_OnPrimaryFingerPosition;
            _touchInput.FirstPrimaryFingerPosition -= InputMVP_OnFirstPrimaryFingerPosition;
        }


        private void Update()
        {
            _playerPresenter.CustomUpdate();
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public int Screen_GetScreenWith()
        {
            return Screen.width;
        }

        #endregion Public Mehods

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void InputMVP_OnPrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            _playerPresenter.PrimaryFingerOnScreen(currentFingerPosition, Screen_GetScreenWith());
        }

        private void InputMVP_OnFirstPrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            _playerPresenter.FirstPrimaryTouchOnScreen(currentFingerPosition);
        }

        #endregion Event Handlers
    }
}
