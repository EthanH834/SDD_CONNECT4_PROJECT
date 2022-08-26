using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipInputFields : MonoBehaviour
{
    public int columnCheck;
    public gameManager gm;

    void OnMouseDown()
    {
        gm.selectColumn(columnCheck);
    }
}
