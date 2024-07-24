using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.View
{
	public class PlayerHealthView : MonoBehaviour
	{
		[SerializeField] private Image _healthBar;
		
		public void SetHealth(float percent) => 
			_healthBar.fillAmount = percent;
	}
}