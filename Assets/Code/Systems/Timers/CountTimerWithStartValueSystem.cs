using Code.Abstract.Interfaces;
using Code.Components.Enemy;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Timers
{
	internal sealed class CountTimerWithStartValueSystem<T> : CountTimerWithDestroySystem<T> where T : struct, ITimerComponent
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
				_world.NewEntity().Get<T>().Timer = _startValue;
			}
			base.ExecuteTimer();
		}
	}
}