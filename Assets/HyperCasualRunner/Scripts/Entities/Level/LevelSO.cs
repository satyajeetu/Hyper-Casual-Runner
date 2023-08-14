using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Spawn Level", order = 1)]
    public class LevelSO : ScriptableObject
    {
        public int Level => _level;
        public GameObject LevelObject => _levelObject;

        [SerializeField] private int _level;
        [SerializeField] private GameObject _levelObject;
    }
}
