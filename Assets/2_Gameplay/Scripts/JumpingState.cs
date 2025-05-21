using UnityEngine;

namespace Gameplay
{
    public class JumpingState : IPlayerState
    {
        private readonly Character _character;
        private readonly PlayerStateMachine _stateMachine;
        private bool _canDoubleJump = true;

        //constructor
        public JumpingState(Character character, PlayerStateMachine stateMachine)
        {
            _character = character;
            _stateMachine = stateMachine;
        }

        //metodos de la interfaz a la cual esta suscrito 
        public void Enter() { }
        public void Exit() { }

        //metodos aplicados para el cambio de estado
        public void HandleMove(Vector2 input)
        {
            _character.SetDirection(input.ToHorizontalPlane() * 0.5f);
        }

        public void HandleJump()
        {
            if (!_canDoubleJump) return;
            _character.StartCoroutine(_character.Jump());
            _canDoubleJump = false;
        }

        public void OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    _stateMachine.SetState(new GroundedState(_character, _stateMachine));
                    break;
                }
            }
        }
    }
}