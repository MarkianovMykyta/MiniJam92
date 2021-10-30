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
		}

		public override void Update()
		{
			Debug.Log("Idle Update");
		}

		public override void End()
		{
			Debug.Log("Idle End");
		}
	}
}