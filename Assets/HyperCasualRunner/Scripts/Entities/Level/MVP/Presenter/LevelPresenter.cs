using System;
using System.Collections;
using System.Collections.Generic;
using HyperCasualRunner.LevelManagerSpace.Model;
using HyperCasualRunner.LevelManagerSpace.View;
using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace.Presenter
{
    #region Namespace Properties

    public delegate void AllLevelsLoaded();

    #endregion Namespace Properties

    public class LevelPresenter
    {
        #region Public Properties

        public event AllLevelsLoaded AllLevelsLoaded;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        private LevelModel _levelModel;
        private LevelView _levelView;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Initialization

        public LevelPresenter()
        {
            _levelModel = new LevelModel();
            _levelView = new LevelView();
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void LoadAllLevels()
        {
            _levelModel.LoadAllLevels();
            AllLevelsLoaded?.Invoke();
        }

        public void CreateLevel()
        {
            _levelModel.CreateLevel(_levelModel.CurrentLevel);
            _levelView.DebugInfo("current level " + _levelModel.CurrentLevel);
        }

        #endregion Public Methods
    }
}
