using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public void Start()
	{
		StartCoroutine("RestartGame");
	}


	public IEnumerator RestartGame()
    {
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}