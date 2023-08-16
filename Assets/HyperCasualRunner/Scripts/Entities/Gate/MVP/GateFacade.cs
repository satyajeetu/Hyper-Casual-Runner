#region Defines

#define VERBOSE_GATE

#endregion Defines

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HyperCasualRunner.Gate
{
    #region Namespace Properties

    public enum GateMath
    {
        ADD,
        SUBTRACT,
        MULTIPLY,
        DIVIDE
    }

    [Serializable]
    public class GateTriggerd : UnityEvent<int, GateMath> { }

    #endregion NameSpace Properties

    public class GateFacade : MonoBehaviour
    {
        #region Public Properties


        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields


        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization



        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods



        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods


        #endregion Private Methods

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers



        #endregion Event Handlers
    }
}

