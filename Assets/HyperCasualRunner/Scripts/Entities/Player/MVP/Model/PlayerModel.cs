#region Defines

// #define VERBOSE_PLAYER

#endregion Defines

using UnityEngine;
using HyperCasualRunner.ComponentsSpace;

namespace HyperCasualRunner.PlayerSpace.MVP.Model
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

        public void PlaceRunners(CrowdSystem crowdSystem)
        {
            crowdSystem.PlaceRunners(_runnersParent);
        }

        public void CreateRunners(int count, GameObject runnerPrefab)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject.Instantiate(runnerPrefab, _runnersParent);

#if VERBOSE_PLAYER
                Debug.Log("runner created");
#endif // VERBOSE_PLAYER
            }
        }

        #endregion Public Methods
    }
}
