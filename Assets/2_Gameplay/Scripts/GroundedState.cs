using UnityEngine;

namespace Gameplay
{
    public class GroundedState : IPlayerState
    {
        private readonly Character _character;
        private readonly PlayerStateMachine _stateMachine;

        //contructor 

        public GroundedState(Character character, PlayerStateMachine stateMachine)
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