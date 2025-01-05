using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questController : MonoBehaviour {
    public GameObject questConvo;
    public GameObject inQuestConvo;
    public GameObject iHaveTheFruit;
    public GameObject fruitObeject;
    public GameObject unlockedDoor;

    public GameObject fruitUi;
    public GameObject keyUi;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (PlayerPrefs.GetInt("collectedFruit") == 1) {
            fruitUi.SetActive(true);
            keyUi.SetActive(false);
            unlockedDoor.SetActive(false);
            fruitObeject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("keyValue") == 1) {
            fruitUi.SetActive(false);
            keyUi.SetActive(true);
            unlockedDoor.SetActive(true);
            fruitObeject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (PlayerPrefs.GetInt("keyValue") == 0) {
                if (PlayerPrefs.GetInt("questAccepted") == 0) {
                    questConvo.SetActive(true);
                    inQuestConvo.SetActive(false);
                    iHaveTheFruit.SetActive(false);
                }
                if (PlayerPrefs.GetInt("questAccepted") == 1) {
                    if (PlayerPrefs.GetInt("collectedFruit") == 1) {
                        iHaveTheFruit.SetActive(true);
                        questConvo.SetActive(false);
                        inQuestConvo.SetActive(false);
                    } else {
                        questConvo.SetActive(false);
                        inQuestConvo.SetActive(true);
                        iHaveTheFruit.SetActive(false);
                    }

                }
            }
        }
    }

    public void noToQuest() {
        PlayerPrefs.SetInt("questAccepted", 0);
        questConvo.SetActive(false);
        inQuestConvo.SetActive(false);
    }
    public void acceptQuest() {
        PlayerPrefs.SetInt("questAccepted", 1);
        questConvo.SetActive(false);
        inQuestConvo.SetActive(false);
        iHaveTheFruit.SetActive(false);
    }
    public void FruitButton() {
        PlayerPrefs.SetInt("keyValue", 1);
        questConvo.SetActive(false);
        inQuestConvo.SetActive(false);
        iHaveTheFruit.SetActive(false);
    }
}
