using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    [SerializeField]
    private KeyUI keyUI;
    [SerializeField]
    private GameObject QuestStartUI, QuestEndUI;

    private List<FarmAnimalGroup> animalGroups;

    private bool AllFed;

    private void Awake ()
    {
        //PlayerPrefs.SetInt("keyValue", 2);
        animalGroups = new List<FarmAnimalGroup>();
        animalGroups = FindObjectsByType<FarmAnimalGroup>(FindObjectsSortMode.None).ToList();
    }

    private void OnEnable ()
    {
        FarmAnimalGroup.OnFed += OnFed;
    }
    private void OnDisable ()
    {
        FarmAnimalGroup.OnFed -= OnFed;
    }
    private void OnFed (FarmAnimalGroup group)
    {
        if (animalGroups.Contains(group))
        {
            animalGroups.Remove(group);
        }
        if (animalGroups.Count == 0) AllFed = true;
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("keyValue") != 2) return;

            if (!AllFed)
            {
                QuestStartUI.SetActive(true);
            }
            else
            {
                QuestEndUI.SetActive(true);
                PlayerPrefs.SetInt("keyValue", 3);

                keyUI.gameObject.SetActive(true);
                keyUI.SetValue();
            }
        }
    }
}
