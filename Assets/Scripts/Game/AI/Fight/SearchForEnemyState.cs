using Game.AI.EggSearch;
using UnityEngine;

namespace Game.AI.Fight
{
	// INHERITANCE
	public class SearchForEnemyState : StateBase
	{
		private float _delayBetweenEnemiesSearch = 3f;

		private float _lastEnemySearchTime;

		private Chicken _targetEnemy;
		
		public SearchForEnemyState(StateContext stateContext) : base(stateContext)
		{
		}

		public override void Begin()
		{
			
		}

		// POLYMORPHISM
		public override void Update()
		{
			SearchForEnemy();

			if (_targetEnemy != null)
			{
				if (!_targetEnemy.IsAlive) _targetEnemy = null;
				else
				{
					StateContext.ChickenController.UpdateMoveTarget(_targetEnemy.transform.position);
					StateContext.ChickenController.PlayMoveAnimation();

					if (Vector3.Distance(StateContext.ChickenBrain.transform.position,
						_targetEnemy.transform.position) < StateContext.WeaponController.ActiveWeapon.Radius)
					{
						StateContext.SetNextState(new AttackState(StateContext, _targetEnemy));
					}
				}
			}
			else
			{
				StateContext.ChickenController.StopMoving();
				StateContext.ChickenController.PlayMoveAnimation();
			}
		}

		// POLYMORPHISM
		public override void End()
		{
			StateContext.ChickenController.StopMoving();
		}

		private void SearchForEnemy()
		{
			if (Time.time < _lastEnemySearchTime + _delayBetweenEnemiesSearch) return;
			
			_lastEnemySearchTime = Time.time;

			var chickens = Object.FindObjectsOfType<Chicken>();

			var distanceToChicken = float.MaxValue;

			for (var i = 0; i < chickens.Length; i++)
			{
				var chicken = chickens[i];
				if(!chicken.IsAlive|| chicken.Team.TeamId == StateContext.ChickenBrain.Team.TeamId) continue;

				var distance = Vector3.Distance(StateContext.ChickenBrain.transform.position, chicken.transform.position);
				if (distance < distanceToChicken)
				{
					distanceToChicken = distance;
					_targetEnemy = chicken;
				}
			}
		}
	}
}