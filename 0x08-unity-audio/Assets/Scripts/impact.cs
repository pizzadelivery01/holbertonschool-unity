using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact : MonoBehaviour
{
	public AudioClip clip;
    public AudioSource audioSource;

    private void splat()
    {
        audioSource.PlayOneShot(clip);
	}
}