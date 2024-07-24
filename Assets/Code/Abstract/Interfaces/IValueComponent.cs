using UnityEngine;

namespace Code.Abstract.Interfaces
{
	public interface IValueComponent<T>
	{
		public T Value { get; set; }
	}
}