using System;
using UnityEngine;

namespace Game.Menu
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private PauseMenu _pauseMenu;

		// ENCAPSULATION
		public bool IsPaused { get; private set; }


		private void Start()
		{
			_pauseMenu.Closed += Unpause;
		}

		private void Update()
		{
			if (Input.GetButtonDown("Cancel"))
			{
				if(IsPaused) Unpause();
				else Pause();
			}
		}

		public void Pause()
		{
			IsPaused = true;
			Time.timeScale = 0;
			_pauseMenu.Open();
		}

		public void Unpause()
		{
			IsPaused = false;
			Time.timeScale = 1;
			_pauseMenu.Close();
		}
	}
}