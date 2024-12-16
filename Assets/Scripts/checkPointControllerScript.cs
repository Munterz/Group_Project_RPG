using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointControllerScript : MonoBehaviour {
    public GameObject checkPointOne;
    public GameObject checkPointTwo;

    public GameObject mainCamera;
    public GameObject player;

    public GameObject sceneOneItems;
    public GameObject sceneTwoItems;

    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.GetInt("checkPoint") == 1) {
            mainCamera.transform.position = checkPointOne.transform.position + new Vector3(0, 0, -10);
            player.transform.position = checkPointOne.transform.position;
            sceneOneItems.SetActive(true);
            sceneTwoItems.SetActive(false);
        }
        if (PlayerPrefs.GetInt("checkPoint") == 2) {
            mainCamera.transform.position = checkPointTwo.transform.position + new Vector3(0, 0, -10);
            player.transform.position = checkPointTwo.transform.position;
            sceneOneItems.SetActive(false);
            sceneTwoItems.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
