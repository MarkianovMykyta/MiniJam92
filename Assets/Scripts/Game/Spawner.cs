using UnityEngine;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Team _team;
		public Team Team => _team;
	}
}