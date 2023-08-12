using UnityEngine;
using UnityEngine.Assertions;

using HyperCasualRunner.Player.MVP.Model;
using HyperCasualRunner.Player.MVP.View;
using HyperCasualRunner.Player.MVP.Presenter;
using HyperCasualRunner.Input;
using HyperCasualRunner.GameCommands;
using HyperCasualRunner.Components;

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
        private CrowdSystem _crowdSystem;
        private Commands _commands;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            Assert.IsNotNull(_playerView);
            Assert.IsNotNull(_runnersParent);

            _playerView.Intialize(transform, _runnersParent);

            _playerModel = new PlayerModel(transform, _runnersParent);
            _touchInput = InputMVP.Instance;
            _commands = Commands.Instance;
            _crowdSystem = new CrowdSystem(_runnersParent, _playerView.CrowdRadius, _playerView.CrowdAngle);
            _playerPresenter = new PlayerPresenter(_playerModel, _playerView, _crowdSystem);
        }

        private void OnEnable()
        {
            _touchInput.ContinuesPrimaryFingerPosition += InputMVP_OnPrimaryFingerPosition;
            _touchInput.FirstPrimaryFingerPosition += InputMVP_OnFirstPrimaryFingerPosition;

            _commands.StartGameplay.AddListener(Commands_StartGamePlay);
        }

        private void OnDisable()
        {
            _touchInput.ContinuesPrimaryFingerPosition -= InputMVP_OnPrimaryFingerPosition;
            _touchInput.FirstPrimaryFingerPosition -= InputMVP_OnFirstPrimaryFingerPosition;

            _commands.StartGameplay.RemoveListener(Commands_StartGamePlay);
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

        private void Commands_StartGamePlay()
        {
            _playerPresenter.StartGamePlay();
        }

        #endregion Event Handlers
    }
}
