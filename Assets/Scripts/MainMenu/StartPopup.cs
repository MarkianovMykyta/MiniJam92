using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
	public class StartPopup : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		[SerializeField] private Button _closeButton;
		[SerializeField] private Slider _slider;
		[SerializeField] private TMP_Text _sliderNumberText;
		[SerializeField] private GameSettings _gameSettings;

		private void Start()
		{
			_startButton.onClick.AddListener(OnStartClicked);
			_closeButton.onClick.AddListener(OnCloseButtonClicked);
			
			_slider.onValueChanged.AddListener(OnSliderValueChanged);
			
			_gameSettings.MaxNumberOfChickens = (int)_slider.value;
			_sliderNumberText.text = _gameSettings.MaxNumberOfChickens.ToString();
		}

		private void OnCloseButtonClicked()
		{
			gameObject.SetActive(false);
		}

		private void OnSliderValueChanged(float value)
		{
			_gameSettings.MaxNumberOfChickens = (int)_slider.value;
			_sliderNumberText.text = _gameSettings.MaxNumberOfChickens.ToString();
		}

		private void OnStartClicked()
		{
			SceneManager.LoadScene(1);
		}

		public void Open()
		{
			gameObject.SetActive(true);
		}
	}
}