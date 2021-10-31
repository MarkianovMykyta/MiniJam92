using System;
using Game.Weapon;
using UnityEngine;

namespace Game
{
	public class Chicken : MonoBehaviour, IDestructible
	{
		public event Action<Chicken> Died; 

		[SerializeField] private float _maxHealth;
		[SerializeField] protected ChickenController ChickenController;
		[SerializeField] protected WeaponController WeaponController;
		[SerializeField] protected Inventory Inventory;

		public float Health {get;  private set; }

		public bool IsAlive => Health > 0;

		public Team Team { get; private set; }

		public virtual void Initialize(Team team)
		{
			Health = _maxHealth;
			Team = team;
			WeaponController.SetWeapon(WeaponType.None);
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
			Died?.Invoke(this);
		}

		private void DestroyAfterDeath()
		{
			Destroy(gameObject);
		}
		
		
	}
}