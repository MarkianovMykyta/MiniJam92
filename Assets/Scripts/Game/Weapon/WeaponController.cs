using UnityEngine;

namespace Game.Weapon
{
	public class WeaponController : MonoBehaviour
	{
		[SerializeField] private WeaponBase[] _weapons;

		public WeaponBase ActiveWeapon { get; private set; }
		
		public void SetWeapon(WeaponType weaponType)
		{
			for (var i = 0; i < _weapons.Length; i++)
			{
				if (_weapons[i].WeaponType == weaponType)
				{
					
					if (ActiveWeapon != null)
					{
						ActiveWeapon.Deactivate();
					}
					
					ActiveWeapon = _weapons[i];
					
					ActiveWeapon.Activate();
					
					return;
				}
			}
			
			Debug.LogError("Can't set weapon type: " + weaponType);
		}
	}
}