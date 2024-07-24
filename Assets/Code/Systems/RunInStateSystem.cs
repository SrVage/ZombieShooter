using Leopotam.Ecs;

namespace Code.Systems
{
	internal abstract class RunInStateSystem<T> : IEcsRunSystem where T : struct
	{
		protected readonly EcsFilter<T> _state;
		
		public void Run()
		{
			if (!_state.IsEmpty())
			{
				Execute();
			}
		}

		protected abstract void Execute();
	}
}