using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//////////////////////////////////////////////
//Assignment/Lab/Project: Minesweeper
//Name: Gwen Burkey
//Section: 2019SP.SGD.213.XXXX
//Instructor: Brian Sowers
//Date: 01/22/2019
/////////////////////////////////////////////
public class MineTile : MonoBehaviour {
    [SerializeField] int xCoordinates;
    [SerializeField] int yCoordinates;
    List<Sprite> _spriteList;
    public int _currentSprite = 0;
    
	// Use this for initialization
	void Start () {
        _spriteList = GameObject.FindGameObjectWithTag("spriteHolder").GetComponent<SpriteHolder>().getTileSprites();

	}

    public int getXCoordinate()
    {
        return xCoordinates;
    }

    public int getYCoordinate()
    {
        return yCoordinates;
    }

    public bool returnTrueIfCoordinatesAreCorrect(int x, int y)
    {
        if (x == xCoordinates && y == yCoordinates)
        {
            return true;
        }
        else
            return false;
    }

    public void changeSprite(int spriteIndex)
    {
        this.GetComponent<Image>().sprite = _spriteList[spriteIndex];
        _currentSprite = spriteIndex;
    }

    public int GetCurrentSprite()
    {
        return _currentSprite;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
