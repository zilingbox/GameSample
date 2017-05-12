using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour {

    public GameObject cube;
	// Use this for initialization
	void Start () {

        //键值对儿的形式保存iTween所用到的参数  
        Hashtable args = new Hashtable();

        //这里是设置类型，iTween的类型又很多种，在源码中的枚举EaseType中  
        //例如移动的特效，先震动在移动、先后退在移动、先加速在变速、等等  
        args.Add("easeType", iTween.EaseType.easeInOutExpo);
        args.Add("movetopath", true);

        args.Add("path", iTweenPath.GetPath("Path01"));

        //最终让改对象开始移动  
        iTween.MoveTo(cube, args);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
