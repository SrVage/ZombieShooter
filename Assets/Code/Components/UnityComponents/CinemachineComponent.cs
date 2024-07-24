using Cinemachine;
using Code.Abstract.Interfaces;

namespace Code.Components
{
	public struct CinemachineComponent : IValueComponent<CinemachineVirtualCamera>
	{
		public CinemachineVirtualCamera Value
		{
			readonly get => _value;
			set
			{
				_value = value;
				Composer = value.GetCinemachineComponent<CinemachineComposer>();
			}
		}

		public CinemachineComposer Composer;
		private CinemachineVirtualCamera _value;
	}
}