using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Components
{
	public struct TransformComponent : IValueComponent<Transform>
	{
		public Transform Value;

		public void SetValue(Transform value)
		{
			Value = value;
		}
	}
}