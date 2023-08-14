using HyperCasualRunner.GameManager.MVP.Model;
using HyperCasualRunner.GameManager.MVP.View;
using HyperCasualRunner.LevelManagerSpace;

namespace HyperCasualRunner.GameManager.Presenter
{
    #region Namespace Properties

    public delegate void LevelGenerationComplete();

    #endregion Namespace Properties

    public class GameManagerPresenter
    {
        #region Public Properties

        public LevelGenerationComplete onLevelGenerationComplete;

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        private GameManagerModel _gameManagerModel;
        private GameManagerView _gameManagerView;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization

        public GameManagerPresenter()
        {
            _gameManagerModel = new GameManagerModel();
            _gameManagerView = new GameManagerView();
        }

        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods

        public void GenerateCurrentLevel(LevelManager levelManager)
        {
            LevelManager_GenerateLevel(levelManager);
        }

        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private void LevelManager_GenerateLevel(LevelManager levelManager)
        {
            levelManager.CreateLevel();
            onLevelGenerationComplete?.Invoke();
        }

        #endregion Private Methods;
    }
}