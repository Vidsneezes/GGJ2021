using UnityEngine;
using System.Collections;

public class LookAble : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameGlue.LookCursor();
    }

    void OnMouseExit()
    {
        GameGlue.IdleCursor();
    }

}
