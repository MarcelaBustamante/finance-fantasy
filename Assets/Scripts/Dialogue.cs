using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    // Este script mantiene toda la informacion relacionada a un simple dialogo
    public string name;

    [TextArea(3, 30)]
    public string[] sentences;

}
