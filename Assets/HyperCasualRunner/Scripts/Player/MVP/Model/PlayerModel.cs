
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HyperCasualRunner.Player.MVP.Model
{
    public class PlayerModel
    {
        #region Private Fields

        private Camera _mainCamera;
        private float _horizontalShift = 6.0f;
        private float _forwardShift = 6.0f;
        private Transform _playerTransform;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public PlayerModel(Camera mainCamera, Transform playerTransform)
        {
            _mainCamera = mainCamera;
            _playerTransform = playerTransform;
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public float UpdatePlayerPosition(Vector2 touchPosition)
        {
            return _mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, _mainCamera.nearClipPlane)).x * _horizontalShift;
        }

        public Vector3 MoveUserForward()
        {
            Vector3 currentPosition = _playerTransform.position;
            currentPosition.z += _forwardShift * Time.deltaTime;
            return currentPosition;
        }

        #endregion Public Methods
    }
}
