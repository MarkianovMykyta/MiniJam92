using UnityEngine;
using UnityEngine.AI;

namespace Game
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private NavMeshAgent _agent;

		[SerializeField] private float _moveSpeed;

		private Vector3 _input;
		
		private void LateUpdate()
		{
			_input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

			_agent.SetDestination(transform.position + _input);

			_animator.SetFloat("Speed", _input.magnitude);
		}
	}
}