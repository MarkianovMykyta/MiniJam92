using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Weapon
{
	public class Spear : WeaponBase
	{
		[SerializeField] private Transform _damagePosition;
		[SerializeField] private float _damageRadius;
		[SerializeField] private float _damageTime;

		private readonly Collider[] _attackCollidersCash = new Collider[10];
		
		public override WeaponType WeaponType => WeaponType.Spear;

		protected override async void OnAttackStarted()
		{
			await Task.Delay(TimeSpan.FromSeconds(_damageTime));
			
			Debug.Log("Attack!");
			
			var size = Physics.OverlapSphereNonAlloc(_damagePosition.position, _damageRadius, _attackCollidersCash);

			for (var i = 0; i < size; i++)
			{
				var chicken = _attackCollidersCash[i].GetComponent<Chicken>();
				if (chicken != null && chicken.Team.TeamId != Team.TeamId)
				{
					chicken.ApplyDamage(Damage);
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(_damagePosition.position, _damageRadius);
		}
	}
}