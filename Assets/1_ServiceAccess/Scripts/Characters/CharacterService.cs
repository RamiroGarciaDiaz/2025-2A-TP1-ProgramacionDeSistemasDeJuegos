using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        private readonly Dictionary<string, ICharacter> _charactersById = new();

        //I transformed it into a singleton so that it is instantiated only once and all characters can access it through the instance
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

        //Methods to add, remove, and search for characters by id 
        public bool TryAddCharacter(string id, ICharacter character)
            => _charactersById.TryAdd(id, character);

        public bool TryRemoveCharacter(string id)
            => _charactersById.Remove(id);

        public bool TryGetCharacter(string id, out ICharacter character)
            => _charactersById.TryGetValue(id, out character);
    }
}
