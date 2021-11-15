using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string name2;

    [TextArea(3, 10)]
    public string[] sentences;
}
