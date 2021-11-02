namespace Game.Weapon
{
	// INHERITANCE
	public class EmptyHands : WeaponBase
	{
		// POLYMORPHISM
		public override WeaponType WeaponType => WeaponType.None;
	}
}