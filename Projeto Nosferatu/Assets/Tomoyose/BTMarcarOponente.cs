using System.Collections;
using System.Collections.Generic;

public class BTMarcarOponente : BTNode
{
      public override IEnumerator Run(BehaviourTree bt) 
    {

      GameObject[] oponentes = GameObject.FindGameObjectWithTag("NPC");
      GameObject alvo = null;
      float distancia = MathF.Infinity;
      foreach (GameObject oponente in oponentes)
      {
        if(oponente == bt.gameObject) continue;
        float dist = Vector3.Distancia(bt.transform.position, oponente.transform.position);
        if (dist < distancia)
        {
          alvo = oponente;
          distancia = dist;
        }
      }
      NPC npc = bt.GetComponent<NPC>();
      if (alvo)
      {
        npc.alvo = alvo;
        status = Status.SUCCESS;
      }
      else
      {
        npc.alvo = null;
        status = Status.FAILURE;
      }
      Print(bt);
      yield break;
    }
}