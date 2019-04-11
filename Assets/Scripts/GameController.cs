using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    int[,] _mineValues = new int[5, 5];
    [SerializeField] int numberOfMines = 5;
    [SerializeField] Text cellsLeftText;
    [SerializeField] Text loseText;
    int _counter;
    bool _gameActive = true;
    PointerEventData _pointerEventData;
    GraphicRaycaster _raycaster;
    EventSystem _eventSystem;
    // Use this for initialization
    void Start () {
        GenerateTiles();
        // Fetch the raycaster from the Canvas
        _raycaster = GameObject.FindGameObjectWithTag("canvas").GetComponent<GraphicRaycaster>();
        // Fetch the event system from the Scene
        _eventSystem = GetComponent<EventSystem>();

        GenerateCounter();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForClicks();
        cellsLeftText.text = "Empty Cells Left:" + _counter;
        CheckGameState();
	}

    public void OnClickResetButton()
    {
        GenerateTiles();
        GenerateCounter();
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("tile"))
        {
            tile.GetComponent<MineTile>().changeSprite(0);
        }
        _gameActive = true;
        loseText.text = "";
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    void CheckGameState()
    {
        if (!_gameActive)
        {
            loseText.text = "You Lose!";
        }

        else if (_counter == 0)
        {
            loseText.text = "You Win!";
        }
    }

    int GenerateCounter()
    {
        _counter = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (_mineValues[x,y] < 7)
                {
                    _counter++;
                }
            }
        }
        return _counter;
    }

    void GenerateTiles()
    {
        ResetTiles();
        int randomX;
        int randomY;
        int mines = numberOfMines;
        while (mines > 0)
        {
            randomX = Random.Range(0, 4);
            randomY = Random.Range(0, 4);
            if (_mineValues[randomX, randomY] != 7)
            {
                _mineValues[randomX, randomY] = 7;
                mines--;
            }
        }
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (_mineValues[x, y] !=7)
                    _mineValues[x,y] = FindNearbyBombs(x, y);
            }
        }
    }

    void ResetTiles()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                _mineValues[x, y] = 0;
            }
        }
    }

    int FindNearbyBombs(int x, int y)
    {
        int counter = 1;
        // Checks the left for a bomb
        if (x > 0)
        {
            if (_mineValues[x-1,y] == 7)
            {
                counter++;
            }
        }

        //Checks down for a bomb
        if (y > 0)
        {
            if (_mineValues[x, y - 1] == 7)
            {
                counter++;
            }
        }

        //Checks up for a bomb
        if (y < 4)
        {
            if (_mineValues[x, y + 1] == 7)
            {
                counter++;
            }
        }

        //Checks right for a bomb
        if (x < 4)
        {
            if (_mineValues[x + 1,y] == 7)
            {
                counter++;
            }
        }

        //Checks up-right for a bomb
        if (x < 4 && y < 4)
        {
            if (_mineValues[x + 1, y + 1] == 7)
            {
                counter++;
            }
        }

        //Checks down-right for a bomb
        if (x < 4 && y > 0)
        {
            if (_mineValues[x + 1, y - 1] == 7)
            {
                counter++;
            }
        }

        //Checks down-left for a bomb
        if (x > 0 && y > 0)
        {
            if (_mineValues[x - 1, y - 1] == 7)
            {
                counter++;
            }
        }

        //Checks up-left for a bomb
        if (x > 0 && y < 4)
        {
            if (_mineValues[x - 1, y + 1] == 7)
            {
                counter++;
            }
        }
        return counter;
    }

    void CheckForClicks()
    {
        int xCoord;
        int yCoord;
        if (Input.GetMouseButtonUp(0))
        {
            //Sets up the new pointer event
            _pointerEventData = new PointerEventData(_eventSystem);
            //Set the pointer Event Poisition to that of the mouse position
            _pointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            _raycaster.Raycast(_pointerEventData, results);


            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "tile")
                {
                    if (result.gameObject.GetComponent<MineTile>().GetCurrentSprite() == 0 && _gameActive) 
                    {
                        xCoord = result.gameObject.GetComponent<MineTile>().getXCoordinate();
                        yCoord = result.gameObject.GetComponent<MineTile>().getYCoordinate();
                        result.gameObject.GetComponent<MineTile>().changeSprite(_mineValues[xCoord, yCoord]);
                        if (_mineValues[xCoord, yCoord] == 7)
                        {
                            _gameActive = false;
                        }
                        else
                            _counter--;
                    }
                }
            }
        }
    }
}
