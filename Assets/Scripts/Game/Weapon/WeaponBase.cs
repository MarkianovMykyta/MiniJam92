using UnityEngine;

namespace Game.Weapon
{
	public class WeaponBase : MonoBehaviour
	{
		[SerializeField] private float _cooldownTime;
		[SerializeField] private float _radius;
		[SerializeField] private float _damage;
		[SerializeField] private Animator _animator;
		[SerializeField] private string _attackAnimationTrigger;

		private float _prevAttackTime;

		public virtual WeaponType WeaponType { get; private set; }
		public float Radius => _radius;
		public float Damage => _damage;

		public void Attack()
		{
			if (Time.time > _prevAttackTime + _cooldownTime)
			{
				Debug.Log("Attack");
				_animator.SetTrigger(_attackAnimationTrigger);

				_prevAttackTime = Time.time;
			}
		}
	}
}