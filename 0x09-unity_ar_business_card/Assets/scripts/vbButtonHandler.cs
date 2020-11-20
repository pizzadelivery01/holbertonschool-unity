using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class vbButtonHandler : MonoBehaviour
{
	
	string vbName;
    // Start is called before the first frame update
    void Start()
    {
		var VBBS = GetComponentsInChildren<VirtualButtonBehaviour>();

		for (int i = 0; i < VBBS.Length; ++i)
		{
			VBBS[i].RegisterOnButtonPressed(OnButtonPressed);
			//VBBS[i].RegisterOnButtonReleased(OnButtonReleased);
		}
    }
	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		vbName = vb.VirtualButtonName;

		if (vbName == "EmailVirtualButton")
		{
			Application.OpenURL("mailto:pizzadeliveryps4@gmail.com");
		}
		else if ( vbName == "LinkedinVirtualButton")
		{
			Application.OpenURL("https://www.linkedin.com/in/jeremy-bedolla-449291a/");
		}
		else if ( vbName == "TwitterVirtualButton")
		{
			Application.OpenURL("https://twitter.com/pizzadelivery01");
		}
		else if ( vbName == "TwitchVirtualButton")
		{
			Application.OpenURL("https://twitch.com/pizzadelivery01");
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
