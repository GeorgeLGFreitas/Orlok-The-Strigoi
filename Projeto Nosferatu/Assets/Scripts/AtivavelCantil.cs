using UnityEngine;

public class AtivavelCantil : Ativavel
{
    Jogador jogador;
    mouseCursor cursor;
    [SerializeField]
    GameObject parentGameObject;

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>();
        cursor = GetComponent<mouseCursor>();
    }

    public override void Ativar()
    {
        cursor.OriginalImage();
        jogador.cantil = true;
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        Destroy(parentGameObject);
    }
}
