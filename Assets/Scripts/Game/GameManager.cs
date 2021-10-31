using System;
using Game.UI;
using UnityEngine;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Team[] _teams;
		[SerializeField] private TeamWinPopup _teamWinPopup;

		private void Start()
		{
			for (var i = 0; i < _teams.Length; i++)
			{
				_teams[i].TeamSizeChanged += OnTeamSizeChanged;
			}
		}

		private void OnTeamSizeChanged()
		{
			var numberOfActiveTeams = 0;
			Team winTeam = null;
			for (var i = 0; i < _teams.Length; i++)
			{
				if (_teams[i].TeamSize > 0)
				{
					numberOfActiveTeams++;
					winTeam = _teams[i];
				}
			}

			if (numberOfActiveTeams == 1)
			{
				_teamWinPopup.Open(winTeam);
			}
		}
	}
}