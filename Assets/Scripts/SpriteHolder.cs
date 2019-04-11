using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////////////////////////////////////////////
//Assignment/Lab/Project: Minesweeper
//Name: Gwen Burkey
//Section: 2019SP.SGD.213.XXXX
//Instructor: Brian Sowers
//Date: 01/22/2019
/////////////////////////////////////////////
public class SpriteHolder : MonoBehaviour {
    [SerializeField] public List<Sprite> tileSprites;
    // Use this for initialization
    void Start () {
		
	}

    public List<Sprite> getTileSprites()
    {
        return tileSprites;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
