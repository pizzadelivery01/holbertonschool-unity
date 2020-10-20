using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseM;
	bool isPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
				Resume();

			else
				Pause();
		}
	}

	public void Pause()
	{
		Time.timeScale = 0;
		isPaused = true;
		PauseM.gameObject.SetActive(true);
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void Resume()
	{
		Time.timeScale = 1;
		isPaused = false;
		PauseM.gameObject.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Options()
	{
		PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("Options");
	}
}