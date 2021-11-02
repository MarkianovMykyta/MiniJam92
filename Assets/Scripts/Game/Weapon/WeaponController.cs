using UnityEngine;

namespace Game.Weapon
{
	public class WeaponController : MonoBehaviour
	{
		[SerializeField] private WeaponBase[] _weapons;

		// ENCAPSULATION
		public WeaponBase ActiveWeapon { get; private set; }

		public void Initialize(Team team)
		{
			for (var i = 0; i < _weapons.Length; i++)
			{
				_weapons[i].Initialize(team);
			}
			
			SetWeapon(WeaponType.None);
		}
		
		// ABSTRACTION
		public void SetWeapon(WeaponType weaponType)
		{
			if (ActiveWeapon != null)
			{
				ActiveWeapon.Deactivate();
			}
			
			for (var i = 0; i < _weapons.Length; i++)
			{
				if (_weapons[i].WeaponType == weaponType)
				{
					ActiveWeapon = _weapons[i];
					
					ActiveWeapon.Activate();
					
					return;
				}
			}
			
			Debug.LogError("Can't set weapon type: " + weaponType);
		}
	}
}