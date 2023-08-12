using UnityEngine;

namespace HyperCasualRunner.Player.MVP.View
{
    public class PlayerView : MonoBehaviour
    {
        #region Private Fields

        private Transform _playerTransform;
        private Transform _runnersParent;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public void Intialize(Transform playerTransform, Transform runnersParent)
        {
            _playerTransform = playerTransform;
            _runnersParent = runnersParent;
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void UpdateRunnersParentLocalPosition(float positionX)
        {
            Vector3 pos = _runnersParent.localPosition;
            _runnersParent.localPosition = new Vector3(positionX, pos.y, pos.z);
        }

        public void MovePlayerForward(Vector3 position)
        {
            _playerTransform.position = position;
        }

        #endregion Public Methods
    }
}
