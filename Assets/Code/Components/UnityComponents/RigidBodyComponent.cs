using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Components
{
	public struct RigidBodyComponent : IValueComponent<Rigidbody>
	{
		public Rigidbody Value;

		public void SetValue(Rigidbody value)
		{
			Value = value;
		}
	}
}