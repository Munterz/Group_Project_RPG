using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallScript : MonoBehaviour {
    private Rigidbody2D rb;
    private GameObject[] target;
    public float moveSpeed = 3;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectsWithTag("Player");
        moveDirection = (target[0].transform.position - transform.position).normalized * moveSpeed;
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
