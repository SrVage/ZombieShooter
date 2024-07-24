using TMPro;
using UnityEngine;

namespace Code.UI.View
{
	public class PlayerAmmoView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _ammoText;
		
		public void SetAmmo(string ammo) => 
			_ammoText.text = ammo;
	}
}