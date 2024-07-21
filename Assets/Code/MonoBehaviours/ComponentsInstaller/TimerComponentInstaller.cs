using Code.Abstract;
using Code.Components;
using UnityEngine;

namespace Code.MonoBehaviours.ComponentsInstaller
{
	internal sealed class TimerComponentInstaller : ValueComponentInstaller<SpawnTimer>
	{
		[SerializeField] private float _maxTime;
	}
}