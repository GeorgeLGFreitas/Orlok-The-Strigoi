using UnityEngine;

public class AtivavelCantil : Ativavel
{
    Jogador jogador;
    [SerializeField]
    GameObject parentGameObject;

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    public override void Ativar()
    {
        jogador.cantil = true;
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        Destroy(parentGameObject);
    }
}
