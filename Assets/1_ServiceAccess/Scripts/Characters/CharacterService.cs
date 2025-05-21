using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        private readonly Dictionary<string, ICharacter> _charactersById = new();

        //lo transforme en singleton para que sea instanciado una sola vez y todos los characters puedan acceder a el mediante la instancia
        public static CharacterService Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //metodos para agregar, quitar y buscar los characters por id 
        public bool TryAddCharacter(string id, ICharacter character)
            => _charactersById.TryAdd(id, character);

        public bool TryRemoveCharacter(string id)
            => _charactersById.Remove(id);

        public bool TryGetCharacter(string id, out ICharacter character)
            => _charactersById.TryGetValue(id, out character);
    }
}
