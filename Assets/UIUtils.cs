using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtils : MonoBehaviour
{
    public void killObjectInteraction()
    {
        GetComponent<Button>().interactable = false;
    }
}
