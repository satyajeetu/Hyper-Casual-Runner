
using System;
using UnityEngine;

namespace HyperCasualRunner.Player.MVP.View
{
    public class PlayerView : MonoBehaviour
    {
        #region Public Methods

        public void UpdatePlayerPosition(float positionX)
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(positionX, pos.y, pos.z);
        }

        public void MoveForward(Vector3 position)
        {
            transform.position = position;
        }

        #endregion Public Methods
    }
}
