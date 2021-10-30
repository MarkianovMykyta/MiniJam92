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
			Debug.Log("Idle Begin");
			
			StateContext.SetNextState(new FollowPlayerState(StateContext));
		}

		public override void Update()
		{
		}

		public override void End()
		{
			Debug.Log("Idle End");
		}
	}
}