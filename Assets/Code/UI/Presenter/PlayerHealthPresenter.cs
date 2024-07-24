using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
	public class PlayerHealthPresenter : MonoBehaviour
	{
		[SerializeField] private PlayerHealthView _playerHealthView;
		private IDisplayPlayerHealth _displayPlayerHealth;

		[Inject]
		public void Init(IDisplayPlayerHealth displayPlayerHealth)
		{
			_displayPlayerHealth = displayPlayerHealth;
			_displayPlayerHealth.ChangePlayerHealth += _playerHealthView.SetHealth;
		}

		private void OnDestroy() => 
			_displayPlayerHealth.ChangePlayerHealth -= _playerHealthView.SetHealth;
	}
}