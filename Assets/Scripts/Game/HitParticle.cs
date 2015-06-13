using UnityEngine;
using System.Collections.Generic;

public class HitParticle : ParticleEffect
{
	private AudioSource m_AudioSource = null;
	private static List<AudioClip> s_AudioClip = new List<AudioClip> ();

	private void Awake()
	{
		m_AudioSource = GetComponent<AudioSource> ();

	}

	private void OnEnable()
	{
		//m_AudioSource.clip = BrawlerConstants.c_HitSoundEffects [Random.Range (0, BrawlerConstants.c_HitSoundEffects.Count-1)];
		//m_AudioSource.Play ();

	}

}