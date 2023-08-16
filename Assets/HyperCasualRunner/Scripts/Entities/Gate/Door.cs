#region Defines

#define VERBOSE_GATE

#endregion Defines

using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

using System.Collections.Generic;

namespace HyperCasualRunner.Gate
{
    #region Namespace Properties



    #endregion NameSpace Properties

    public class Door : MonoBehaviour
    {
        #region Public Properties

        [HideInInspector] public GateTriggerd OnCurrentDoorHit = new();

        #endregion Public Properties

        //------------------------------------------------------------------------------------------------------------

        #region Private Fields

        [Header("Elements")]
        [SerializeField] private TextMeshPro _text;

        [Header("Settings")]
        [SerializeField] private string _runnerTag = "RUNNER";
        [SerializeField] private int _variable = 1;
        [SerializeField] private GateMath _currentGateMath = GateMath.ADD;
        [SerializeField] private Vector3 _boxSize = new(3f, 3f, 1f);

        private Dictionary<GateMath, string> _gameMathCharacter;

        #endregion Private Fields

        //------------------------------------------------------------------------------------------------------------

        #region Intialization



        #endregion Intialization

        //------------------------------------------------------------------------------------------------------------

        #region Unity

        private void Awake()
        {
            Assert.IsNotNull(_runnerTag);
            Assert.IsNotNull(_text);
            GenerateGameMathCharacterList();
        }

        private void Start()
        {
            _text.text = _gameMathCharacter[_currentGateMath] + _variable.ToString();
        }

        private void FixedUpdate()
        {
            CheckIfRunner();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, _boxSize);
        }

        #endregion Unity

        //------------------------------------------------------------------------------------------------------------

        #region Public Methods



        #endregion Public Methods

        //------------------------------------------------------------------------------------------------------------

        #region Private Methods

        private void GenerateGameMathCharacterList()
        {
            _gameMathCharacter = new Dictionary<GateMath, string>
            {
                { GateMath.ADD, "+" },
                { GateMath.SUBTRACT, "-" },
                { GateMath.MULTIPLY, "x" },
                { GateMath.DIVIDE, "%" }
            };
        }

        private void CheckIfRunner()
        {
            RaycastHit[] hits = Physics.BoxCastAll(transform.position, _boxSize / 2, transform.forward, Quaternion.identity);

            if (hits.Length == 0)
            {
                return;
            }

            foreach (RaycastHit raycastHit in hits)
            {
                if (!(raycastHit.collider.tag == _runnerTag))
                {
                    continue;
                }

                Debug.Log("Hit Runner");
            }
        }

        #endregion Private Methods

        //------------------------------------------------------------------------------------------------------------

        #region Event Handlers



        #endregion Event Handlers
    }
}
