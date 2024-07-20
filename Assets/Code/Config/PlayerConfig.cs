using Code.Abstract;
using UnityEngine;

namespace Code.Config
{
	[CreateAssetMenu(menuName = "Configs/Player config")]
	public class PlayerConfig : ScriptableObject
	{
		public EntityInstaller PlayerPrefab;
	}
}