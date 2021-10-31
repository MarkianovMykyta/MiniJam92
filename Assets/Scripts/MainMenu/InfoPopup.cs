using System;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
	public class InfoPopup : MonoBehaviour
	{
		[SerializeField] private Button _okButton;

		private void Start()
		{
			_okButton.onClick.AddListener(OkButtonClicked);
		}

		private void OkButtonClicked()
		{
			gameObject.SetActive(false);
		}

		public void Open()
		{
			gameObject.SetActive(true);
		}
	}
}