using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField colorValue, shipValue;
    public Color[] colors;

    private void Start()
    {
        colors = new Color[MainManager.Instance.materials.Length];
        colors[0] = Color.black;
        colors[1] = Color.cyan;
        colors[2] = new Color(0.95f, 0.475f, 0.2f, 1);
        colors[3] = Color.yellow;
        colors[4] = Color.blue;
        colors[5] = Color.green;
        colors[6] = Color.grey;
        colors[7] = Color.magenta;
        colors[8] = Color.red;
        colors[9] = Color.white;
        colorValue.GetComponent<Image>().color = colors[MainManager.Instance.currentMaterialIndex];
        shipValue.text = "0";
    }

    public void ChangeColor(int direction)
    {
        MainManager.Instance.ChangeMaterial(direction);
        colorValue.GetComponent<Image>().color = colors[MainManager.Instance.currentMaterialIndex];
    }

    public void ChangeShip(int direction)
    {
        MainManager.Instance.ChangeShip(direction);
        shipValue.text = MainManager.Instance.currentPresetIndex.ToString();
    }
}
