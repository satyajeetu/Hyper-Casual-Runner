using System;
using System.Windows.Input;
using Custom.Generics;
using HyperCasualRunner.CommandsSpace;
using HyperCasualRunner.LevelManagerSpace.Presenter;
using UnityEngine;

namespace HyperCasualRunner.LevelManagerSpace
{
    [DefaultExecutionOrder(-1)]
    public class LevelManager : Singleton<LevelManager>
    {
        #region Private Fields

        private Commands _commands;
        private LevelPresenter _levelPresenter;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            _commands = Commands.Instance;
            _levelPresenter = new LevelPresenter();
        }

        private void OnEnable()
        {
            _levelPresenter.AllLevelsLoaded += LevelPresenter_OnAllLevelsLoaded;
        }

        private void OnDisable()
        {
            _levelPresenter.AllLevelsLoaded -= LevelPresenter_OnAllLevelsLoaded;
        }

        private void Start()
        {
            _levelPresenter.LoadAllLevels();
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void CreateLevel()
        {
            _levelPresenter.CreateLevel();
        }

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void LevelPresenter_OnAllLevelsLoaded()
        {
            Commands_InvokeAllLevelsLoaded();
        }

        private void Commands_InvokeAllLevelsLoaded()
        {
            _commands.AllLevelsLoaded?.Invoke();
        }

        #endregion Event Handlers
    }
}
