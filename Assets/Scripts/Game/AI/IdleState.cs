using Game.AI.EggSearch;
using Game.AI.Fight;
using Game.Weapon;
using UnityEngine;

namespace Game.AI
{
	public class IdleState : StateBase
	{
		public IdleState(StateContext stateContext) : base(stateContext)
		{
		}

		public override void Begin()
		{
			if (Random.value > 0.5f)
			{
				StateContext.Inventory.Activate();
				StateContext.WeaponController.SetWeapon(WeaponType.None);
				StateContext.SetNextState(new SearchForEggState(StateContext));
			}
			else
			{
				StateContext.Inventory.Deactivate();
				StateContext.WeaponController.SetWeapon(WeaponType.Spear);
				StateContext.SetNextState(new SearchForEnemyState(StateContext));
			}

			
		}

		public override void Update()
		{
		}

		public override void End()
		{
		}
	}
}