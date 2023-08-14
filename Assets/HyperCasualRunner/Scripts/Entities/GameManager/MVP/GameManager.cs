using UnityEngine;
using HyperCasualRunner.CommandsSpace;
using HyperCasualRunner.LevelManagerSpace;
using HyperCasualRunner.GameManager.Presenter;

namespace HyperCasualRunner.GameManager.MVP
{
    [DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        #region Private Fields

        private Commands _commands;
        private LevelManager _levelManager;
        private GameManagerPresenter  _gameManagerPresenter;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            _commands = Commands.Instance;
            _levelManager = LevelManager.Instance;
            _gameManagerPresenter = new GameManagerPresenter();
        }
    
        private void OnEnable()
        {
            _commands.AllLevelsLoaded.AddListener(Commands_OnAllLevelsLoaded);
            _gameManagerPresenter.onLevelGenerationComplete += GameManagerPresenter_OnLevelGenerationComplete;
        }

        private void OnDisable()
        {
            _commands.AllLevelsLoaded.RemoveListener(Commands_OnAllLevelsLoaded);
            _gameManagerPresenter.onLevelGenerationComplete -= GameManagerPresenter_OnLevelGenerationComplete;
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers

        private void Commands_OnAllLevelsLoaded()
        {
            _gameManagerPresenter.GenerateCurrentLevel(_levelManager);
        }

        private void GameManagerPresenter_OnLevelGenerationComplete()
        {
            Commands_InvokeStartGameplay();
        }

        private void Commands_InvokeStartGameplay()
        {
            _commands.StartGameplay?.Invoke();
        }

        #endregion Event Handlers
    }
}

