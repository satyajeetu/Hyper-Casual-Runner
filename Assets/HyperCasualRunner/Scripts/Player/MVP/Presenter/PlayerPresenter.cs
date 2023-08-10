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

        public void PrimaryFingerOnScreen(Vector2 currentFingerPosition)
        {
            _playerView.UpdatePlayerPosition(_playerModel.UpdatePlayerPosition(currentFingerPosition));
        }

        public void CustomUpdate()
        {
            MoveForward();
        }

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private void MoveForward()
        {
            _playerView.MoveForward(_playerModel.MoveUserForward());
        }

        #endregion Private Methods
    }
}

