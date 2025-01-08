using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomScript : MonoBehaviour {
    public float attackingCoolDown;
    public int timeBetweenAttack;
    public GameObject attackingObjects;
    public int health;
    public GameObject droppedItem;

    // Start is called before the first frame update
    void Start() {
        attackingCoolDown = timeBetweenAttack;
    }

    // Update is called once per frame
    void Update() {
        if (attackingCoolDown > 0) {
            attackingCoolDown -= Time.deltaTime;

        } else {
            attackingObjects.SetActive(true);
            StartCoroutine(attack());
            attackingCoolDown = timeBetweenAttack;
        }

        if (health <= 0) {
            Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            gameObject.SetActive(false);
        }
    }

    IEnumerator attack() {
        yield return new WaitForSeconds(0.5f);
        attackingObjects.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Sword1")) {
            health--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            attackingObjects.SetActive(true);
            StartCoroutine(attack());
            attackingCoolDown = timeBetweenAttack;
            StartCoroutine(whitecolor());
        }
        if (collision.gameObject.CompareTag("Arrow1")) {
            health--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            attackingObjects.SetActive(true);
            StartCoroutine(attack());
            attackingCoolDown = timeBetweenAttack;
            StartCoroutine(whitecolor());
        }

    }

    IEnumerator whitecolor() {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
