using UnityEngine;

namespace Game.AI
{
	public class FollowPlayerState : StateBase
	{
		private Transform _player;
		private float _searchRadius;
		
		public FollowPlayerState(StateContext stateContext) : base(stateContext)
		{
		}

		public override void Begin()
		{
			Debug.Log("Follow Player Begin");
		}

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