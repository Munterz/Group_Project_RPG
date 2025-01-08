using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void PlayAgain_OnClick ()
    {
        Debug.LogError("Reload");
        SceneManager.LoadScene("SampleScene");
    }
}
