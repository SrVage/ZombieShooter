using Code.Abstract.Interfaces;

namespace Code.Components.Enemy
{
	public struct NavigationTimer : ITimerComponent
	{ 
		public float Timer { get; set; }
	}
}