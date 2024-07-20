using Code.Abstract;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
	internal sealed class InitSystem : IEcsInitSystem
	{
		private readonly EcsWorld _world;
		public void Init()
		{
			var installers = Object.FindObjectsOfType<EntityInstaller>();
			foreach (var installer in installers)
			{
				installer.Init(_world);
			}
		}
	}
}