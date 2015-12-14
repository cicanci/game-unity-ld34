using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
    public static Game instance;

    public GameObject spock;
	public Image arrowLeft;
	public Image arrowRight;
    public float spawnDelay;
	public float spawnDelayIncrement;
    public Text scoreText;
	public Text messageText;
	public List<string> messageList;
//    public Text highScoreText;
//    public GameObject gameOverPanel;

    private Command buttonLeft;
    private Command buttonRight;
    private float spawnCount;
    private int currentScore;
    private bool gameOver;
	private bool touchPressed;

    void Start() 
	{
        instance = this;

        buttonLeft = new MoveLeftCommand();
        buttonRight = new MoveRightCommand();

        spawnCount = 0;
        currentScore = 0;
        gameOver = false;
		touchPressed = false;

		ShowMessage("Start", Color.green);
		FadeArrowButtons();

		Debug.Log("High Score: " + PlayerPrefs.GetInt("HighScore"));
    }

    void Update() 
	{
	#if UNITY_ANDROID || UNITY_IOS
		HandleMobileInput();
	#else
		HandleDesktopInput();
	#endif
		SpawnFood();
    }

	private void HandleMobileInput() 
	{
		if (Input.touchCount > 0) 
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began) 
			{
				touchPressed = true;
				FadeArrowButtons();
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Ended) 
			{
				touchPressed = false;
			}
			else if (touchPressed) 
			{
				if (Input.GetTouch(0).position.x > (Screen.width * 0.5f)) 
				{
					buttonRight.Execute(spock);
				}
				else 
				{
					buttonLeft.Execute(spock);
				}
			}
		}
		else 
		{
			touchPressed = false;
		}
	}

	private void HandleDesktopInput() 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}

		if (Input.GetMouseButton(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (ray.origin.x > 0) 
			{
				buttonRight.Execute(spock);
			}
			else 
			{
				buttonLeft.Execute(spock);
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				buttonLeft.Execute(spock);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				buttonRight.Execute(spock);
			}
		}
    }

	private void FadeArrowButtons() 
	{
		arrowLeft.CrossFadeAlpha(0, 10, false);
		arrowRight.CrossFadeAlpha(0, 10, false);
	}

    private void SpawnFood()
    {
        if (spawnCount < spawnDelay)
        {
            spawnCount += Time.deltaTime;
        }

        if (spawnCount >= spawnDelay)
        {
			GetComponent<FoodSpawner>().SpawnFoodRandom();
            spawnCount = 0;
        }
    }

	public void ShowMessage(string message, Color color)
	{
		messageText.color = color;
		messageText.CrossFadeAlpha(1, 0, false);
		messageText.text = message;
		messageText.CrossFadeAlpha(0, 3, false);
	}

    public void AddScore(int points)
    {
        currentScore += points;
		scoreText.text = "Score: " + currentScore;

		if (spawnDelay > 1)
        {
			spawnDelay -= spawnDelayIncrement;
        }

		ShowMessage(messageList[Random.Range(0, messageList.Count)], Color.blue);

		Debug.Log("Score: " + currentScore);
    }

    private void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;

            PauseGame();
            //gameOverPanel.SetActive(true);

            if (currentScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", currentScore);
            }
        }
    }
}
