using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
	public abstract class EntityInstaller : MonoBehaviour
	{
		[SerializeField] private ComponentInstallerBase[] _componentInstallers;
		
		public virtual EcsEntity Init(EcsWorld world)
		{
			EcsEntity entity = world.NewEntity();
			ref var gameObjectComponent = ref entity.Get<GameObjectComponent>();
			gameObjectComponent.Value = gameObject;
			foreach (var componentInstaller in _componentInstallers)
			{
				componentInstaller.InitComponent(entity);
			}
			Destroy(this);
			return entity;
		}
	}
}