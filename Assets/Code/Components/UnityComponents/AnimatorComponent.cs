using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Components
{
	public struct AnimatorComponent : IValueComponent<Animator>
	{
		public Animator Value { get; set; }
	}
}