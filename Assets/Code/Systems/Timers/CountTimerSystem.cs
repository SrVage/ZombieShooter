using Code.Abstract.Interfaces;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Timers
{
	internal class CountTimerSystem<T> : IEcsRunSystem where T : struct, ITimerComponent
	{
		protected readonly EcsFilter<T>.Exclude<FinishTimerTag> _timer;
		protected readonly EcsFilter<T, FinishTimerTag> _destroyTimer;
		
		public void Run()
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
			_destroyTimer.GetEntity(id).Del<T>();
			_destroyTimer.GetEntity(id).Del<FinishTimerTag>();
		}
	}
}