using UnityEngine;

namespace HyperCasualRunner.Player.MVP.Model
{
    public class PlayerModel
    {
        #region Private Fields

        private float _runnersSlideSpeed = 6.0f;
        private float _forwardShift = 6.0f;
        private Transform _runnersParent;
        private Transform _playerTransform;
        private Vector2 _firstPrimaryTouch;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public PlayerModel(Transform playerTransform, Transform runnersParent)
        {
            _playerTransform = playerTransform;
            _runnersParent = runnersParent;
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public float UpdateRunnersParentLocalPosition(Vector2 touchPosition, float screenWidth)
        {
            float xScreenDiff = touchPosition.x - _firstPrimaryTouch.x;
            xScreenDiff /= screenWidth;
            xScreenDiff *= _runnersSlideSpeed;
            return xScreenDiff;
        }

        public Vector3 MovePlayerForward()
        {
            Vector3 currentPosition = _playerTransform.position;
            currentPosition.z += _forwardShift * Time.deltaTime;
            return currentPosition;
        }

        public void FirstPrimaryTouchPosition(Vector2 currentFingerPosition)
        {
            _firstPrimaryTouch = currentFingerPosition;
        }

        #endregion Public Methods
    }
}
