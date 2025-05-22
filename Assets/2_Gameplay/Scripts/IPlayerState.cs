using UnityEngine;

namespace Gameplay
{
    public interface IPlayerState
    {
        //In this interface are the methods that the different states must apply.
        void Enter();
        void Exit();
        void HandleMove(Vector2 input);
        void HandleJump();
        void OnCollisionEnter(Collision collision);
    }
}