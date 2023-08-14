using System.Collections.Generic;
using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace.Model
{
    public class LevelModel
    {
        #region Public Properties

        public int CurrentLevel => _currentLevel;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        private Dictionary<int, LevelSO> _levels;
        private LevelLoadingService _levelLoadingService;
        private GameObject _currentLevelObject;
        private int _currentLevel = 1;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public LevelModel()
        {
            _levels = new ();
            _levelLoadingService = new();
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void LoadAllLevels()
        {
            foreach (LevelSO level in LevelLoadingService_LoadLevels())
            {
                _levels.TryAdd(level.Level, level);
            }
        }

     
        public void CreateLevel(int levelNumber)
        {
            if (_currentLevelObject != null)
            {
                GameObject.Destroy(_currentLevelObject);
            }

            _currentLevelObject = GameObject.Instantiate(_levels[levelNumber].LevelObject);
        }

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private LevelSO[] LevelLoadingService_LoadLevels()
        {
            return _levelLoadingService.LoadLevels();
        }

        #endregion Private Methods
    }
}
