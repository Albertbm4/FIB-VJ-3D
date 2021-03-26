using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;
	public Sound[] sounds;

	void Awake() {
		if (instance != null) Destroy(gameObject);
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
		}
	}

	void Start() {
		PlayScenes("MainTheme");
	}
	
	public void PlayScenes(string sound) {
		Sound menu = Array.Find(sounds, item => item.name == "MainTheme");
		Sound lvl1 = Array.Find(sounds, item => item.name == "Lvl1Music");
		Sound lvl2 = Array.Find(sounds, item => item.name == "Lvl2Music");
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s != null) {
			if(s.source != null) {
				menu.source.Stop();
				lvl1.source.Stop();
				lvl2.source.Stop();
				s.source.volume = s.volume;
				s.source.Play();
			}
		}
	}

	public void PlaySound(string sound) {
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s != null) s.source.PlayOneShot(s.clip, s.volume);
	}
	
}
