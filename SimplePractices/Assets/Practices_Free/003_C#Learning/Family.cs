using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour {

    public Person father;
    public Person mother;
    public Person son;
	// Use this for initialization
	void Start () {

        father = new Person();
        father.firstName = "Greg";
        father.lastName = "Lu";
        father.age = 30;
        father.isMale = true;
        father.isMarried = true;

        mother = new Person();
        mother.firstName = "Kate";
        mother.lastName = "Miao";
        mother.age = 21;
        mother.isMale = false;
        mother.isMarried = true;

        son = new Person();
        son.firstName = "Adam";
        son.lastName = "Lu";
        son.age = 1;
        son.isMale = false;
        son.isMarried = true;


        Debug.Log(father.firstName + "and " + mother.firstName + " have a son " + son.firstName);
    }
	
}
