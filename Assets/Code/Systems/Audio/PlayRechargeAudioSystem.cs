using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Components.Shooting;
using Code.Components.States;
using Leopotam.Ecs;

namespace Code.Systems.Audio
{
	internal sealed class PlayRechargeAudioSystem : RunInStateSystem<PlayState>
	{
		private readonly IPlaySound _playSound;
		private readonly EcsFilter<StartRechargeSignal> _signal;
		protected override void Execute()
		{
			if (_signal.IsEmpty())
				return;
			_playSound.PlaySound(SoundsType.Recharge);
		}
	}
}