using Cinemachine;
using Code.Abstract.Interfaces;

namespace Code.Components
{
	public struct CinemachineComponent : IValueComponent<CinemachineVirtualCamera>
	{
		public CinemachineVirtualCamera Value;
		public CinemachineComposer Composer;

		public void SetValue(CinemachineVirtualCamera value)
		{
			Value = value;
			Composer = value.GetCinemachineComponent<CinemachineComposer>();
		}
	}
}