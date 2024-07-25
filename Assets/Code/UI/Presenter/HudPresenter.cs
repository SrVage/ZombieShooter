using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
	public class HudPresenter : MonoBehaviour
	{
		[SerializeField] private HudView _hudView;
		private IDisplayHud _displayHud;

		[Inject]
		public void Init(IDisplayHud displayHud)
		{
			_displayHud = displayHud;
			_displayHud.ShowPlayEvent += _hudView.Show;
			_displayHud.HidePlayEvent += _hudView.Hide;
		}

		private void OnDestroy()
		{
			_displayHud.ShowPlayEvent -= _hudView.Show;
			_displayHud.HidePlayEvent -= _hudView.Hide;
		}
	}
}