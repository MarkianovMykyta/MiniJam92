using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class HealthView : MonoBehaviour
	{
		[SerializeField] private Slider _progressbar;
		[SerializeField] private Transform _followTarget;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _disappearAnimationTime;

		private bool _isActive;

		private void Start()
		{
			transform.SetParent(null);
			transform.rotation = Quaternion.identity;
			transform.position = _followTarget.position;
		}

		public void Activate()
		{
			if (_isActive) return;
			
			transform.rotation = Quaternion.identity;
			transform.position = _followTarget.position;
			
			gameObject.SetActive(true);
			
			_animator.SetTrigger("Appear");

			_isActive = true;
		}

		public async void Deactivate()
		{
			if (!_isActive) return;
			
			_isActive = false;
			_animator.SetTrigger("Disappear");

			await Task.Delay(TimeSpan.FromSeconds(_disappearAnimationTime));

			if (!_isActive)
			{
				gameObject.SetActive(false);
			}
		}

		public void UpdateValue(float value)
		{
			_progressbar.value = Mathf.Clamp01(value);
		}

		private void Update()
		{
			if(_followTarget == null) return;

			transform.position = Vector3.Lerp(transform.position, _followTarget.position, 0.3f);
		}
	}
}