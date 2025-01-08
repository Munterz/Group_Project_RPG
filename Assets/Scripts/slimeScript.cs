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

    [SerializeField]
    private GameObject takeDamageVFX;

    
    [SerializeField]
    private float activePlayerPositionThreshold;
    [SerializeField]
    private Transform defaultPosition;

    private Transform currentTarget;

    // Update is called once per frame
    void Update() {
        //if (Vector2.Distance(Player.transform.position, this.transform.position) < interactRange || seenPlayer == true) {
        //    seenPlayer = true;
        //    if (health > 0) {
        //        moving = true;
        //        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        //    }
        //    if (health <= 0)
        //    {
        //        Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        //        gameObject.SetActive(false);
        //    }
        //}
        

        if (Vector2.Distance(Player.transform.position, this.transform.position) < interactRange)
        {
            currentTarget = Player.transform;
            //seenPlayer = true;
        }
        if(Player.transform.position.x < activePlayerPositionThreshold)
        {
            currentTarget = defaultPosition;
        }

        if (currentTarget == null) return;

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Sword1")) {
            seenPlayer = true;

            GameObject vfx = Instantiate(takeDamageVFX);
            vfx.transform.position = transform.position;
            Destroy(vfx, 2);

            health--;
            if (health > 0) {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -100 * Time.deltaTime);
            }
            else
            {
                Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                gameObject.SetActive(false);
            }
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
        if (collision.gameObject.CompareTag("Arrow1")) {
            seenPlayer = true;
            health--;

            GameObject vfx = Instantiate(takeDamageVFX);
            vfx.transform.position = transform.position;
            Destroy(vfx, 2);

            if (health > 0) {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -100 * Time.deltaTime);
            }
            else
            {
                Instantiate(droppedItem, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                gameObject.SetActive(false);
            }
            //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
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
