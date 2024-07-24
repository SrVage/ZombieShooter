using Code.Abstract.Interfaces;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Timers
{
	internal class CountTimerSystem<TTimer, TState> : RunInStateSystem<TState> where TTimer : struct, ITimerComponent where TState : struct
	{
		protected readonly EcsFilter<TTimer>.Exclude<FinishTimerTag> _timer;
		protected readonly EcsFilter<TTimer, FinishTimerTag> _destroyTimer;
		
		protected override void Execute()
		{
			DestroyTimer();
			ExecuteTimer();
		}

		private void DestroyTimer()
		{
			foreach (var ddx in _destroyTimer)
			{
				Destroy(ddx);
			}
		}

		protected virtual void ExecuteTimer()
		{
			foreach (var tdx in _timer)
			{
				ref var timer = ref _timer.Get1(tdx);
				timer.Timer -= Time.deltaTime;
				if (timer.Timer <= 0)
				{
					_timer.GetEntity(tdx).Get<FinishTimerTag>();
				}
			}
		}

		protected virtual void Destroy(int id)
		{
			_destroyTimer.GetEntity(id).Del<TTimer>();
			_destroyTimer.GetEntity(id).Del<FinishTimerTag>();
		}
	}
}