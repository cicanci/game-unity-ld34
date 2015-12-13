using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour 
{
    public static Game instance;

    public GameObject spock;
	public Image arrowLeft;
	public Image arrowRight;
    public float spawnDelay;
//    public Text currentScoreText;
//    public Text highScoreText;
//    public GameObject gameOverPanel;
//    public AudioSource music;

    private Command buttonLeft;
    private Command buttonRight;
    private float spawnCount;
//    private int currentScore;
//    private bool gameOver;

    void Start() 
	{
        instance = this;

        buttonLeft = new MoveLeftCommand();
        buttonRight = new MoveRightCommand();

        spawnCount = 0;
//        currentScore = 0;
//        gameOver = false;

//        AddScore(0);
//        SetHighScore();

		FadeArrowButtons();
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

	private bool touchPressed = false;

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

//    private void SetHighScore()
//    {
//        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
//    }
//
//    public void AddScore(int points)
//    {
//        currentScore += points;
//        if (currentScoreText != null)
//        {
//            currentScoreText.text = currentScore.ToString();
//        }
//
//        // This makes the game more intersting
//        spawnDelay -= Time.deltaTime;
//        monster.GetComponent<Character>().speed -= Time.deltaTime;
//
//        if (spawnDelay < 0)
//        {
//            spawnDelay = 0;
//        }
//    }
//
//    private void PauseGame()
//    {
//        if (Time.timeScale != 0)
//        {
//            Time.timeScale = 0;
//        }
//        else
//        {
//            Time.timeScale = 1;
//        }
//
//        Debug.Log(Time.timeScale);
//    }
//
//    public void GameOver()
//    {
//        if (!gameOver)
//        {
//            gameOver = true;
//
//            PauseGame();
//            gameOverPanel.SetActive(true);
//
//            if (currentScore > PlayerPrefs.GetInt("HighScore"))
//            {
//                PlayerPrefs.SetInt("HighScore", currentScore);
//            }
//
//            music.Stop();
//            PlaySound("GameOver");
//        }
//    }
//
//    public void PlaySound(string pFileName)
//    {
//        AudioClip audioClip = Resources.Load<AudioClip>(pFileName);
//        GetComponent<AudioSource>().PlayOneShot(audioClip);
//    }
}
