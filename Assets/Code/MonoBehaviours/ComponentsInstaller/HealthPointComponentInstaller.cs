using Code.Abstract;
using Code.Components.Health;
using UnityEngine;

namespace Code.MonoBehaviours.ComponentsInstaller
{
	internal sealed class HealthPointComponentInstaller : ValueComponentInstaller<HealthPoint>
	{
		[SerializeField] private float _healthPoint;
	}
}