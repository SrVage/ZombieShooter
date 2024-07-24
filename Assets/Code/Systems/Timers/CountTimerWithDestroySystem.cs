using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Systems.Timers
{
	internal class CountTimerWithDestroySystem<T> : CountTimerSystem<T> where T : struct, ITimerComponent
	{
		protected override void Destroy(int id)
		{
			_destroyTimer.GetEntity(id).Destroy();
		}
	}
}