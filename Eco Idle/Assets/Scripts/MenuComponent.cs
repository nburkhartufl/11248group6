using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuComponent : MonoBehaviour
{

    [SerializeField]//Scenes
    private GameObject powerBank, storage, techTree, shop, options, scenes;

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
    }

    public GameObject GetActive()
    {
        GameObject activeScene = null;

        for(int i = 0; i < scenes.transform.childCount; i++)
        {
            if (scenes.transform.GetChild(i).gameObject.activeSelf)
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
    }

    public void Storage()
    {
        GetActive().SetActive(false);
        storage.SetActive(true);
    }

    public void TechTree()
    {
        GetActive().SetActive(false);
        techTree.SetActive(true);
    }

    public void Shop()
    {
        GetActive().SetActive(false);
        shop.SetActive(true);
    }

    public void Options()
    {
        GetActive().SetActive(false);
        options.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
