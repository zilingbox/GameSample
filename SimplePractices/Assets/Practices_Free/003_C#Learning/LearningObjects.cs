using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningObjects : MonoBehaviour {

    public PersonUpgrade man;
    public PersonUpgrade woman;

	// Use this for initialization
	void Start () {

        //man = new PersonUpgrade();
        //man.firstName = "Greg";
        //man.lastName = "Lu";
        man = new PersonUpgrade("Greg", "Lu" );
        woman = new PersonUpgrade("Kate", "Lu");

        //woman = new PersonUpgrade();
        //woman.firstName = "Kate";
        //woman.lastName = "Lu";
  
        man.spouse = woman;
        woman.spouse = man;

        if(man.IsMarriedWith(woman))
        {
            Debug.Log(man.firstName + "is married to " + woman.firstName);
        }else
        {
            Debug.Log(man.firstName + " and" + woman.firstName + "are not married");
        }
        
	}
	

}
