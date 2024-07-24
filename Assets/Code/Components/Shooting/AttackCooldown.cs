using Code.Abstract.Interfaces;

namespace Code.Components.Shooting
{
	public struct AttackCooldown : ITimerComponent
	{
		public float Timer { get; set; }
	}
}