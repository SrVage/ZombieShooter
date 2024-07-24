using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Components.Shooting
{
	public struct FirePoint : IValueComponent<Transform>
	{
		public Transform Value { get; set; }
	}
}