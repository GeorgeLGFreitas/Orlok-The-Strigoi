using System.Collections;
using UnityEngine;

public abstract class BTNode 
{
   public enum Status { RUNNING, SUCCESS, FAILURE }
   public Status status;

   public abstract IEnumerator Run(BehaviourTreeNosferatu bt);

   public void Print(BehaviourTreeNosferatu bt)
   {
      string cor = "cyan";
      if (status == Status.SUCCESS) cor = "green";
      else if (status == Status.FAILURE) cor = "orange";

      string texto = bt.name + "  -  " + this.GetType().Name + "  :  " + status.ToString();
      Debug.Log("<color=\"" + cor + "\">" + texto + "</color>"); 
   }
}
