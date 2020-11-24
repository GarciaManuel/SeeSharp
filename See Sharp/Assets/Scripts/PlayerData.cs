using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{

    public float memoryTime;
    public float ecoRange;
    public int timeLeft;
    public string[] toFind;

    private void Update()
    {
    }

    public void NewLevel(float levelMemoryTime, float levelEcoRange, int levelTimeLeft, string[] levelToFind, int sceneIndex )
    {
        this.memoryTime = levelMemoryTime;
        this.ecoRange = levelEcoRange;
        this.timeLeft = levelTimeLeft;
        this.toFind = levelToFind;

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void Hurt(int decreaseTime)
    {
        this.timeLeft -= decreaseTime;
    }
}
