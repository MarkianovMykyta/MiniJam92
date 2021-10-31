using System.Collections;
using UnityEngine;

namespace Game
{
	public class EggSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _eggPrefab;
		[SerializeField] private float _spawnRadius;
		[SerializeField] private int _eggsCount;
		[SerializeField] private float _delayBetweenSpawns;
		
		private void Start()
		{
			StartCoroutine(SpawnEggsRoutine());
		}

		private IEnumerator SpawnEggsRoutine()
		{
			for (var i = 0; i < _eggsCount; i++)
			{
				var spawnPosition = transform.position;
				spawnPosition.x = Random.Range(-_spawnRadius, _spawnRadius);
				spawnPosition.z = Random.Range(-_spawnRadius, _spawnRadius);
				Instantiate(_eggPrefab, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(_delayBetweenSpawns);
			}
		}
	}
}