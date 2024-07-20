using Code.Abstract.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
	public abstract class ComponentInstaller<T1, T2> : ComponentInstallerBase 
		where T1 : Component 
		where T2 : struct, IValueComponent<T1>
	{
		[SerializeField] private T1 _component;

		public override void InitComponent(EcsEntity entity)
		{
			ref var component = ref entity.Get<T2>();
			component.SetValue(_component);
		}
	}
}