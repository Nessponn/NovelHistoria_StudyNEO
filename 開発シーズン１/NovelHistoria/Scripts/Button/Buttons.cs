using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int Number;

    public void SelectBranch()
    {
        ChoiceButtons.Instance.Send_Branch(Number);
    }
}
