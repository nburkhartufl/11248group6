using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuComponent : MonoBehaviour
{

    [SerializeField]//Scenes
    private GameObject powerBank, techTree, shop, options, scenes, blank;

    [SerializeField]//Images
    private Sprite selectedBtn;
    [SerializeField]//Buttons
    private Button powerBankBtn;

    void Start()
    {
        InitializeScenes();
    }

    private void InitializeScenes()
    {
        for (int i = 0; i < scenes.transform.childCount; i++)
        {
            scenes.transform.GetChild(i).gameObject.SetActive(false);
        }
        powerBank.SetActive(true);
        powerBankBtn.Select();
        blank.SetActive(false);
    }

    public GameObject GetActive()
    {
        GameObject activeScene = null;

        for(int i = 0; i < scenes.transform.childCount; i++)
        {
            if (scenes.transform.GetChild(i).gameObject.activeSelf && scenes.transform.GetChild(i).gameObject != blank)
            {
                activeScene = scenes.transform.GetChild(i).gameObject;
            }
        }

        return activeScene;
    }

    public void PowerBank()
    {
        GetActive().SetActive(false);
        powerBank.SetActive(true);
        blank.SetActive(false);
    }

    /*public void Storage()
    {
        while (GetActive() != null)
        {
            GetActive().SetActive(false);
        }
        storage.SetActive(true);
    }*/

    public void TechTree()
    {
        while (GetActive() != null)
        {
            GetActive().SetActive(false);
        }
        techTree.SetActive(true);

    }

    public void Shop()
    {
        if(GetActive()==powerBank){
            blank.SetActive(true);
        }else{
            GetActive().SetActive(false);
            powerBank.SetActive(true);
            blank.SetActive(true);
        }
        shop.SetActive(true);
    }

    public void Options()
    {
        while (GetActive() != null)
        {
            GetActive().SetActive(false);
        }
        powerBank.SetActive(true);
        blank.SetActive(true);
        options.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
