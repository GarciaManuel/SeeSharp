using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private Text eco;

    [SerializeField]
    private Text memo;

    [SerializeField]
    private Text inventory;

    [SerializeField]
    private Text timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        eco.text = $"Rango de ecolocaliación: {PlayerData.Instance.ecoRange} mts";
        memo.text =  $"Memoria: {PlayerData.Instance.memoryTime} s";
    }

    // Update is called once per frame
    void Update()
    {
        PaintInventory();
        timeLeft.text = $"Tiempo restante: { (int)PlayerData.Instance.timeLeft } s";
    }

    void PaintInventory()
    {
        var inventoryText = "";

        foreach (string el in PlayerData.Instance.toFind)
        {
            int index = el.IndexOf("_");
            var parsedEl = el.Substring(0, index);
            inventoryText += parsedEl + "\n";
        }
        if(inventoryText == "")
        {
            inventoryText = "La salida";
        }
        inventory.text = inventoryText;
    }
}
