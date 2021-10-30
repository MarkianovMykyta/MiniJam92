namespace Game.AI
{
	public abstract class StateBase
	{
		protected StateContext StateContext;

		protected StateBase(StateContext stateContext)
		{
			StateContext = stateContext;
		}
		
		public abstract void Begin();
		public abstract void Update();
		public abstract void End();
	}
}