using UnityEngine;

namespace Gameplay
{
    public class GroundedState : IPlayerState
    {
        private readonly Character _character;
        private readonly PlayerStateMachine _stateMachine;

        //Builder

        public GroundedState(Character character, PlayerStateMachine stateMachine)
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
            _character.SetDirection(input.ToHorizontalPlane());
        }

        public void HandleJump()
        {
            _character.StartCoroutine(_character.Jump());
            _stateMachine.SetState(new JumpingState(_character, _stateMachine));
        }

        public void OnCollisionEnter(Collision collision) { }
    }
}