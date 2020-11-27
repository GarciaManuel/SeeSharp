using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	// Start is called before the first frame update

	public void Start()
	{

		StartCoroutine(RestartGame());
	}

	public IEnumerator RestartGame()
    {
		yield return new WaitForSeconds(5.0f);
		PlayerPrefs.SetInt("Scene", 0);
		SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}