using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonUpgrade
{
    public string firstName = "";
    public string lastName = "";
    //PersonUpgrade is a class,the spouse is a new object that have the PersonUpgarde attributes
    public PersonUpgrade spouse;

    public PersonUpgrade()
    {

    }

     public PersonUpgrade(string pFirstName,string pLastName)
    {
        this.firstName = pFirstName;
        this.lastName = pLastName;
    }

    //this method take a PersonUpgrade parameter and return a value
    public bool IsMarriedWith(PersonUpgrade otherPerson)
    {
        if(spouse != null)
        {
            //PersonUpgrade object is stored in spouse variable
            if(otherPerson == this.spouse)
            {
                //otherPerson object is the same stored spouse
                return true;
            }else
            {
                //not married
                return false;
            }
        }else
        {
            //spouse variable is not assigned so this
            //PersonUpgrade is not married at all
            return false;
        }
    }

}
