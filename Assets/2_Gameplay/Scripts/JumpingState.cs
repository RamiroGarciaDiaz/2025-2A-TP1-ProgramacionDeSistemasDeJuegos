using UnityEngine;

namespace Gameplay
{
    public class JumpingState : IPlayerState
    {
        private readonly Character _character;
        private readonly PlayerStateMachine _stateMachine;
        private bool _canDoubleJump = true;

        //Builder
        public JumpingState(Character character, PlayerStateMachine stateMachine)
        {
            _character = character;
            _stateMachine = stateMachine;
        }

        //methods of the interface to which it is subscribed 
        public void Enter() { }
        public void Exit() { }

        //methods applied for the change of state
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