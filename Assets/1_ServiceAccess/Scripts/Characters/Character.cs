using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        //la variable id ahora se puede modificar desde el editor de unity 
        [SerializeField] protected string id;

        protected virtual void OnEnable()
        {
            //ahora se registran automaticamente los personajes con id
            CharacterService.Instance?.TryAddCharacter(id, this);
        }

        protected virtual void OnDisable()
        {
            CharacterService.Instance?.TryRemoveCharacter(id);
        }
    }
}