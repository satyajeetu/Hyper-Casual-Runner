using UnityEngine;

namespace HyperCasualRunner.ComponentsSpace
{
    public class CrowdSystem
    {
        [Header("Settings")]
        private float _radius = 1.0f;
        private float _angle = 137.508f;
        private Transform _runnersParent;

        public CrowdSystem(Transform runnersParent, float radius = 1.0f, float angle = 137.508f)
        {
            _runnersParent = runnersParent;
            _radius = radius;
            _angle = angle;
        }

        public void PlaceRunners(Transform transformParent)
        {
            for (int childIndex = 0; childIndex < transformParent.childCount; childIndex++)
            {
                Vector3 childLocalPosition = GetRunnerLocalPosition(childIndex);
                transformParent.GetChild(childIndex).localPosition = childLocalPosition;
            }
        }

        private Vector3 GetRunnerLocalPosition(int index)
        {
            float x = _radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * _angle);
            float z = _radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * _angle);

            return new Vector3(x, 0, z);
        }

        public float GetCrowdRadius()
        {
            return _radius * Mathf.Sqrt(_runnersParent.childCount);
        }
    }
}
