using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {

    AudioClip[] sound;

    public void GetDataSound(DataList data)
    {
        sound = data.sfx;
    }

    public void DamselGetHurt()
    {
        GetComponent<AudioSource>().pitch = 1;
        GetComponent<AudioSource>().PlayOneShot(sound[3]);
    }

    // Use this for initialization
    public void Firebullet(float pitch = 1) {
        GetComponent<AudioSource>().pitch = pitch;
        GetComponent<AudioSource>().PlayOneShot(sound[0]);
    }
	
	public void EmptyBullet(float pitch = 1) {
        GetComponent<AudioSource>().pitch = pitch;
        GetComponent<AudioSource>().PlayOneShot(sound[1]);
	}

    public void EnemyShoot(float pitch = 1)
    {
        GetComponent<AudioSource>().pitch = pitch;
        GetComponent<AudioSource>().PlayOneShot(sound[2]);
    }
}
