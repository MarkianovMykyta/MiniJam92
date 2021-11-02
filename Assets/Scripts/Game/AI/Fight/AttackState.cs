using UnityEngine;

namespace Game.AI.Fight
{
	// INHERITANCE
	public class AttackState : StateBase
	{
		private readonly Chicken _attackTarget;

		public AttackState(StateContext stateContext, Chicken attackTarget) : base(stateContext)
		{
			_attackTarget = attackTarget;
		}
		
		public override void Begin()
		{
		}

		// POLYMORPHISM
		public override void Update()
		{
			if (_attackTarget == null ||
			    Vector3.Distance(StateContext.ChickenBrain.transform.position, _attackTarget.transform.position) >
			    StateContext.WeaponController.ActiveWeapon.Radius)
			{
				StateContext.SetNextState(new SearchForEnemyState(StateContext));
			}
			else
			{
				StateContext.ChickenController.transform.LookAt(_attackTarget.transform);
				StateContext.WeaponController.ActiveWeapon.Attack();
			}
			
			StateContext.ChickenController.PlayMoveAnimation();
		}

		public override void End()
		{
		}
	}
}