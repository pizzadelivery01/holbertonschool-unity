using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(1, -24.75f, 9);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.GetComponent<Rigidbody> ().position - offset;
        transform.rotation = Quaternion.Euler(45, 0, 0);
    }
}
