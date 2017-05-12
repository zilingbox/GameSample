using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//StartCoroutine("MyCoroutine");//string based
        //StartCoroutine(MyCoroutine());//IEnumerator based

        //now if we want to call MySecondCoroutine

        //StartCoroutine(MySecondCoroutine(0.5f);//we cannot use string based to call MySecondCoroutine


       
	}
	IEnumerator MyTestCoroutine()
    {
        Debug.Log("Hello world!");
        yield return null;
    }
	
    IEnumerator MySecondCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);//yield must be used before
        Debug.Log("Hello word");
    }

    // void StopMyCoroutine()
    //{
    //    StopCoroutine("MyCoroutine");
    //}
}
