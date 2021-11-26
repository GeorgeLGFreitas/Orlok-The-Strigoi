using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelLivroColeta : Ativavel
{
    [SerializeField]
    bool isLivroIII;

    Stats stats;
    mouseCursor cursor;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        cursor = GetComponent<mouseCursor>();
    }

    public override void Ativar()
    {
        if (isLivroIII)
        {
            cursor.OriginalImage();
            stats.numeroLivroIII++;
            Destroy(gameObject);
        }
        else
        {
            cursor.OriginalImage();
            stats.numeroLivroXIII++;
            Destroy(gameObject);
        }
    }
}
