using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAreaSpawn : MonoBehaviour {
    public GameObject spawnPoint;
    public GameObject prevoiusScene;
    public GameObject newScene;
    public GameObject mainCamera;

    public Animator sceneChangeAnim;

    [SerializeField]
    private GameObject doorObj;
    [SerializeField]
    private int doorPassKey;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("keyValue") >= doorPassKey) {

            if(doorObj != null)
            {
                doorObj.SetActive(false);
            }

            sceneChangeAnim.Play("SwitchScene");
            mainCamera.transform.position = spawnPoint.transform.position + new Vector3(0, 0, -10);
            other.transform.position = spawnPoint.transform.position;
            prevoiusScene.SetActive(false);
            newScene.SetActive(true);
        }
    }
}
