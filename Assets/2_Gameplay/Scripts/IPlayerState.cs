using UnityEngine;

namespace Gameplay
{
    public interface IPlayerState
    {
        //en esta interfaz se encuentran los metodos que deben aplicar los diferentes estados 
        void Enter();
        void Exit();
        void HandleMove(Vector2 input);
        void HandleJump();
        void OnCollisionEnter(Collision collision);
    }
}