using Code.Abstract.Interfaces;

namespace Code.Components.Enemy
{
	public struct DeathTimer : ITimerComponent
	{
		public float Timer { get; set; }
	}
}