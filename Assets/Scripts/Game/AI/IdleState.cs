using Game.AI.EggSearch;
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
			StateContext.SetNextState(new SearchForEggState(StateContext));
		}

		public override void Update()
		{
		}

		public override void End()
		{
		}
	}
}