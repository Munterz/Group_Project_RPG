using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest2 : MonoBehaviour
{
    [SerializeField]
    private KeyUI keyUI;
    [SerializeField]
    private GameObject QuestStartUI, QuestEndUI;

    private List<Crop> Crops;

    private bool AllHarvested;

    private void Awake ()
    {
        Crops = new List<Crop>();
        Crops = FindObjectsByType<Crop>(FindObjectsSortMode.None).ToList();
    }

    private void OnEnable ()
    {
        Crop.OnHarvested += OnHarvested;
    }
    private void OnDisable ()
    {
        Crop.OnHarvested -= OnHarvested;
    }
    private void OnHarvested (Crop crop)
    {
        if(Crops.Contains(crop))
        {
            Crops.Remove(crop);
        }
        if (Crops.Count == 0) AllHarvested = true;
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("keyValue") != 1) return;

            if (!AllHarvested)
            {
                QuestStartUI.SetActive(true);
            }
            else
            {
                QuestEndUI.SetActive(true);
                PlayerPrefs.SetInt("keyValue", 2);

                keyUI.gameObject.SetActive(true);
                keyUI.SetValue();
            }
        }
    }

}
