using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public GameObject winCanvas;
	public GameObject timerCanvas;
	public TextEditor timerText;
	public TextEditor FinalTime;


    /// <summary>
    /// ends timer.
    /// </summary>
    /// <param name="other">The other Collider .</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("Stop");
	        win();
		}
    }

	public void win()
	{
		winCanvas.SetActive(true);
		FinalTime.text = timerText.text;
		timerCanvas.SetActive(false);
	}
}