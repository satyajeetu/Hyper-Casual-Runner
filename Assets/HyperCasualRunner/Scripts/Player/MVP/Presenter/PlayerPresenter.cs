using HyperCasualRunner.Player.MVP.Model;
using HyperCasualRunner.Player.MVP.View;
using UnityEngine;

namespace HyperCasualRunner.Player.MVP.Presenter
{
    public class PlayerPresenter
    {
        #region Private Fields

        private PlayerView _playerView;
        private PlayerModel _playerModel;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _playerModel = model;
            _playerView = view;
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

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private void MovePlayerForward()
        {
            _playerView.MovePlayerForward(_playerModel.MovePlayerForward());
        }

        #endregion Private Methods
    }
}

