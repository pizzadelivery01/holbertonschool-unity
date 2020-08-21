using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Text winLoseText;
	public Text scoreText;
	public Text healthText;
    public float speed;
    private Rigidbody body;
    private Vector3 movement;
    private int score = 0;
    public int health = 5;
	private GameObject WinLoseBG;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody> ();
        speed = 50.0F;
		WinLoseBG = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
		
    }
    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (health == 0)
        {
			playerLose();
            ///Debug.Log("Game Over!");
            //SceneManager.LoadScene("maze");
            score = 0;
			health = 5;
        }
		if (Input.GetKeyDown(KeyCode.Escape))
        {
        	SceneManager.LoadScene(0);
    	}
    }
    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
       movePlayer(movement);
    }
    void movePlayer(Vector3 direction)
    {
        body.AddForce(direction * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score += 1;
			SetScoreText();
            //Debug.Log("Score: " + score);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
			SetHealthText();
            //Debug.Log(string.Format("Health: {0}", health));
        }
          if (other.gameObject.tag == "Goal")
        {
			playerWin();
            //Debug.Log(string.Format("You win!"));
        }
    }
	/// <summary>
	/// sets score text
	/// </summary>
	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
	/// <summary>
	/// sets health text
	/// </summary>
	void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
	/// <summary>
	/// sets win text
	/// </summary>
	void playerWin()
	{
		WinLoseBG.transform.GetChild(0).GetComponent<Text>().text = "You Win!";
        WinLoseBG.transform.GetChild(0).GetComponent<Text>().color = Color.black;
        WinLoseBG.GetComponent<Image>().color = Color.green;
		WinLoseBG.SetActive(true);
		StartCoroutine(LoadScene(3));
	}
	/// <summary>
	/// sets lose text
	/// </summary>
	void playerLose()
	{
        WinLoseBG.transform.GetChild(0).GetComponent<Text>().text = "Game Over!";
        WinLoseBG.transform.GetChild(0).GetComponent<Text>().color = Color.white;
		WinLoseBG.SetActive(true);
        StartCoroutine(LoadScene(3));
	}
	IEnumerator LoadScene(float seconds)
	{
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
