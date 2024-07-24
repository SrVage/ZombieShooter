using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Systems.Timers
{
	internal class CountTimerWithDestroySystem<T> : CountTimerSystem<T> where T : struct, ITimerComponent
	{
		protected override void Destroy(int tdx)
		{
			_timer.GetEntity(tdx).Destroy();
		}
	}
}