using UnityEngine;

namespace Code.UI.View
{
	public abstract class HidableView : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _group;

		public void Show()
		{
			_group.alpha = 1;
			_group.interactable = true;
			_group.blocksRaycasts = true;
		}

		public void Hide()
		{
			_group.alpha = 0;
			_group.interactable = false;
			_group.blocksRaycasts = false;
		}
	}
}