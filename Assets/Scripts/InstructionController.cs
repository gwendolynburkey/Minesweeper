using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//////////////////////////////////////////////
//Assignment/Lab/Project: Minesweeper
//Name: Gwen Burkey
//Section: 2019SP.SGD.213.XXXX
//Instructor: Brian Sowers
//Date: 01/22/2019
/////////////////////////////////////////////

public class InstructionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainSceneBurkey");
    }
}
