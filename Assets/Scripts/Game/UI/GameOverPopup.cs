using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
	public class GameOverPopup : MonoBehaviour
	{
		[SerializeField] private Button _restartButton;

		private void Start()
		{
			_restartButton.onClick.AddListener(OnRestartClicked);
		}

		public void Open()
		{
			gameObject.SetActive(true);
		}

		private void OnRestartClicked()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}