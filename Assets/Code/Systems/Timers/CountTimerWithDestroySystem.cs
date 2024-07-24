using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Systems.Timers
{
	internal class CountTimerWithDestroySystem<TTimer, TState> : CountTimerSystem<TTimer, TState> where TTimer : struct, ITimerComponent where TState : struct
	{
		protected override void Destroy(int id)
		{
			_destroyTimer.GetEntity(id).Destroy();
		}
	}
}