using Leopotam.Ecs;

namespace Code.Abstract
{
	public class TagComponentInstaller<T> : ComponentInstallerBase where T : struct
	{
		public override void InitComponent(EcsEntity entity)
		{
			entity.Get<T>();
		}
	}
}