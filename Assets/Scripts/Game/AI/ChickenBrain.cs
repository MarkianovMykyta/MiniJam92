using UnityEngine;

namespace Game.AI
{
	public class ChickenBrain : Chicken
	{
		[SerializeField] private Transform _moveTarget;

		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSpeed;
		
		protected override void OnStart()
		{
			ChickenController.SetSpeedLimit(Random.Range(_minSpeed, _maxSpeed));
		}

		protected override void OnUpdate()
		{
			ChickenController.UpdateMoveTarget(_moveTarget.position);
			ChickenController.PlayMoveAnimation();
		}
	}
}