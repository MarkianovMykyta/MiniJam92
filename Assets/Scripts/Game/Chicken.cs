using System;
using UnityEngine;

namespace Game
{
	public class Chicken : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private Rigidbody _rigidbody;

		[SerializeField] private float _moveSpeed;

		private Vector3 _input;
		
		private void Update()
		{
			_input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			_rigidbody.AddForce(_input * _moveSpeed, ForceMode.Impulse);

			var horizontalVelocity = _rigidbody.velocity;
			horizontalVelocity.y = 0;
			if (horizontalVelocity.magnitude > _moveSpeed)
			{
				_rigidbody.velocity = horizontalVelocity.normalized  * _moveSpeed + Vector3.up * _rigidbody.velocity.y;
			}

			_animator.SetFloat("Speed",horizontalVelocity.magnitude / _moveSpeed);

			if (_input.magnitude > 0)
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_input), 0.3f);
			}
		}
	}
}