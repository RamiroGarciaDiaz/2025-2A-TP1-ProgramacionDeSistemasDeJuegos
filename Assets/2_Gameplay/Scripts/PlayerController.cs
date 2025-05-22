    using UnityEngine;
    using UnityEngine.InputSystem;

    namespace Gameplay
    {
        [RequireComponent(typeof(Character))]
        public class PlayerController : MonoBehaviour
        {
            [SerializeField] private InputActionReference moveInput;
            [SerializeField] private InputActionReference jumpInput;

            private Character _character;
            private PlayerStateMachine _stateMachine;

            private void Awake()
            {
                _character = GetComponent<Character>();
                _stateMachine = new PlayerStateMachine();
                _stateMachine.SetState(new GroundedState(_character, _stateMachine));
            }
            
            //event subscriptions 
            private void OnEnable()
            {
                moveInput.action.performed += OnMove;
                moveInput.action.canceled += OnMove;
                jumpInput.action.performed += OnJump;
            }

            private void OnDisable()
            {
                moveInput.action.performed -= OnMove;
                moveInput.action.canceled -= OnMove;
                jumpInput.action.performed -= OnJump;
            }
            
            //methods to control movement
            private void OnMove(InputAction.CallbackContext ctx)
            {
                _stateMachine.HandleMove(ctx.ReadValue<Vector2>());
            }
            
            private void OnJump(InputAction.CallbackContext ctx)
            {
                _stateMachine.HandleJump();
            }

            private void OnCollisionEnter(Collision collision)
            {
                _stateMachine.OnCollisionEnter(collision);
            }
        }
    }



