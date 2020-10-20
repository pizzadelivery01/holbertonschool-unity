using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// option menu class
/// </summary>
public class OptionsMenu : MonoBehaviour
{
	public Toggle inverted;

/// <summary>
/// called once
/// </summary>
	void Start()
	{
		if (PlayerPrefs.GetString("Inverted") != "")
			inverted.isOn = bool.Parse(PlayerPrefs.GetString("Inverted"));

	}
	/// <summary>
	/// goes back to previous scene
	/// </summary>
	public void Back()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("PrevScene"));
	}

	public void Apply()
	{
		PlayerPrefs.SetString("Inverted", inverted.isOn.ToString());
	}
}