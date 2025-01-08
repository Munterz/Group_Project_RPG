using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeScript : MonoBehaviour {
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 1.5f;
    private float charecterVolocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    public int health;
    public GameObject droppedItem;

    // Start is called before the first frame update
    void Start() {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }
    void calculateNewMovementVector() {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * charecterVolocity;
    }

    // Update is called once per frame
    void Update() {
        if (health > 0) {
            if (Time.time - latestDirectionChangeTime > directionChangeTime) {
                latestDirectionChangeTime = Time.time;
                calculateNewMovementVector();
            }

            if (Mathf.Abs(movementPerSecond.x) > Mathf.Abs(movementPerSecond.y)) {
                movementPerSecond.y = 0;
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
                    transform.position.y + (movementPerSecond.y * Time.deltaTime));
            } else {
                movementPerSecond.x = 0;
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
                    transform.position.y + (movementPerSecond.y * Time.deltaTime));
            }
        } else {
            Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Sword1")) {
            health--;
            calculateNewMovementVector();
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
        if (collision.gameObject.CompareTag("Arrow1")) {
            health--;
            calculateNewMovementVector();
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
