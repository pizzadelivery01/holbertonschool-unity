using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{

	public void UrlOpener(string url)
	{
		Application.OpenURL(url);
	}
}