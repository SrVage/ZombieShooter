using UnityEngine;

namespace Code.Abstract.Interfaces
{
	public interface IValueComponent<T> where T:Component
	{
		public T Value { get; set; }
	}
}