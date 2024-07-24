using Code.Abstract.Interfaces;
using UnityEngine.AI;

namespace Code.Components
{
	public struct NavMeshComponent : IMovableComponent<NavMeshAgent>
	{
		public NavMeshAgent Value { get; set; }
		
		public float GetSpeed() => 
			Value.velocity.sqrMagnitude;
	}
}