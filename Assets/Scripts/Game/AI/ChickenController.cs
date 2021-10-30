using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Game.AI
{
	public class ChickenController : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private Transform _moveTarget;

		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSpeed;
		
		private void Start()
		{
			_navMeshAgent.speed = Random.Range(_minSpeed, _maxSpeed);
			_animator.speed = _navMeshAgent.speed / ((_minSpeed + _maxSpeed) / 2f);
		}

		private void Update()
		{
			if (_navMeshAgent.SetDestination(_moveTarget.position))
			{
				_navMeshAgent.isStopped = false;
			}
			
			_animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
		}
	}
}