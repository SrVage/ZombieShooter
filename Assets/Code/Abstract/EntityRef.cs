using Leopotam.Ecs;
using UnityEngine;

namespace Code.Abstract
{
	internal sealed class EntityRef : MonoBehaviour
	{
		public EcsEntity Entity { get; private set; }
		
		public void Init(EcsEntity entity)
		{
			Entity = entity;
		}
	}
}