using System.Collections.Generic;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Config;
using UnityEngine;
using Zenject;

namespace Code.Services
{
	internal sealed class PlaySoundService : IPlaySound
	{
		private readonly AudioSource _audioSource;
		private readonly Dictionary<SoundsType, AudioClip> _audioClips = new Dictionary<SoundsType, AudioClip>();

		[Inject]
		public PlaySoundService(SoundsConfig soundsConfig)
		{
			_audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
			foreach (var sound in soundsConfig.Sounds)
			{
				_audioClips.Add(sound.Type, sound.AudioClip);
			}
		}

		public void PlaySound(SoundsType soundsType)
		{
			_audioSource.PlayOneShot(_audioClips[soundsType]);
		}
	}
}