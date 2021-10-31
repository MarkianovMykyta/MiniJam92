using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
	public class TeamWinPopup : MonoBehaviour
	{
		[SerializeField] private TMP_Text _title;
		[SerializeField] private Button _restartButton;

		private void Start()
		{
			_restartButton.onClick.AddListener(OnRestartClicked);
		}

		public void Open(Team winTeam)
		{
			_title.text = $"Team {winTeam.gameObject.name} win!";
			gameObject.SetActive(true);
		}

		private void OnRestartClicked()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}