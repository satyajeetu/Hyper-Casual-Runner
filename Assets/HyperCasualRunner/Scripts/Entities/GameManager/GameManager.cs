using UnityEngine;
using HyperCasualRunner.GameCommands;

namespace HyperCasualRunner.GameManager
{
    [DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Commands.Instance.StartGameplay?.Invoke();
        }
    }
}

