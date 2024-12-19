using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    
    private void OnEnable ()
    {
        Debug.LogError("OnEnable");
    }
    private void OnDisable ()
    {
        Debug.LogError("OnDisable");
    }
    private void Awake ()
    {
        Debug.LogError("Awake");
    }
    private void Start ()
    {
        Debug.LogError("Start");
    }

    private void Update ()
    {
        Debug.LogError("Update");
    }
    private void LateUpdate ()
    {
        Debug.LogError("LateUpdate");
    }
    private void FixedUpdate ()
    {
        Debug.LogError("FixedUpdate");
    }
}
