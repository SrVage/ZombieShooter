using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Systems.Timers
{
	internal sealed class CountTimerWithStartValueSystem<TTimer, TState> : CountTimerWithDestroySystem<TTimer, TState> where TTimer : struct, ITimerComponent where TState : struct
	{
		private readonly float _startValue;
		private readonly EcsWorld _world;

		public CountTimerWithStartValueSystem(float startValue)
		{
			_startValue = startValue;
		}
		
		protected override void ExecuteTimer()
		{
			if (_timer.IsEmpty() && _destroyTimer.IsEmpty())
			{
				_world.NewEntity().Get<TTimer>().Timer = _startValue;
			}
			base.ExecuteTimer();
		}
	}
}