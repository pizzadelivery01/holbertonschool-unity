using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float time = 0f;
    private bool stop = false;
	public AudioSource bgm;
	public AudioSource sting;
	public Canvas winCanvas;
	public Text winText;

    /// <summary>
    /// timer UI update.
    /// </summary>
    void Update()
    {
        if (stop == false)
        {
            time += Time.deltaTime;
            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", time / 60, time % 60, time * 100 % 100);

		}
    }
	public void Stop()
	{
			{
				stop = true;
				winText.text = timerText.text;
		        timerText.enabled = false;
				bgm.Stop();
				winCanvas.gameObject.SetActive(true);
				sting.Play();
				
			}
	}
}