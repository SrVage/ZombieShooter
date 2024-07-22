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
			
			AddGameObjectComponent(entity);

			AddAllComponents(entity);
			
			gameObject.AddComponent<EntityRef>().Init(entity);
			Destroy(this);
			
			return entity;
		}

		private void AddAllComponents(EcsEntity entity)
		{
			foreach (var componentInstaller in _componentInstallers)
			{
				componentInstaller.InitComponent(entity);
			}
		}

		private void AddGameObjectComponent(EcsEntity entity)
		{
			ref var gameObjectComponent = ref entity.Get<GameObjectComponent>();
			gameObjectComponent.Value = gameObject;
		}
	}
}