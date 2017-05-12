using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour {

    public List<string> familyMembers = new List<string>();

	// Use this for initialization
	void Start () {

        familyMembers.Add("Greg");
        familyMembers.Add("Kate");
        familyMembers.Add("Adam");

        int adamsIndex = -1;

        for(int i =0; i<familyMembers.Count;i++)
        {
            if(familyMembers[i] == "Adam")
            {
                adamsIndex = i;
                //it will not loop 
                break;
            }
        }

        if (adamsIndex == -1)
        {
            Debug.Log("Adam value is not stored in the list");

        }
        else
        {
            Debug.Log("Adam value found at index " + adamsIndex);
        }
	}
	
}
