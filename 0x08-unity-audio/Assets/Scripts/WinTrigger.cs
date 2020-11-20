using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public bool done = false;


    /// <summary>
    /// ends timer.
    /// </summary>
    /// <param name="other">The other Collider .</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && done == false)
        {
			done = true;
            other.gameObject.SendMessage("Stop");
		}
    }
}