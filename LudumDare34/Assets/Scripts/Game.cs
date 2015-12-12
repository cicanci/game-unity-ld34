using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour 
{
    public static Game instance;

    public GameObject spock;
	public Image arrowLeft;
	public Image arrowRight;
//    public GameObject boatPrefab;
//    public float spawnDelay;
//    public Text currentScoreText;
//    public Text highScoreText;
//    public GameObject gameOverPanel;
//    public AudioSource music;

    private Command buttonLeft;
    private Command buttonRight;
//    private Spawner spawner;
//    private float spawnCount;
//    private int currentScore;
//    private bool gameOver;

    void Start() 
	{
        instance = this;

        buttonLeft = new MoveLeftCommand();
        buttonRight = new MoveRightCommand();

//		spawner = new Spawner(boatPrefab);
//        spawnCount = 0;
//        currentScore = 0;
//        gameOver = false;

//        AddScore(0);
//        SetHighScore();
    }

    void Update() 
	{
	#if UNITY_ANDROID || UNITY_IOS
		HandleMobileInput();
	#else
		HandleDesktopInput();
	#endif
//        SpawnBoat();
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
		if (Input.GetMouseButtonDown(0)) 
		{
			FadeArrowButtons();
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
    }

	private void FadeArrowButtons() 
	{
		arrowLeft.CrossFadeAlpha(0, 5, false);
		arrowRight.CrossFadeAlpha(0, 5, false);
	}

//    private void SpawnBoat()
//    {
//        if (spawnCount < spawnDelay)
//        {
//            spawnCount += Time.deltaTime;
//        }
//
//        if (spawnCount >= spawnDelay)
//        {
//            Vector3 position = Vector3.zero;
//
//            switch (Random.Range(0, 4))
//            {
//                case 0:
//                    position = new Vector3(Random.Range(-10, 10), 7, 0);
//                    break;
//                case 1:
//                    position = new Vector3(Random.Range(-10, 10), -7, 0);
//                    break;
//                case 2:
//                    position = new Vector3(10, Random.Range(-7, 7), 0);
//                    break;
//                case 3:
//                    position = new Vector3(-10, Random.Range(-7, 7), 0);
//                    break;
//                default:
//                    break;
//            }
//
//            GameObject boat = boatSpawner.SpawnObject();
//            boat.transform.localPosition = position;
//            spawnCount = 0;
//        }
//    }
//
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
