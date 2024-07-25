using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Shooting;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.Audio
{
	internal sealed class PlayShotAudioSystem : RunInStateSystem<PlayState>
	{
		private readonly EcsFilter<ShootSignal> _signal;
		private readonly IPlaySound _playSound;
		protected override void Execute()
		{
			if (_signal.IsEmpty())
				return;
			_playSound.PlaySound(SoundsType.Shot);
		}
	}
}