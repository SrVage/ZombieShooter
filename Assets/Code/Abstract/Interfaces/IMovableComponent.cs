using UnityEngine;

namespace Code.Abstract.Interfaces
{
	public interface IMovableComponent<T> : IValueComponent<T> where T : Component
	{
		public float GetSpeed();
	}
}