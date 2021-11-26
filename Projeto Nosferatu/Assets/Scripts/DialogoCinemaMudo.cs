using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DialogoCinemaMudo : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    GameObject cutsceneFala1;
    [SerializeField]
    GameObject cutsceneFala2;
    [SerializeField]
    GameObject finalFala1;
    [SerializeField]
    GameObject finalFala2;
    [SerializeField]
    GameObject final;
    [SerializeField]
    GameObject cutscene;

    public float timer;
    public float timeLimit;
    bool ligatempo, one, two;

    void Start()
    {
        timer = 0;
        final.SetActive(false);
        cutscene.SetActive(false);
    }

    public void FalasCutscene1()
    {
        ligatempo = true;
        timer = 0;
        one = true;
        two = false;
        cutscene.SetActive(true);

    }

    public void FalasFinal()
    {
        final.SetActive(true);
        finalFala1.SetActive(true);
        if (Input.GetKey(KeyCode.Space) || timer <= 0)
        {
            finalFala1.SetActive(false);
            finalFala2.SetActive(true);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (ligatempo)
        {
            if (one)
            {
                cutsceneFala1.SetActive(true);
                if (timer >= timeLimit || Input.GetKey(KeyCode.Space))
                {

                    timer = 0;
                    cutsceneFala1.SetActive(false);
                    two = true;
                    one = false;

                }
            }
            if (two)
            {
                cutsceneFala2.SetActive(true);

                if (Input.GetKey(KeyCode.Space) || timer >= timeLimit)
                {
                    timer = 0;
                    cutsceneFala2.SetActive(false);
                    cutscene.SetActive(false);
                    two = false;
                    ligatempo = false;
                }
            }
        }
    }

}
