using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableCrops : MonoBehaviour
{
    private void Awake ()
    {
        //PlayerPrefs.SetInt("keyValue", 1);//temp
        if (PlayerPrefs.GetInt("keyValue") != 1)
        {
            gameObject.SetActive(false);
        }
    }
}
