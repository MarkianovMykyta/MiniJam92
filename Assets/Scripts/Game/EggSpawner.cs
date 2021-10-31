using System.Collections;
using UnityEngine;

namespace Game
{
	public class EggSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _eggPrefab;
		[SerializeField] private float _spawnRadius;
		[SerializeField] private float _delayBetweenSpawns;
		[SerializeField] private GameSettings _gameSettings;
		
		private void Start()
		{
			StartCoroutine(SpawnEggsRoutine());
		}

		private IEnumerator SpawnEggsRoutine()
		{
			var eggsCount = _gameSettings.MaxNumberOfChickens;
			for (var i = 0; i < eggsCount; i++)
			{
				var spawnPosition = transform.position;
				spawnPosition.x += Random.Range(-_spawnRadius, _spawnRadius);
				spawnPosition.z += Random.Range(-_spawnRadius, _spawnRadius);
				Instantiate(_eggPrefab, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(_delayBetweenSpawns);
			}
		}
	}
}