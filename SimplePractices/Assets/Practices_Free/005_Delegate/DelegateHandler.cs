using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler: MonoBehaviour {

    public delegate void OnButtonClickDelegate();
    public  static event OnButtonClickDelegate buttonClickDelegate;

    public void OnButtonClickBBB()
    {
        if (buttonClickDelegate != null)
        {
            buttonClickDelegate();
        }
        Debug.Log("click");
    }
}
