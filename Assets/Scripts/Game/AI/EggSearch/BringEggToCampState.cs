using UnityEngine;

namespace Game.AI.EggSearch
{
	public class BringEggToCampState : StateBase
	{
		private float _throwDistance = 3f;
		
		public BringEggToCampState(StateContext stateContext) : base(stateContext)
		{
		}

		private Spawner _targetSpawner;

		public override void Begin()
		{
			SearchForSpawner();
		}

		public override void Update()
		{
			if(_targetSpawner == null) return;
			
			if (Vector3.Distance(StateContext.ChickenBrain.transform.position, _targetSpawner.transform.position) <
			    _throwDistance)
			{
				StateContext.Inventory.ThrowAway();
				StateContext.SetNextState(new IdleState(StateContext));
			}
			else
			{
				StateContext.ChickenController.PlayMoveAnimation();
			}
		}

		public override void End()
		{
			_targetSpawner = null;
			StateContext.ChickenController.StopMoving();
			StateContext.ChickenController.PlayMoveAnimation();
		}
		
		private void SearchForSpawner()
		{
			var spawners = Object.FindObjectsOfType<Spawner>();

			var distanceToSpawner = float.MaxValue;
			
			for (var i = 0; i < spawners.Length; i++)
			{
				var spawner = spawners[i];
				if(spawner.Team.TeamId != StateContext.ChickenBrain.Team.TeamId) continue;

				var distance = Vector3.Distance(StateContext.ChickenBrain.transform.position, spawner.transform.position);
				if (distance < distanceToSpawner)
				{
					_targetSpawner = spawner;
				}
			}

			StateContext.ChickenController.UpdateMoveTarget(_targetSpawner.transform.position);
		}
	}
}