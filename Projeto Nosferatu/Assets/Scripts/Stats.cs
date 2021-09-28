using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField]
    float maxStamina;
    public float atualStamina;

    [SerializeField]
    float maxSanidade;
    float atualSanidade;

    [SerializeField]
    float maxCantil;
    float atualCantil;

    [SerializeField]
    float maxTocha;
    float atualTocha;

    [SerializeField]
    float timer;
    [SerializeField]
    float sanidadeDecaimento;

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


    private void Start()
    {
        atualStamina = maxStamina;
        atualSanidade = maxSanidade;
        atualCantil = 0;

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

    private void FixedUpdate()
    {
        #region Sliders
        staminaSlider.value = atualStamina;
        sanidadeSlider.value = atualSanidade;
        cantilSlider.value = atualCantil;
        tochaSlider.value = atualTocha;
        #endregion

        if (movimento.velocity > 3)
        {
            atualStamina -= 0.1f;
        }

        if (atualStamina < 0)
        {
            atualStamina = 0;
        }

        if (atualCantil == 0)
        {
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                float consumido;

                consumido = atualCantil;


                if (atualCantil + atualStamina > maxStamina)
                {
                    consumido = maxStamina - atualStamina;

                    atualCantil -= consumido;
                    atualStamina = maxStamina;
                }
                else
                {
                    atualCantil -= consumido;
                    atualStamina += consumido;

                    atualStamina += consumido;
                }
            }
        }

        if (atualSanidade == 0) //GAMEOVER
        {
            derrota.gameObject.SetActive(true);
        }

        if (jogador.tocha == true)
        {
            
            tochaSlider.gameObject.SetActive(true);

            float tochaDecaimento = 0.05f;
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
                    //Efeitos
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
                    //Efeitos
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
                    //Efeitos
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
            }
        }
    }
}