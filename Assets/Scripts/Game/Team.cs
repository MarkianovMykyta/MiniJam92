using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Team : MonoBehaviour
	{
		[SerializeField] private int _teamId;
		
		public int TeamId => _teamId;

		private readonly List<Chicken> _teamChickens = new List<Chicken>();

		public void AddChicken(Chicken chicken)
		{
			chicken.Initialize(TeamId);
			
			_teamChickens.Add(chicken);

			chicken.Died += RemoveChicken;
		}

		public void RemoveChicken(Chicken chicken)
		{
			chicken.Died -= RemoveChicken;

			_teamChickens.Remove(chicken);
		}
	}
}