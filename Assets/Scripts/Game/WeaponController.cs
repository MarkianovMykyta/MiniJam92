using Game.Weapon;
using UnityEngine;

namespace Game
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
					ActiveWeapon = _weapons[i];
					return;
				}
			}
			
			Debug.LogError("Can't set weapon type: " + weaponType);
		}
	}
}