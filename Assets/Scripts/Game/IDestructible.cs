namespace Game
{
	public interface IDestructible
	{
		float Health { get; }
		void ApplyDamage(float damage);
	}
}