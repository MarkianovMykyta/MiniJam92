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
		[SerializeField] private Slider _progressbar;
		[SerializeField] private Animator _uiAnimator;

		private readonly List<Chicken> _chickensTargetedOnThisEgg = new List<Chicken>();
		
		public bool IsPickedUp;
		public bool IsSpawning { get; private set; }
		public Team Team { get; private set; }
		
		private float _timeForSpawnLeft;

		private void Start()
		{
			_uiAnimator.transform.SetParent(null);
		}

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
			
			_uiAnimator.gameObject.SetActive(true);
			_uiAnimator.SetTrigger("Appear");
		}

		private void StopSpawning()
		{
			IsSpawning = false;

			_uiAnimator.SetTrigger("Disappear");
		}

		private void Update()
		{
			if (!IsSpawning) return;

			_timeForSpawnLeft -= Time.deltaTime;

			_progressbar.value = Mathf.Clamp01(1f - _timeForSpawnLeft / _timeForSpawn);
			_progressbar.transform.parent.position = transform.position;

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

			Destroy(_uiAnimator.gameObject);
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