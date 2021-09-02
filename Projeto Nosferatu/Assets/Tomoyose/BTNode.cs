using System.Collections;

public abstract class BTNode 
{
   public enum Status { RUNNING, SUCCESS, FAILURE }
   public Status status;

   public abstract IEnumerator Run(BehaviourTree bt);
}
