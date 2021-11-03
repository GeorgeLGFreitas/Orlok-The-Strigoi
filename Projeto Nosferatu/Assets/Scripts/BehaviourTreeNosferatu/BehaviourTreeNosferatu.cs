using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeNosferatu : MonoBehaviour
{
    public BTNode root;

    public IEnumerator Begin()
    {
        while(true)
        {
            yield return StartCoroutine(root.Run(this));
        }
    }
}