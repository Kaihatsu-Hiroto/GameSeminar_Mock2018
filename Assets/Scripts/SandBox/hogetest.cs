using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hogetest : MonoBehaviour {


    /// <summary>ucall back </summary>
    System.Func<string> hey = () =>{
        return "へい";
    };


	// Update is called once per frame
	void Update () {
        //Debug.Log(hey());
    }
}
