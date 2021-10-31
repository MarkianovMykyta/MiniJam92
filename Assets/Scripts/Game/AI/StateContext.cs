using Game.Weapon;

namespace Game.AI
{
	public class StateContext
	{
		public ChickenBrain ChickenBrain { get; private set; }
		public ChickenController ChickenController { get; private set; }
		public Inventory Inventory { get; private set; }
		public WeaponController WeaponController { get; private set; }
		
		private StateBase _currentState;

		public StateContext(ChickenBrain chickenBrain, ChickenController chickenController, Inventory inventory, WeaponController weaponController)
		{
			ChickenBrain = chickenBrain;
			ChickenController = chickenController;
			Inventory = inventory;
			WeaponController = weaponController;
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