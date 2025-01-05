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
        //if (PlayerPrefs.GetInt("collectedFruit") == 1) {
        //    fruitUi.SetActive(true);
        //    keyUi.SetActive(false);
        //    unlockedDoor.SetActive(false);
        //    fruitObeject.SetActive(false);
        //}

        //if (PlayerPrefs.GetInt("keyValue") == 1) {
        //    fruitUi.SetActive(false);
        //    keyUi.SetActive(true);
        //    unlockedDoor.SetActive(true);
        //    fruitObeject.SetActive(false);
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {

            // This means quest is already complete. You don't need to do anything in this case. Hence return!
            if (PlayerPrefs.GetInt("keyValue") != 0) return;

            if( PlayerPrefs.GetInt("collectedFruit") != 1)
            {
                // Quest#1 has not been completed yet and fruit has not been fetched
                questConvo.SetActive(true);
            }
            else
            {
                // Fruit has been fetched
                iHaveTheFruit.SetActive(true);

                fruitUi.SetActive(false);
                keyUi.SetActive(true);

                PlayerPrefs.SetInt("keyValue", 1);
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
