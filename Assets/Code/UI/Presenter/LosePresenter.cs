using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
	public class LosePresenter : MonoBehaviour
	{
		[SerializeField] private LoseView _loseView;
		private IDisplayLose _displayLose;

		[Inject]
		public void Init(IDisplayLose displayLose)
		{
			_displayLose = displayLose;
			_displayLose.ShowLoseEvent += _loseView.Show;
			_displayLose.HideLoseEvent += _loseView.Hide;
			_loseView.RestartButton.onClick.AddListener(_displayLose.Restart);
		}

		private void OnDestroy()
		{
			_displayLose.ShowLoseEvent -= _loseView.Show;
			_displayLose.HideLoseEvent -= _loseView.Hide;
			_loseView.RestartButton.onClick.RemoveAllListeners();
		}
	}
}