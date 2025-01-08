using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private GameObject vfxPrefab;

    public static event Action<Crop> OnHarvested;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword1"))
        {
            OnHarvested?.Invoke(this);

            GameObject temp = Instantiate(vfxPrefab);
            temp.transform.position = transform.position;
            Destroy(temp, 2);

            Destroy(gameObject);
        }
    }
}
