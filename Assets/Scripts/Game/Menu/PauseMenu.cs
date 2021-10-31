using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Menu
{
	public class PauseMenu : MonoBehaviour
	{
		public event Action Closed;
		
		[SerializeField] private Button _closeButton;
		[SerializeField] private Button _exitToMenuButton;

		private void Start()
		{
			_closeButton.onClick.AddListener(OnCloseClicked);
			_exitToMenuButton.onClick.AddListener(OnExitClicked);
		}

		private void OnCloseClicked()
		{
			Closed?.Invoke();
		}

		private void OnExitClicked()
		{
			Closed?.Invoke();
			SceneManager.LoadScene(0);
		}

		public void Open()
		{
			gameObject.SetActive(true);
		}

		public void Close()
		{
			gameObject.SetActive(false);
		}
	}
}