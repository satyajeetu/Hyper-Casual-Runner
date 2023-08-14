using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace
{
    public class LevelLoadingService
    {
        public LevelSO[] LoadLevels()
        {
            return Resources.LoadAll<LevelSO>("Level");
        }
    }
}