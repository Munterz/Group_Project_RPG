using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimalGroup : MonoBehaviour
{
    [SerializeField] private GameObject vfxPrefab;
    [SerializeField] private Transform[] vfxSpawnPts;


    public static event Action<FarmAnimalGroup> OnFed;

    private bool isFed;
    private void Awake ()
    {
        if(PlayerPrefs.GetInt("keyValue") == 3) isFed = true;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (isFed) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            OnFed?.Invoke(this);
            isFed = true;

            foreach(Transform t in vfxSpawnPts)
            {
                GameObject temp = Instantiate(vfxPrefab, transform);
                temp.transform.position = t.position + new Vector3(0,1,0);
                Destroy(temp,2);
            }
        }
    }
}
