using UnityEngine;

using HyperCasualRunner.Player.MVP.Model;
using HyperCasualRunner.Player.MVP.View;
using HyperCasualRunner.Components;

namespace HyperCasualRunner.Player.MVP.Presenter
{
    public class PlayerPresenter
    {
        #region Private Fields

        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private CrowdSystem _crowdSystem;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public PlayerPresenter(PlayerModel model, PlayerView view, CrowdSystem crowdSystem)
        {
            _playerModel = model;
            _playerView = view;
            _crowdSystem = crowdSystem;
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void PrimaryFingerOnScreen(Vector2 currentFingerPosition, float screenWidth)
        {
            _playerView.UpdateRunnersParentLocalPosition(_playerModel.UpdateRunnersParentLocalPosition(currentFingerPosition, screenWidth));
        }

        public void FirstPrimaryTouchOnScreen(Vector2 currentFingerPosition)
        {
            _playerModel.FirstPrimaryTouchPosition(currentFingerPosition);
        }

        public void CustomUpdate()
        {
            MovePlayerForward();
        }

        public void StartGamePlay()
        {
            CreateRunners(_playerView.CrowdIntitalCount);
        }

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private void MovePlayerForward()
        {
            _playerView.MovePlayerForward(_playerModel.MovePlayerForward());
        }

        private void CreateRunners(int count)
        {
            _playerModel.CreateRunners(count, _playerView.RunnerPrefab);
            _playerModel.PlaceRunners(_crowdSystem);
        }

        #endregion Private Methods
    }
}

