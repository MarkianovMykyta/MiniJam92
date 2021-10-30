using System;
using UnityEngine;

namespace Game
{
	public class Chicken : MonoBehaviour, IDestructible
	{
		[SerializeField] private float _maxHealth;
		[SerializeField] protected ChickenController ChickenController;
		
		public float Health { private set; get; }

		public bool IsAlive => Health > 0;
		
		public void ApplyDamage(float damage)
		{
			Health = Mathf.Max(0, Health - damage);

			if (Health == 0)
			{
				Die();
			}
		}
		
		private void Start()
		{
			Health = _maxHealth;

			OnStart();
		}

		private void Update()
		{
			OnUpdate();
		}

		protected virtual void OnStart(){}
		protected virtual void OnUpdate(){}
		
		private void Die()
		{
			ChickenController.PlayDeathAnimation(DestroyAfterDeath);
		}

		private void DestroyAfterDeath()
		{
			Destroy(gameObject);
		}
	}
}