using System.Collections;
using System.Collections.Generic;

public class BTSelector : BTNode
{
    public List<BTNode> children = new List<BTNode>();

    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {
        status = Status.RUNNING;

        foreach (BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));
            if (node.status == Status.SUCCESS)
            {
                status = Status.SUCCESS;
                break;
            }
            
        }

        if (status == Status.RUNNING)
        {
            status = Status.FAILURE;
        }
    }
}