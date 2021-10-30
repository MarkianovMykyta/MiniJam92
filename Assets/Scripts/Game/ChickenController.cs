using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
	/// <summary>
	/// Basic chicken controller abstraction to work with Unity components
	/// </summary>
	public class ChickenController : MonoBehaviour
	{
		private static readonly int Death = Animator.StringToHash("Death");
		private static readonly int Attack = Animator.StringToHash("Attack");
		private static readonly int Speed = Animator.StringToHash("Speed");
		
		
		[SerializeField] private Animator _animator;
		[SerializeField] private NavMeshAgent _agent;
		[Space]
		[SerializeField] private float _deathAnimationTime;
		
		public void SetSpeedLimit(float maxSpeed)
		{
			_agent.speed = maxSpeed;
		}

		public void UpdateMoveTarget(Vector3 targetPosition)
		{
			_agent.SetDestination(targetPosition);
			_agent.isStopped = false;
		}

		public void StopMoving()
		{
			_agent.isStopped = true;
		}
		
		public void PlayMoveAnimation(float? value = null)
		{
			if (value != null)
			{
				_animator.SetFloat(Speed, value.Value);
			}
			else
			{
				_animator.SetFloat(Speed, _agent.velocity.magnitude / _agent.speed);
			}
		}

		public void PlayAttackAnimation()
		{
			_animator.SetTrigger(Attack);
		}

		public async void PlayDeathAnimation(Action animationCompletedCallback = null)
		{
			_animator.SetTrigger(Death);

			await Task.Delay(TimeSpan.FromSeconds(_deathAnimationTime));

			animationCompletedCallback?.Invoke();
		}
	}
}