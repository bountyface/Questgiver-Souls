using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        print("StartGame");
        SceneManager.LoadScene("Game");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // This function will be called when the GameObject is clicked
        Debug.Log("Clicked!");
        StartGame();

        // Add your custom code here for what should happen on the click event
    }
    public void OnFire()
    {
        StartGame();
    }
}
