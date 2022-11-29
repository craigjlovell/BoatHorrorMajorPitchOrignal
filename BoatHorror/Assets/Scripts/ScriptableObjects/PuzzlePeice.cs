using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Puzzle Piece Data", menuName = "Puzzle")]
public class PuzzlePeice : ScriptableObjectController
{    
    public void Awake()
    {
        type = types.puzzle;
    }
}
