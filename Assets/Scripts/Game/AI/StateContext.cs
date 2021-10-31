namespace Game.AI
{
	public class StateContext
	{
		public ChickenBrain ChickenBrain { get; private set; }
		public ChickenController ChickenController { get; private set; }
		public Inventory Inventory { get; private set; }
		
		private StateBase _currentState;

		public StateContext(ChickenBrain chickenBrain, ChickenController chickenController, Inventory inventory)
		{
			ChickenBrain = chickenBrain;
			ChickenController = chickenController;
			Inventory = inventory;
		}

		public void Update()
		{
			_currentState?.Update();
		}

		public void SetNextState(StateBase stateBase)
		{
			_currentState?.End();
			_currentState = stateBase;
			_currentState?.Begin();
		}
	}
}