using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class TeamsProgressView : MonoBehaviour
	{
		[SerializeField] private Team[] _teams;
		[SerializeField] private RectTransform _teamProgressTemplate;
		[SerializeField] private RectTransform _parent;
		[SerializeField] private HorizontalLayoutGroup _layoutGroup;

		private RectTransform[] _progressInstances;

		private void Start()
		{
			_progressInstances = new RectTransform[_teams.Length];
			for (var i = 0; i < _teams.Length; i++)
			{
				_progressInstances[i] = Instantiate(_teamProgressTemplate, _teamProgressTemplate.parent);
				_progressInstances[i].GetComponent<Image>().color = _teams[i].TeamMaterial.color;
				_progressInstances[i].gameObject.SetActive(true);
				
				_teams[i].TeamSizeChanged += UpdateProgress;
			}
			
			_teamProgressTemplate.gameObject.SetActive(false);

			UpdateProgress();
		}

		private void UpdateProgress()
		{
			var chickensCount = 0;
			var activeTeamsCount = 0;
			for (var i = 0; i < _teams.Length; i++)
			{
				if (_teams[i].TeamSize > 0)
				{
					chickensCount += _teams[i].TeamSize;
					activeTeamsCount++;
				}
			}
			
			if (chickensCount == 0) return;

			var parentSize = _parent.sizeDelta.x;
			parentSize -= _layoutGroup.spacing * (activeTeamsCount-1);
			parentSize -= _layoutGroup.padding.left + _layoutGroup.padding.right;
			
			for (var i = 0; i < _teams.Length; i++)
			{
				var value = ((float)_teams[i].TeamSize) / chickensCount;
				var size = _progressInstances[i].sizeDelta;
				size.x = parentSize * value;
				_progressInstances[i].sizeDelta = size;
			}
		}
	}
}