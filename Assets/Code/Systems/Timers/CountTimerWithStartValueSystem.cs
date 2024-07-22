using Code.Abstract.Interfaces;
using Leopotam.Ecs;

namespace Code.Systems.Timers
{
	internal sealed class CountTimerWithStartValueSystem<T> : CountTimerSystem<T> where T : struct, ITimerComponent
	{
		private readonly float _startValue;
		private readonly EcsWorld _world;

		public CountTimerWithStartValueSystem(float startValue)
		{
			_startValue = startValue;
		}
		
		protected override void ExecuteTimer()
		{
			if (_timer.IsEmpty())
			{
				_world.NewEntity().Get<T>().Timer = _startValue;
			}
			base.ExecuteTimer();
		}
	}
}