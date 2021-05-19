using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu_Navigation_Actions : MonoBehaviour
{
    protected int currentIndex = 0;
    private GameObject[] menuItems;

    //menu Navigation speed variables
    private const float FirstTimeTreshold = 0.8f;
    private const float SecondTimeTreshold = 0.3f;
    private float counter = 0f;

    private bool activeFunction = false;
    private bool CanMove = true;
    private bool finishedFirstCicle = false;

    public void UpAction()
    {
        activeFunction = true;
        if (CanMove)
        {
            LeaveElement(menuItems[currentIndex]);
            if (--currentIndex < 0)
            {
                currentIndex = menuItems.Length - 1;
            }
            HighlightElement(menuItems[currentIndex]);
        }
    }

    public void DownAction()
    {
        activeFunction = true;
        if (CanMove)
        {
            LeaveElement(menuItems[currentIndex]);
            if (!(++currentIndex < menuItems.Length))
            {
                currentIndex = 0;
            }
            HighlightElement(menuItems[currentIndex]);
        }
    }

    public void Update()
    {
        if (activeFunction)
        {
            counter = counter + Time.deltaTime;
            if (counter < FirstTimeTreshold && !finishedFirstCicle)
            {
                CanMove = false;
            }
            else if (counter < SecondTimeTreshold && finishedFirstCicle)
            {
                CanMove = false;
            }
            else
            {
                counter = 0f;
                CanMove = true;
                finishedFirstCicle = true;
            }
            activeFunction = false;
        }


        else
        {
            CanMove = true;
            counter = 0f;
            finishedFirstCicle = false;
        }
    }

    protected void SetMenuItems(GameObject[] items)
    {
        menuItems = items;
    }

    public int GetCurrentIndex() { return currentIndex; }

    public void ResetIndex() { currentIndex = 0; }

    public abstract void Select();

    public abstract void Cancel();

    public abstract void HighlightElement(GameObject toHighlight);

    public abstract void LeaveElement(GameObject toLeave);
}
