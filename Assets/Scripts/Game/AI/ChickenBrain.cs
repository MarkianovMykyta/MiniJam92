using UnityEngine;

namespace Game.AI
{
	public class ChickenBrain : Chicken
	{
		[SerializeField] private Transform _moveTarget;

		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSpeed;

		private StateContext _stateContext;

		protected override void OnStart()
		{
			ChickenController.SetSpeedLimit(Random.Range(_minSpeed, _maxSpeed));

			_stateContext = new StateContext(this, ChickenController);
			_stateContext.SetNextState(new IdleState(_stateContext));
		}

		protected override void OnUpdate()
		{
			// ChickenController.UpdateMoveTarget(_moveTarget.position);
			// ChickenController.PlayMoveAnimation();
			
			_stateContext.Update();
		}
	}
}