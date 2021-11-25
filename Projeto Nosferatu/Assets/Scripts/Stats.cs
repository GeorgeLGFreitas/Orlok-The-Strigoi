using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{
    public Text textoC;
    bool unica = true;
    bool endPrimeiroDialogo = false;

    public GameObject efeitoSanidade;
    public GameObject efeitoStamina;
    Volume volumeStamina;
    Volume volumeSanidade;
    Vignette vignette;

    [Header("Stats")]

    [Header("Stamina")]

    [SerializeField]
    float maxStamina;
    public float atualStamina;
    bool canRun;

    [Header("Sanidade")]

    [SerializeField]
    float maxSanidade;
    public float atualSanidade;

    [Header("Cantil")]

    [SerializeField]
    float maxCantil;
    float atualCantil;
    bool restoreInitialStamina = true;

    [Header("Tocha")]

    [SerializeField]
    public float maxTocha;
    public float atualTocha;

    [Header("Pedra")]

    public int atualPedra;
    public bool primeiraMira = false;
    public bool primeiroTiro = false;
    public bool arremessouPrimeiraVez = false;
    [SerializeField]
    Text countPedraText;
    public bool pedraSelected;

    [Header("Garrafa")]

    public int atualGarrafa;
    [SerializeField]
    Text countGarrafaText;
    public bool garrafaSelected;

    [Header("Inventario")]

    [SerializeField]
    int sizeIndex = 8;
    int selectedSlot;
    [SerializeField]
    GameObject[] itemsGroup;
    public bool[] itemsGroupBool;

    public int numeroChave;
    [SerializeField]
    Text numeroChaveText;

    public int numeroAlimento;
    [SerializeField]
    Text numeorAlimentoText;

    public int numeroDiscoPrato;
    [SerializeField]
    Text numeroDiscoPratoText;

    public int numeroLivroI;
    [SerializeField]
    Text numeroLivroIText;

    public int numeroLivroIII;
    [SerializeField]
    Text numeroLivroIIIText;

    public int numeroLivroXIII;
    [SerializeField]
    Text numeroLivroXIIIText;

    [Header("Decaimentos + Timer")]

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
    QuestManager questManager;

    [Header("GameObjects")]

    [SerializeField]
    GameObject cantilGameObject;
    [SerializeField]
    DialogueTrigger drunkCantilDialogo;
    [SerializeField]
    DialogueTrigger tochaEsgotadaDialogo;

    private void Start()
    {
        maxStamina = 100;
        atualStamina = 20;
        atualSanidade = maxSanidade;
        atualCantil = maxCantil;
        atualTocha = maxTocha;

        #region Sliders

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = atualStamina;

        sanidadeSlider.maxValue = maxSanidade;
        sanidadeSlider.value = atualSanidade;

        cantilSlider.maxValue = maxCantil;
        cantilSlider.value = atualCantil;

        tochaSlider.maxValue = maxTocha;
        tochaSlider.value = atualTocha;

        #endregion

        tochaSlider.gameObject.SetActive(false);

        questManager = GetComponent<QuestManager>();

        textoC.text = "";

        pedraSelected = true;
        garrafaSelected = false;

        atualPedra = 0;

        selectedSlot = 0;

        for (int i = 0; i < itemsGroup.Length; i++)
        {
            itemsGroup[i].SetActive(false);
            itemsGroupBool[i] = false;
        }

        itemsGroup[0].SetActive(true);
        itemsGroupBool[0] = true;
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

        #region Stamina

        if (canRun)
        {
            if (movimento.velocity > 3 & movimento.movi != Vector3.zero)
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

        #endregion

        #region Cantil

        if (jogador.cantil)
        {
            if (restoreInitialStamina)
            {
                textoC.text = "'F' para beber";
            }

            if (atualCantil == 0)
            {

            }
            else
            {
                if (Input.GetKey(KeyCode.F))
                {
                    textoC.text = "";

                    questManager.bebeuVinho = true;

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


                        if (restoreInitialStamina)
                        {
                            drunkCantilDialogo.TriggerDialogue();
                            restoreInitialStamina = false;
                        }
                    }
                }
            }
        }

        #endregion

        countPedraText.text = "" + atualPedra;

        if (atualSanidade == 0) //GAMEOVER
        {
            vignette.intensity.value = 1f;
        }

        #region Tocha

        if (jogador.tocha == true)
        {
            
            tochaSlider.gameObject.SetActive(true);

            atualTocha -= tochaDecaimento * Time.deltaTime;
            atualSanidade = maxSanidade;

            if (atualTocha <= -1)
            {
                atualTocha = 0;
                tochaEsgotadaDialogo.TriggerDialogue();
            }
        }

        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                atualSanidade -= sanidadeDecaimento;
                if (atualSanidade >= 70)
                {
                    vignette.intensity.value -= efeitosanidadeDecaimento;
                }
                else if (atualSanidade < 70 & atualSanidade >= 40)
                {
                    vignette.intensity.value -= efeitosanidadeDecaimento * 2;
                }
                else if (atualSanidade < 40)
                {
                    vignette.intensity.value -= efeitosanidadeDecaimento * 3;
                }
            }
        }

        #endregion

        if (questManager.interagiuPedra)
        {
            textoC.text = "Segure o botão direito para mirar.";

            if (primeiroTiro)
            {
                textoC.text = "Aperte o botão esquerdo para atirar.";

                if (arremessouPrimeiraVez)
                {
                    textoC.text = "";

                    questManager.arremessou = true;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedSlot++;
            if (selectedSlot > sizeIndex)
            {
                selectedSlot = 0;
            }

            for (int i = 0; i < itemsGroup.Length; i++)
            {
                if (itemsGroup[i] == itemsGroup[selectedSlot])
                {
                    itemsGroup[i].SetActive(true);

                    itemsGroupBool[i] = true;
                }
                else
                {
                    itemsGroup[i].SetActive(false);

                    itemsGroupBool[i] = false;
                }
            }

            /*
            0 - Pedra
            1 - Garrafa
            2 - Livro I
            3 - Livro III
            4 - Livro XIII
            5 - Alimento
            6 - Chave
            7 - Disco/Prato
            */
        }

        numeroChaveText.text = "" + numeroChave;
        countPedraText.text = "" + atualPedra;
        countGarrafaText.text = "" + atualGarrafa;
        numeorAlimentoText.text = "" + numeroAlimento;
        numeroChaveText.text = "" + numeroChave;
        numeroDiscoPratoText.text = "" + numeroDiscoPrato;
        numeroLivroIText.text = "" + numeroLivroI;
        numeroLivroIIIText.text = "" + numeroLivroIII;
        numeroLivroXIIIText.text = "" + numeroLivroXIII;
    }
}