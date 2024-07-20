using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
	public abstract class ComponentInstallerBase : MonoBehaviour
	{
		public abstract void InitComponent(EcsEntity entity);
	}
}