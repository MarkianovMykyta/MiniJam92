using UnityEngine;

namespace Game.AI
{
	public class ChickenBrain : Chicken
	{
		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSpeed;

		private StateContext _stateContext;

		public override void Initialize(Team team)
		{
			base.Initialize(team);
			
			_stateContext = new StateContext(this, ChickenController, Inventory, WeaponController);
			_stateContext.SetNextState(new IdleState(_stateContext));
		}

		protected override void OnStart()
		{
			ChickenController.SetSpeedLimit(Random.Range(_minSpeed, _maxSpeed));
		}

		protected override void OnUpdate()
		{
			_stateContext.Update();
		}
	}
}