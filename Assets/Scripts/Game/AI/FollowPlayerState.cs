using UnityEngine;

namespace Game.AI
{
	// INHERITANCE
	public class FollowPlayerState : StateBase
	{
		private Transform _player;
		private float _searchRadius;
		
		public FollowPlayerState(StateContext stateContext) : base(stateContext)
		{
		}

		// POLYMORPHISM
		public override void Begin()
		{
			Debug.Log("Follow Player Begin");
		}

		// POLYMORPHISM
		public override void Update()
		{
			if (_player == null)
			{
				FindPlayer();
				return;
			}
			
			StateContext.ChickenController.UpdateMoveTarget(_player.position);
			StateContext.ChickenController.PlayMoveAnimation();
		}

		// POLYMORPHISM
		public override void End()
		{
			Debug.Log("Follow Player End");
		}

		private void FindPlayer()
		{
			_player = GameObject.Find("Player")?.transform;
		}
	}
}