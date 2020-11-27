using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerData : Singleton<PlayerData>
{

    public float memoryTime= 10;
    public float ecoRange = 10;
    public float timeLeft = 100;
    public string[] toFind;

    public void NewLevel(float levelMemoryTime, float levelEcoRange, int levelTimeLeft, int sceneIndex )
    {
        this.memoryTime = levelMemoryTime;
        this.ecoRange = levelEcoRange;
        this.timeLeft = levelTimeLeft;

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    private void Update()
    {
        this.timeLeft -= Time.deltaTime;
    }

    public void Hurt(int decreaseTime)
    {
        this.timeLeft -= decreaseTime;
        Debug.Log("Hurt, lose time");
    }

    public bool PickElement(string el)
    {
        int index = Array.IndexOf(this.toFind, el);
        if(index >= 0)
        {
            this.toFind = this.toFind.Where((val, idx) => idx != index).ToArray();

            return true;
        }

        return false;
    }
}
