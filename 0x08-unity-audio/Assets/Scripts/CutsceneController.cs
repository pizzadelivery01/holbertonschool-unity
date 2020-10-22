using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{

	Animator animator;
	public GameObject mainCam;
	public GameObject Player;
	public GameObject timer;
	public GameObject cutScenecam;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}
	void Transition()
	{
		mainCam.SetActive(true);
		timer.SetActive(true);
		cutScenecam.SetActive(false);
		Player.GetComponent<PlayerController>().enabled = true;
	}
}