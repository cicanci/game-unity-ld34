using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void OnClick(int sceneIndex)
    {
        //Time.timeScale = 1; //unpause game
		SceneManager.LoadScene(sceneIndex);
    }
}
