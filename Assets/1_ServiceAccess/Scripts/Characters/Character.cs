using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        //The id variable can now be modified from the Unity editor.
        [SerializeField] protected string id;

        protected virtual void OnEnable()
        {
            //Characters with id are now automatically registered
            CharacterService.Instance?.TryAddCharacter(id, this);
        }

        protected virtual void OnDisable()
        {
            CharacterService.Instance?.TryRemoveCharacter(id);
        }
    }
}