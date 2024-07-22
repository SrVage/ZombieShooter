using Code.Abstract.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Components
{
	public struct NavMeshComponent : IValueComponent<NavMeshAgent>
	{
		public NavMeshAgent Value;

		public void SetValue(NavMeshAgent value)
		{
			Value = value;
		}
	}
}