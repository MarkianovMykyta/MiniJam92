using UnityEngine;

namespace Game.AI
{
	// INHERITANCE
	public class ChickenBrain : Chicken
	{
		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSpeed;

		private StateContext _stateContext;

		// POLYMORPHISM
		public override void Initialize(Team team)
		{
			base.Initialize(team);
			
			_stateContext = new StateContext(this, ChickenController, Inventory, WeaponController);
			_stateContext.SetNextState(new IdleState(_stateContext));
		}

		// POLYMORPHISM
		protected override void OnStart()
		{
			ChickenController.SetSpeedLimit(Random.Range(_minSpeed, _maxSpeed));
		}

		protected override void OnUpdate()
		{
			if (!IsAlive) return;
			_stateContext.Update();
		}
	}
}