using UnityEngine;

public class AtivavelCantil : Ativavel
{
    Jogador jogador;

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    public override void Ativar()
    {
        jogador.cantil = true;
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        Destroy(gameObject);
    }
}
