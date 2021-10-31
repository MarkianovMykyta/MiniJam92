using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		[SerializeField] private Button _infoButton;
		[SerializeField] private Button _exitButton;
		[SerializeField] private StartPopup _startPopup;
		[SerializeField] private InfoPopup _infoPopup;
		[SerializeField] private Button _tweeterButton;

		private void Start()
		{
			_startButton.onClick.AddListener(OnStartClicked);
			_infoButton.onClick.AddListener(OnInfoClicked);
			_exitButton.onClick.AddListener(OnExitClicked);
			_tweeterButton.onClick.AddListener(OnTweeterClicked);
		}

		private void OnTweeterClicked()
		{
			Application.OpenURL("https://twitter.com/MarkianovNikita");
		}

		private void OnExitClicked()
		{
			Application.Quit();
		}

		private void OnInfoClicked()
		{
			_infoPopup.Open();
		}

		private void OnStartClicked()
		{
			_startPopup.Open();
		}
	}
}