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
		[SerializeField] private GameObject _eggPrefab;
		
		[SerializeField] private HealthView _healthView;

		public float Health {get;  private set; }

		public bool IsAlive => Health > 0;

		public Team Team { get; private set; }

		public virtual void Initialize(Team team)
		{
			Health = _maxHealth;
			Team = team;
			WeaponController.Initialize(team);
			ChickenController.SetTeamMaterial(team.TeamMaterial);
			Inventory.Initialize(team.TeamId);
			
			_healthView.Activate();
		}

		public void ApplyDamage(float damage)
		{
			if(!IsAlive) return;
			
			Health = Mathf.Max(0, Health - damage);

			_healthView.UpdateValue(Health/_maxHealth);
			
			if (Health == 0)
			{
				Die();
			}
		}

		private void Awake()
		{
			OnAwake();
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

		protected virtual void OnAwake(){}
		protected virtual void OnStart(){}
		protected virtual void OnUpdate(){}
		protected virtual void OnDie(){}
		
		private void Die()
		{
			_healthView.Deactivate();
			ChickenController.StopMoving();
			ChickenController.PlayDeathAnimation(DestroyAfterDeath);
			Inventory.ThrowAway();
			WeaponController.ActiveWeapon.Deactivate();
			Died?.Invoke(this);
			
			OnDie();
		}

		private void DestroyAfterDeath()
		{
			Destroy(gameObject);
			Destroy(_healthView.gameObject);

			Instantiate(_eggPrefab, transform.position, Quaternion.identity);
		}
	}
}