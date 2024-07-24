using Code.Components.Shooting;
using Leopotam.Ecs;

namespace Code.Systems.Shooting
{
	internal sealed class HitAnimationSystem : IEcsRunSystem
	{
		private readonly EcsFilter<ShootSignal> _shootSignal;
		
		
		public void Run()
		{
			throw new System.NotImplementedException();
		}
	}
}