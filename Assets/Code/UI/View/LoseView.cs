using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.View
{
	public class LoseView : HidableView
	{
		[SerializeField] private Button _restartButton;
		
		public Button RestartButton => _restartButton;
	}
}