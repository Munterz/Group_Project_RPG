using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour {
    public static bool moving;
    public GameObject Player;
    public float speed = 2.0f;
    public float knockBackForce;
    public Rigidbody2D rb;
    public int health;

    public float interactRange;
    public bool seenPlayer;

    public GameObject droppedItem;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(Player.transform.position, this.transform.position) < interactRange || seenPlayer == true) {
            seenPlayer = true;
            if (health > 0) {
                moving = true;
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
            if (health <= 0) {
                Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Sword1")) {
            seenPlayer = true;
            health--;
            if (health > 0) {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -100 * Time.deltaTime);
            }
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
        if (collision.gameObject.CompareTag("Arrow1")) {
            seenPlayer = true;
            health--;
            if (health > 0) {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -100 * Time.deltaTime);
            }
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
    }

    IEnumerator whitecolor() {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;

    }
}