using UnityEngine;

using HyperCasualRunner.Player.MVP.Model;
using HyperCasualRunner.Player.MVP.View;
using HyperCasualRunner.Player.MVP.Presenter;
using HyperCasualRunner.Input;

namespace HyperCasualRunner.Player.MVP
{
    public class Player : MonoBehaviour
    {
        #region Private Fields

        [Header("Elements")]
        [SerializeField] private PlayerView playerView;

        private PlayerPresenter _playerPresenter;
        private InputMVP _touchInput;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            _playerPresenter = new PlayerPresenter(new PlayerModel(Camera.main, transform), playerView);
            _touchInput = InputMVP.Instance;
        }

        private void OnEnable()
        {
            _touchInput.PrimaryFingerPosition += InputMVP_OnPrimaryFingerPosition;
        }

        private void OnDisable()
        {
            _touchInput.PrimaryFingerPosition -= InputMVP_OnPrimaryFingerPosition;
        }

        private void Update()
        {
            _playerPresenter.CustomUpdate();
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void InputMVP_OnPrimaryFingerPosition(Vector2 currentFingerPosition)
        {
            _playerPresenter.PrimaryFingerOnScreen(currentFingerPosition);
        }

        #endregion Event Handlers
    }
}
