using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaQuest : MonoBehaviour
{
    QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        questManager.acharChave2 = true;
    }
}
