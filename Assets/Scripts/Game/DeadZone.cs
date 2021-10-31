using System;
using UnityEngine;

namespace Game
{
	public class DeadZone : MonoBehaviour
	{
		[SerializeField] private Transform _eggsRespawn;

		private void OnTriggerEnter(Collider other)
		{
			other.gameObject.transform.position = _eggsRespawn.position;
		}
	}
}