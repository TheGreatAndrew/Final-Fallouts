using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;

    // add all tab to tabButtons
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null){
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    // hover 
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab){
            button.background.sprite = tabHover;
        }
    }
    // not touch 
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    // select 
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index){
                objectsToSwap[i].SetActive(true);
            }
            else {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    // tabs that are not chosen
    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab ){continue;}
            button.background.sprite = tabIdle;
        }
    }

}
