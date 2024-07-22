using Code.Utils;

namespace Code.Components
{
	public struct SpawnTimer
	{
		public float Value;
		[InjectField("_maxTime")] public float MaxTime;
	}
}