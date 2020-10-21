using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// mainmenu class
/// </summary>
public class MainMenu : MonoBehaviour
{
	/// <summary>
	/// loads level
	/// </summary>
	/// <param name="level">level selected</param>
	public void LevelSelect(int level)
	{
		Time.timeScale = 1f;
		if (level == 1)
			SceneManager.LoadScene("Level01");
		if (level == 2)
			SceneManager.LoadScene("Level02");
		if (level == 3)
			SceneManager.LoadScene("Level03");
	}
	/// <summary>
	/// loads options menu
	/// </summary>
	public void Options()
	{
		PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("Options");
	}
	public void Exit()
	{
		Application.Quit();
		Debug.Log("Exited");
	}
}