using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private void OnEnable ()
    {
        SetValue();
    }
    public void SetValue ()
    {
        label.text = PlayerPrefs.GetInt("keyValue").ToString();
    }
}
