using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager Instance { get { return instance; } }
    
    public Material[] materials;
    public GameObject[] modules;
    public GameObject[] presets;
    public Transform starshipHolder;
    public int currentMaterialIndex = 0;
    public int currentPresetIndex = 0;

    private Material currentMaterial;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetCurrentMaterial(0);
        SetModel(0);
    }

    public void ChangeMaterial(int direction)
    {
        int newMaterial = 0;
        if (currentMaterialIndex + direction < 0)
        {
            newMaterial = materials.Length - 1;
        }
        else if(currentMaterialIndex + direction > materials.Length - 1)
        {
            newMaterial = 0;
        }
        else
        {
            newMaterial = currentMaterialIndex + direction;
        }

        SetCurrentMaterial(newMaterial);
    }

    public void ChangeShip(int direction)
    {
        int newPreset = 0;

        if (currentPresetIndex + direction < 0)
        {
            newPreset = materials.Length - 1;
        }
        else if (currentPresetIndex + direction > presets.Length - 1)
        {
            newPreset = 0;
        }
        else
        {
            newPreset = currentPresetIndex + direction;
        }

        SetModel(newPreset);
    }

    public void SetCurrentMaterial(int index)
    {
        currentMaterial = materials[index];
        currentMaterialIndex = index;
        ApplyMaterial();
    }

    public void SetModel(int index)
    {
        if(starshipHolder.childCount != 0) 
        { 
            Destroy(starshipHolder.GetChild(0).gameObject); 
        }
        Instantiate(presets[index], starshipHolder.position, starshipHolder.rotation, starshipHolder);
        currentPresetIndex = index;
        ApplyMaterial();
    }

    private void ApplyMaterial()
    {
        if (starshipHolder.childCount != 0)
        {
            foreach (Transform child in starshipHolder.GetChild(starshipHolder.childCount - 1))
            {
                child.GetComponent<MeshRenderer>().material = currentMaterial;
            }
        }
    }
}
