using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Team : MonoBehaviour
	{
		public event Action TeamSizeChanged; 

		[SerializeField] private int _teamId;
		[SerializeField] private Material _teamMaterial;
		[SerializeField] private Chicken[] _predefinedTeamMembers;
		
		// ENCAPSULATION
		public int TeamId => _teamId;
		// ENCAPSULATION
		public Material TeamMaterial => _teamMaterial;
		// ENCAPSULATION
		public int TeamSize => _teamChickens.Count;

		private readonly List<Chicken> _teamChickens = new List<Chicken>();

		private void Awake()
		{
			for (var i = 0; i < _predefinedTeamMembers.Length; i++)
			{
				AddChicken(_predefinedTeamMembers[i]);
			}
		}

		// ABSTRACTION
		public void AddChicken(Chicken chicken)
		{
			chicken.Initialize(this);
			
			_teamChickens.Add(chicken);

			chicken.Died += RemoveChicken;
			
			TeamSizeChanged?.Invoke();
		}

		// ABSTRACTION
		public void RemoveChicken(Chicken chicken)
		{
			chicken.Died -= RemoveChicken;

			_teamChickens.Remove(chicken);
			
			TeamSizeChanged?.Invoke();
		}
	}
}