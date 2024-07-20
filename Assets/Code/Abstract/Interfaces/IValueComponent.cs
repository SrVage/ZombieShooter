using UnityEngine;

namespace Code.Abstract.Interfaces
{
	public interface IValueComponent<in T> where T:Component
	{
		void SetValue(T value);
	}
}