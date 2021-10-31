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

		public abstract WeaponType WeaponType { get; }
		public float Radius => _radius;
		public float Damage => _damage;
		
		public Team Team { get; private set; }

		public void Initialize(Team team)
		{
			Team = team;

			_cooldownTime += Random.Range(-0.3f, 0.3f);
		}

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

		public void Activate()
		{
			for (var i = 0; i < _weaponObjects.Length; i++)
			{
				_weaponObjects[i].SetActive(true);
			}
		}

		public void Deactivate()
		{
			for (var i = 0; i < _weaponObjects.Length; i++)
			{
				_weaponObjects[i].SetActive(false);
			}
		}
	}
}