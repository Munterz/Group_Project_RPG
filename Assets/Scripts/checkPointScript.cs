using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointScript : MonoBehaviour {

    public int checkPointNumeber;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (checkPointNumeber == 1) {
                PlayerPrefs.SetInt("checkPoint", 1);
            }
            if (checkPointNumeber == 2) {
                PlayerPrefs.SetInt("checkPoint", 2);
            }
        }
    }
}
