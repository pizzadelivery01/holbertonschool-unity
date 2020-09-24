using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Timer start trigger.
/// </summary>
public class TimerTrigger : MonoBehaviour
{
    public GameObject player;

    /// <summary>
    /// starts timer on exit.
    /// </summary>
    /// <param name="other">The collider that exited the trigger area.</param>
    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
		{
	        player.GetComponent<Timer>().enabled = true;
		}
    }
}