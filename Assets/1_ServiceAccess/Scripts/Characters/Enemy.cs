using UnityEngine;

namespace Excercise1
{
    public class Enemy : Character
    {
        [SerializeField] private float speed = 5;
        [SerializeField] private string playerId = "Player";
        private ICharacter _player;
        private string _logTag;

        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
            => _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";

        //Id search is applied
        protected override void OnEnable()
        {
            base.OnEnable();
            if (CharacterService.Instance != null && CharacterService.Instance.TryGetCharacter(playerId, out _player))
            {
         
            }
            else
            {
                Debug.LogError($"{_logTag} Player not found!");
            }
        }

        private void Update()
        {
            if (_player == null)
                return;

            var direction = _player.transform.position - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);
        }
    }
}
