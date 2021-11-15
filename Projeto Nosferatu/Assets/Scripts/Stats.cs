using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{
    public string[] texto ;
    public Text textoC;
    bool unica = true;
    bool endPrimeiroDialogo = false;

    public GameObject efeitoSanidade;
    public GameObject efeitoStamina;
    Volume volumeStamina;
    Volume volumeSanidade;
    Vignette vignette;

    [Header("Stats")]

    [SerializeField]
    float maxStamina;
    public float atualStamina;
    bool canRun;

    [SerializeField]
    float maxSanidade;
    float atualSanidade;

    [SerializeField]
    float maxCantil;
    float atualCantil;
    bool restoreInitialStamina = true;

    [SerializeField]
    float maxTocha;
    float atualTocha;

    [SerializeField]
    float timer;
    [SerializeField]
    float sanidadeDecaimento;
    [SerializeField]
    float efeitosanidadeDecaimento;
    [SerializeField]
    float tochaDecaimento;
    [SerializeField]
    float staminaDecaimento;

    [Header("Sliders")]

    [SerializeField]
    Slider staminaSlider;
    [SerializeField]
    Slider sanidadeSlider;
    [SerializeField]
    Slider cantilSlider;
    [SerializeField]
    Slider tochaSlider;

    [Header("Other Scripts")]

    [SerializeField]
    Movimento movimento;
    [SerializeField]
    Jogador jogador;

    [SerializeField]
    public RawImage derrota;

    [Header("GameObjects")]

    [SerializeField]
    Light tochaLight;
    [SerializeField]
    GameObject cantilGameObject;
    [SerializeField]
    DialogueTrigger drunkCantilDialogo;

    private void Start()
    {
        maxStamina = 100;
        atualStamina = 20;
        atualSanidade = maxSanidade;
        atualCantil = 100;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = atualStamina;

        sanidadeSlider.maxValue = maxSanidade;
        sanidadeSlider.value = atualSanidade;

        cantilSlider.maxValue = maxCantil;
        cantilSlider.value = atualCantil;

        tochaSlider.maxValue = maxTocha;
        tochaSlider.value = atualTocha;
        atualTocha = 100;

        tochaSlider.gameObject.SetActive(false);
    }

    void Awake()
    {
        efeitoSanidade = GameObject.Find("Sanidade Volume");
        volumeSanidade = efeitoSanidade.GetComponent<Volume>();
        volumeSanidade.profile.TryGet<Vignette>(out vignette);
    }

    private void FixedUpdate()
    {
        #region Sliders
        staminaSlider.value = atualStamina;
        sanidadeSlider.value = atualSanidade;
        cantilSlider.value = atualCantil;
        tochaSlider.value = atualTocha;

        if (!jogador.cantil)
        {
            cantilSlider.gameObject.SetActive(false);
            cantilGameObject.SetActive(false);
        }
        else
        {
            cantilSlider.gameObject.SetActive(true);
            cantilGameObject.SetActive(true);
        }
        #endregion


        if (canRun)
        {
            if (movimento.velocity > 3)
            {
                atualStamina -= staminaDecaimento;
            }
        }
        
        if (atualStamina <= 0)
        {
            atualStamina = 0;
            canRun = false;
        }

        else
        {
            canRun = true;
        }

        if (atualStamina <=30)
        {
            if(unica)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                unica = false;
            }
            
            
            efeitoStamina.SetActive(true);
        }

        else
        {
            efeitoStamina.SetActive(false);
        }

        if (jogador.cantil)
        {
            if (atualCantil == 0)
            {

            }
            else
            {
                if (Input.GetKey(KeyCode.F))
                {
                    float consumido;

                    consumido = atualCantil;

                    if (atualCantil + atualStamina > maxStamina)
                    {
                        consumido = maxStamina - atualStamina;

                        atualCantil -= consumido;
                        atualStamina = maxStamina;

                        if (restoreInitialStamina)
                        {
                            drunkCantilDialogo.TriggerDialogue();
                            restoreInitialStamina = false;
                        }
                    }
                    else
                    {
                        atualCantil -= consumido;
                        atualStamina += consumido;

                        atualStamina += consumido;

                        if (restoreInitialStamina)
                        {
                            drunkCantilDialogo.TriggerDialogue();
                            restoreInitialStamina = false;
                        }
                    }
                }
            }
        }

        if (atualSanidade == 0) //GAMEOVER
        {
            vignette.intensity.value = 1f;
            derrota.gameObject.SetActive(true);
        }

        if (jogador.tocha == true)
        {
            
            tochaSlider.gameObject.SetActive(true);

            atualTocha -= tochaDecaimento * Time.deltaTime;
            atualSanidade = maxSanidade;

            if (atualTocha > 70)
            {
                tochaLight.intensity = 4.1f;
            }
            else if (atualTocha < 70)
            {
                tochaLight.intensity = 3.5f;
                
                if (atualSanidade == 70)
                {
                    vignette.intensity.value = 0.3f;
                }
                else
                {
                    atualSanidade -= 0.05f;
                }
            }
            else if (atualTocha < 40)
            {
                tochaLight.intensity = 3.0f;

                if (atualSanidade == 40)
                {
                    vignette.intensity.value = 0.6f;
                }
                else
                {
                    atualSanidade -= 0.075f;
                }
            }
            else if (atualTocha < 10)
            {
                tochaLight.intensity = 2.5f;

                if (atualSanidade == 10)
                {
                    vignette.intensity.value = 0.9f;
                }
                else
                {
                    atualSanidade -= 0.1f;
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                atualSanidade -= sanidadeDecaimento;
                if(atualSanidade >= 70) vignette.intensity.value -= efeitosanidadeDecaimento;
                else if(atualSanidade < 70 & atualSanidade >= 40 ) vignette.intensity.value -= efeitosanidadeDecaimento * 2;
                else if(atualSanidade < 40) vignette.intensity.value -= efeitosanidadeDecaimento * 3;



            }
        }
    }
    
}