using Code.Abstract;
using UnityEngine;

namespace Code.Config
{
	[CreateAssetMenu(menuName = "Configs/Enemy config")]
	public class EnemyConfig : ScriptableObject
	{
		public EntityInstaller EnemyPrefab;
		public int MaxEnemyCount;
	}
}