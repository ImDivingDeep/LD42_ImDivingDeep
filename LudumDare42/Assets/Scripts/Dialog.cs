using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Dialog", order = 1)]
public class Dialog : ScriptableObject {

    [TextArea]
    public string[] lines;
}
