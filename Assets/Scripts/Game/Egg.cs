using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class Egg : MonoBehaviour
	{
		[SerializeField] private float _timeForSpawn;
		[SerializeField] private Chicken _chickenPrefab;
		[SerializeField] private Rigidbody _rb;
		[SerializeField] private HealthView _healthView;

		private readonly List<Chicken> _chickensTargetedOnThisEgg = new List<Chicken>();
		
		public bool IsPickedUp;
		public bool IsSpawning { get; private set; }
		public Team Team { get; private set; }
		
		private float _timeForSpawnLeft;

		public void PickUp()
		{
			_rb.isKinematic = true;
			IsPickedUp = true;
		}

		public void ThrowAway()
		{
			_rb.isKinematic = false;
			IsPickedUp = false;
		}

		public bool IsEggFreeForTeam(int teamId)
		{
			for (var i = 0; i < _chickensTargetedOnThisEgg.Count; i++)
			{
				if (_chickensTargetedOnThisEgg[i].Team.TeamId == teamId) return false;
			}

			return true;
		}

		public void AddTargetedChicken(Chicken chicken)
		{
			_chickensTargetedOnThisEgg.Add(chicken);
		}

		public void RemoveTargetedChicken(Chicken chicken)
		{
			_chickensTargetedOnThisEgg.Remove(chicken);
		}
		
		private void StartSpawning(Team team)
		{
			_timeForSpawnLeft = _timeForSpawn;
			Team = team;
			IsSpawning = true;
			
			_healthView.Activate();
		}

		private void StopSpawning()
		{
			IsSpawning = false;

			_healthView.Deactivate();
		}

		private void Update()
		{
			if (!IsSpawning) return;

			_timeForSpawnLeft -= Time.deltaTime;

			_healthView.UpdateValue(1f - _timeForSpawnLeft / _timeForSpawn);

			if (_timeForSpawnLeft <= 0)
			{
				SpawnChicken();
			}
		}

		private void SpawnChicken()
		{
			IsSpawning = false;
			
			var chicken = Instantiate(_chickenPrefab, transform.position, Quaternion.identity);
			Team.AddChicken(chicken);

			Destroy(_healthView.gameObject);
			Destroy(gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			var spawner = other.GetComponent<Spawner>();
			if (spawner != null)
			{
				StartSpawning(spawner.Team);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			var spawner = other.GetComponent<Spawner>();
			if (spawner != null)
			{
				StopSpawning();
			}
		}
	}
}