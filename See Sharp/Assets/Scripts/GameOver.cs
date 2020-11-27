using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Button keepPlaying;
	public Button endGame;
	public void Start()
	{
		Button btn = keepPlaying.GetComponent<Button>();
		Button end = endGame.GetComponent<Button>();
		Debug.Log(btn.gameObject.name);
		Debug.Log(end.gameObject.name);
		btn.onClick.AddListener(TaskOnClick);
		end.onClick.AddListener(TaskOnFinish);
	}

	public void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
	public void TaskOnFinish()
	{
		Debug.Log("You have clicked the button!");
		Application.Quit();
	}
}
