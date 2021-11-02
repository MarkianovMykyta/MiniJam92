using UnityEngine;

namespace Game.Weapon
{
	public abstract class WeaponBase : MonoBehaviour
	{
		[SerializeField] private float _cooldownTime;
		[SerializeField] private float _radius;
		[SerializeField] private float _damage;
		[SerializeField] private Animator _animator;
		[SerializeField] private string _attackAnimationTrigger;
		[SerializeField] private GameObject[] _weaponObjects;

		private float _prevAttackTime;
		
		// ENCAPSULATION
		public bool IsActive { get; private set; }

		// ENCAPSULATION
		public abstract WeaponType WeaponType { get; }
		// ENCAPSULATION
		public float Radius => _radius;
		// ENCAPSULATION
		public float Damage => _damage;
		// ENCAPSULATION
		public Team Team { get; private set; }

		public void Initialize(Team team)
		{
			Team = team;

			_cooldownTime += Random.Range(-0.3f, 0.3f);
		}

		// ABSTRACTION
		public void Attack()
		{
			if (Time.time > _prevAttackTime + _cooldownTime)
			{
				_animator.SetTrigger(_attackAnimationTrigger);

				_prevAttackTime = Time.time;
				
				OnAttackStarted();
			}
		}

		protected virtual void OnAttackStarted()
		{
			
		}

		// ABSTRACTION
		public void Activate()
		{
			for (var i = 0; i < _weaponObjects.Length; i++)
			{
				_weaponObjects[i].SetActive(true);
			}

			IsActive = true;
		}

		// ABSTRACTION
		public void Deactivate()
		{
			for (var i = 0; i < _weaponObjects.Length; i++)
			{
				_weaponObjects[i].SetActive(false);
			}

			IsActive = false;
		}
	}
}