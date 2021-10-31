using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Inventory : MonoBehaviour
	{
		public event Action<Egg> PickedUp;
		
		[SerializeField] private Transform _slot;
		[SerializeField] private float _ignoreObjectAfterThrowTime;
		
		private Egg _egg;
		private int _teamId;
		
		private readonly List<Egg> _eggsToIgnore = new List<Egg>();
		
		public bool IsEmpty => _egg == null;

		public void Initialize(int teamId)
		{
			_teamId = teamId;
		}

		public void Activate()
		{
			ThrowAway();
			gameObject.SetActive(true);
		}
		
		public void Deactivate()
		{
			gameObject.SetActive(false);
		}

		public void ThrowAway()
		{
			if (IsEmpty) return;

			_egg.GetComponent<Rigidbody>().isKinematic = false;

			StartCoroutine(IgnoreEggForSeconds(_egg, _ignoreObjectAfterThrowTime));
			
			_egg.ThrowAway();
			
			_egg = null;
		}

		private void Update()
		{
			if (IsEmpty) return;

			_egg.transform.position = Vector3.Lerp(_egg.transform.position, _slot.position, 0.3f);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!IsEmpty) return;

			var egg = other.GetComponent<Egg>();
			
			if (egg != null)
			{
				if (egg.IsPickedUp) return;
				if (egg.IsSpawning && egg.Team.TeamId == _teamId) return;
				if (_eggsToIgnore.Contains(egg)) return;

				_egg = egg;
				_egg.transform.rotation = _slot.rotation;
				_egg.PickUp();
				PickedUp?.Invoke(_egg);
			}
		}

		private IEnumerator IgnoreEggForSeconds(Egg egg, float ignoreTime)
		{
			_eggsToIgnore.Add(egg);

			yield return new WaitForSeconds(ignoreTime);

			_eggsToIgnore.Remove(egg);
		}
	}
}