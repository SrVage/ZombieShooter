using Code.Abstract.Interfaces;

namespace Code.Components.Shooting
{
	public struct ShootingCooldown : ITimerComponent
	{
		public float Timer { get; set; }
	}
}