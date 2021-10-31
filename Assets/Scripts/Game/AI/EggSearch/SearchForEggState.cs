using System.Collections.Generic;
using UnityEngine;

namespace Game.AI.EggSearch
{
	public class SearchForEggState : StateBase
	{
		private float _delayBetweenEggSearch = 3f;

		private float _lastEggSearchTime;

		private Egg _targetEgg;
		
		public SearchForEggState(StateContext stateContext) : base(stateContext)
		{
		}

		public override void Begin()
		{
			StateContext.Inventory.PickedUp += OnEggPickedUp;
		}

		public override void Update()
		{
			SearchForEgg();

			if (_targetEgg != null)
			{
				if (_targetEgg.IsPickedUp) _targetEgg = null;
				else
				{
					StateContext.ChickenController.PlayMoveAnimation();
				}
			}
			else
			{
				StateContext.ChickenController.StopMoving();
				StateContext.ChickenController.PlayMoveAnimation();
			}
		}

		public override void End()
		{
			StateContext.ChickenController.StopMoving();
			
			StateContext.Inventory.PickedUp -= OnEggPickedUp;

			if (_targetEgg != null)
			{
				_targetEgg.RemoveTargetedChicken(StateContext.ChickenBrain);
			}
		}

		private void SearchForEgg()
		{
			if (Time.time < _lastEggSearchTime + _delayBetweenEggSearch) return;
			
			_lastEggSearchTime = Time.time;

			var eggs = Object.FindObjectsOfType<Egg>();

			var distanceToEgg = float.MaxValue;

			if (_targetEgg != null)
			{
				_targetEgg.RemoveTargetedChicken(StateContext.ChickenBrain);
			}
			
			for (var i = 0; i < eggs.Length; i++)
			{
				var egg = eggs[i];
				if(egg.IsPickedUp || egg.IsSpawning && egg.Team.TeamId == StateContext.ChickenBrain.Team.TeamId) continue;
				if(egg != _targetEgg && !egg.IsEggFreeForTeam(StateContext.ChickenBrain.Team.TeamId)) continue;

				var distance = Vector3.Distance(StateContext.ChickenBrain.transform.position, egg.transform.position);
				if (distance < distanceToEgg)
				{
					distanceToEgg = distance;
					_targetEgg = egg;
				}
			}

			if (_targetEgg != null)
			{
				_targetEgg.AddTargetedChicken(StateContext.ChickenBrain);
				StateContext.ChickenController.UpdateMoveTarget(_targetEgg.transform.position);
			}
		}

		private void OnEggPickedUp(Egg egg)
		{
			StateContext.SetNextState(new BringEggToCampState(StateContext));
		}
	}
}