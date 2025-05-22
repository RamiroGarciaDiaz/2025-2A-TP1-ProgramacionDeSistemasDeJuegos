using UnityEngine;

namespace Gameplay
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;

        //method to change the player's state
        public void SetState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        //methods for handling state transitions
        public void HandleMove(Vector2 input) => _currentState?.HandleMove(input);
        public void HandleJump() => _currentState?.HandleJump();
        public void OnCollisionEnter(Collision collision) => _currentState?.OnCollisionEnter(collision);
    }
}