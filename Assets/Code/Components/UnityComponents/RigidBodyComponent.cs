using Code.Abstract.Interfaces;
using UnityEngine;

namespace Code.Components
{
	public struct RigidBodyComponent : IMovableComponent<Rigidbody>
	{
		public Rigidbody Value { get; set; }
		
		public float GetSpeed() => 
			Value.velocity.sqrMagnitude;
	}
}