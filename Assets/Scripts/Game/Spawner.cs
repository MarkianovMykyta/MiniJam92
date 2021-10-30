using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Team _team;
		[SerializeField] private float _timeToSpawn;
		[SerializeField] private Chicken _chickenPrefab;

		private readonly List<EggData> _eggsInZone = new List<EggData>();

		private void Update()
		{
			for (var i = _eggsInZone.Count-1; i >= 0; i--)
			{
				_eggsInZone[i].TimeLeft -= Time.deltaTime;

				if (_eggsInZone[i].TimeLeft <= 0f)
				{
					SpawnChicken(_eggsInZone[i].Egg);
					_eggsInZone.RemoveAt(i);
				}
			}
		}

		private void SpawnChicken(GameObject egg)
		{
			Destroy(egg);
			
			var chicken = Instantiate(_chickenPrefab, egg.transform.position, Quaternion.identity);
			
			_team.AddChicken(chicken);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Egg"))
			{
				if(_eggsInZone.Exists(x => x.Egg == other.gameObject)) return;
				
				var eggData = new EggData(other.gameObject, _timeToSpawn);
				_eggsInZone.Add(eggData);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Egg"))
			{
				_eggsInZone.RemoveAll(x => x.Egg == other.gameObject);
			}
		}
	}
}