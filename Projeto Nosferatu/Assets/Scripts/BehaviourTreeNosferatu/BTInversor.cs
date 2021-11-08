using System.Collections;

public class BTInversor : BTNode
{
    public BTNode child;
    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {
        status = Status.RUNNING;

        bt.StartCoroutine(child.Run(bt));

        while (child.status == Status.RUNNING) yield return null;

        if (child.status == Status.SUCCESS) status = Status.FAILURE;
        else status = Status.SUCCESS;
        Print(bt);

    }
}