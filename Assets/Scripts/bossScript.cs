using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour {
    public GameObject flameBall;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public float attackingCoolDown;
    public int timeBetweenAttack;
    public int health;
    public GameObject blockingWall;

    // Start is called before the first frame update
    void Start() {
        health = 3;
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            blockingWall.SetActive(false);
            gameObject.SetActive(false);
        }

        if (attackingCoolDown > 0) {
            attackingCoolDown -= Time.deltaTime;
        } else {
            Instantiate(flameBall, target1.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(flameBall, target2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(flameBall, target3.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(flameBall, target4.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            attackingCoolDown = timeBetweenAttack;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Sword1")) {
            health--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WhiteColor());
        }

        if (collision.gameObject.CompareTag("Arrow1")) {
            health--;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(WhiteColor());
        }
    }

    IEnumerator WhiteColor() {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
