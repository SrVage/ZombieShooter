using Leopotam.Ecs;

namespace Code.Abstract.Interfaces
{
	public interface IPool
	{
		public EcsEntity? GetEntity();

		public void ReturnToPool(EcsEntity entity);
	}
}