using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
	public class PlayerAmmoPresenter : MonoBehaviour
	{
		[SerializeField] private PlayerAmmoView _playerAmmoView;
		private IDisplayPlayerAmmo _displayPlayerAmmo;

		[Inject]
		public void Init(IDisplayPlayerAmmo displayPlayerAmmo)
		{
			_displayPlayerAmmo = displayPlayerAmmo;
			_displayPlayerAmmo.ChangePlayerAmmo += _playerAmmoView.SetAmmo;
		}

		private void OnDestroy() => 
			_displayPlayerAmmo.ChangePlayerAmmo += _playerAmmoView.SetAmmo;
	}
}