using System;
using Game.Weapon;
using UnityEngine;

namespace Game
{
	public class Chicken : MonoBehaviour, IDestructible
	{
		[SerializeField] private float _maxHealth;
		[SerializeField] protected ChickenController ChickenController;
		[SerializeField] protected WeaponController WeaponController;
		[SerializeField] private int _teamId;
		
		public float Health {get;  private set; }

		public bool IsAlive => Health > 0;

		public int TeamId
		{
			get => _teamId;
			set => _teamId = value;
		}

		public void ApplyDamage(float damage)
		{
			if(!IsAlive) return;
			
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
			if (!IsAlive) return;
			
			OnUpdate();
		}

		protected virtual void OnStart(){}
		protected virtual void OnUpdate(){}
		
		private void Die()
		{
			if(!IsAlive) return;
			
			ChickenController.PlayDeathAnimation(DestroyAfterDeath);
		}

		private void DestroyAfterDeath()
		{
			Destroy(gameObject);
		}
		
		
	}
}