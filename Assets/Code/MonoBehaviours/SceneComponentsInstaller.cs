using Cinemachine;
using UnityEngine;
using Zenject;

namespace Code.MonoBehaviours
{
	public class SceneComponentsInstaller : MonoInstaller<SceneComponentsInstaller>
	{
		[SerializeField] private CinemachineVirtualCamera _virtualCamera;
		public override void InstallBindings()
		{
			Container.Bind<CinemachineVirtualCamera>().FromInstance(_virtualCamera);
		}
	}
}