using System;
using Code.Abstract;
using UnityEngine;

namespace Code.Config
{
	[CreateAssetMenu(menuName = "Configs/Sounds config")]
	public class SoundsConfig : ScriptableObject
	{
		[Serializable]
		public class Sound
		{
			public SoundsType Type;
			public AudioClip AudioClip;
		}

		public Sound[] Sounds;
	}
}