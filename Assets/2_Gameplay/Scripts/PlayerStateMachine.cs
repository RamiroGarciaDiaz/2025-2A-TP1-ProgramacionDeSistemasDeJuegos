using UnityEngine;

namespace Gameplay
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;

        //metodo para cambiar el estado del player
        public void SetState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        //metodos para manejar las tranciciones de estados 
        public void HandleMove(Vector2 input) => _currentState?.HandleMove(input);
        public void HandleJump() => _currentState?.HandleJump();
        public void OnCollisionEnter(Collision collision) => _currentState?.OnCollisionEnter(collision);
    }
}