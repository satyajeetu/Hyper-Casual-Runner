using Custom.Generics;
using UnityEngine;
using UnityEngine.Events;

namespace HyperCasualRunner.CommandsSpace
{
    [DefaultExecutionOrder(-1)]
    public class Commands : Singleton<Commands>
    {
        [HideInInspector] public UnityEvent StartGameplay = new UnityEvent();
        [HideInInspector] public UnityEvent AllLevelsLoaded = new UnityEvent();
    }
}
