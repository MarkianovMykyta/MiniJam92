using UnityEngine;
namespace Game.Player
{
	public class PlayerController : Chicken
	{
		private Vector3 _input;

		protected override void OnUpdate()
		{
			Move();
			Attack();
		}

		private void Move()
		{
			_input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

			ChickenController.UpdateMoveTarget(transform.position + _input);
			ChickenController.PlayMoveAnimation(_input.magnitude);
		}

		private void Attack()
		{
			if (Input.GetButtonDown("Attack"))
			{
				if (WeaponController.ActiveWeapon != null)
				{
					WeaponController.ActiveWeapon.Attack();
				}
			}
		}
	}
}