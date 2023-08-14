using UnityEngine;
using UnityEngine.Assertions;

namespace HyperCasualRunner.PlayerSpace.MVP.View
{
    public class PlayerView : MonoBehaviour
    {
        #region Public Properties

        public float CrowdRadius => _crowdRadius;
        public float CrowdAngle => _crowdAngle;
        public int CrowdIntitalCount => _runnersIntialCount;
        public GameObject RunnerPrefab => _runner;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        [Header("Elements")]
        [SerializeField] private GameObject _runner;

        [Header("Settings")]
        [SerializeField] private float _crowdRadius = 0.3f;
        [SerializeField] private float _crowdAngle = 137.508f;
        [SerializeField] private int _runnersIntialCount = 6;

        private Transform _playerTransform;
        private Transform _runnersParent;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            Assert.IsNotNull(_runner);
        }

        #endregion Unity

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
