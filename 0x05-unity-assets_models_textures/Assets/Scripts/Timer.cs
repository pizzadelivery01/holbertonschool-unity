using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float time = 0f;
    private bool stop = false;

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
		        timerText.color = Color.green;
    		    timerText.fontSize = 60;
        		this.GetComponent<Timer>().enabled = false;
			}
	}
}