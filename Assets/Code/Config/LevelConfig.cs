using UnityEngine;

namespace Code.Config
{
	[CreateAssetMenu(menuName = "Configs/Level config")]
	public class LevelConfig : ScriptableObject
	{
		public GameObject Prefab;
	}
}