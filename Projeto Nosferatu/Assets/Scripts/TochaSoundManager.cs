using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TochaSoundManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip acesso;

    public Stats stats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioS.volume = Mathf.Clamp(stats.atualTocha, 0, 0.20f);
    }


}
