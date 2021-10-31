using System;
using UnityEngine;

namespace Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Team _team;
		[SerializeField] private SpriteRenderer _radiusRenderer;
		public Team Team => _team;

		private void Start()
		{
			_radiusRenderer.color = Team.TeamMaterial.color;
		}
	}
}