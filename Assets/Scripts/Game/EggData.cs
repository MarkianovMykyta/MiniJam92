using UnityEngine;

namespace Game
{
	public class EggData
	{
		public readonly GameObject Egg;
		public float TimeLeft;
		
		public EggData(GameObject egg, float timer)
		{
			Egg = egg;
			TimeLeft = timer;
		}
		
		public override int GetHashCode()
		{
			return Egg.GetHashCode();
		}
	}
}