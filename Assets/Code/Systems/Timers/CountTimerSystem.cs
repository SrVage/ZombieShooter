using Code.Abstract.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems.Timers
{
	internal class CountTimerSystem<T> : IEcsRunSystem where T : struct, ITimerComponent
	{
		protected readonly EcsFilter<T> _timer;
		
		public void Run()
		{
			ExecuteTimer();
		}

		protected virtual void ExecuteTimer()
		{
			foreach (var tdx in _timer)
			{
				ref var timer = ref _timer.Get1(tdx);
				timer.Timer -= Time.deltaTime;
				if (timer.Timer <= 0)
				{
					Destroy(tdx);
				}
			}
		}

		protected virtual void Destroy(int tdx)
		{
			_timer.GetEntity(tdx).Del<T>();
		}
	}
}