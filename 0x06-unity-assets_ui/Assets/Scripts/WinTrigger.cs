using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    /// <summary>
    /// ends timer.
    /// </summary>
    /// <param name="other">The other Collider .</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("Stop");
        }
    }
}