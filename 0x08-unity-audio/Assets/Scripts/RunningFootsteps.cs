using UnityEngine;

public class RunningFootsteps : MonoBehaviour
{
	public AudioClip clip;
    public AudioSource audioSource;

    private void Step()
    {
        audioSource.PlayOneShot(clip);
    }
}