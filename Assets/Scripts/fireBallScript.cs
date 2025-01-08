using UnityEngine;

public class fireBallScript : MonoBehaviour {
    private Rigidbody2D rb;
    public float moveSpeed = 3;
    private Vector2 moveDirection;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null) {
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
