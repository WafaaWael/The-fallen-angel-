using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_manager : MonoBehaviour
{
    [SerializeField] private void_event pause_event;
    [SerializeField] private void_event ddeath_event;
    [SerializeField] private GameObject pause_menu;
    [SerializeField] private GameObject ddeath_screen;


    
    private void OnEnable()
    {
        pause_event.RegisterListener(OnPause);
        ddeath_event.RegisterListener(onDeath);
    }

    
    private void onDeath()
    {
        ddeath_screen.SetActive(true);
    }

    private void OnDisable()
    {
        pause_event.UnregisterListener(OnPause);
        ddeath_event.UnregisterListener(onDeath);
    }
    void Start()
    {
        ddeath_screen.SetActive(false);
        
    }

    
    void Update()
    {
        
    }
    private void OnPause()
    {
        if (pause_menu.activeInHierarchy==true)
        {
            pause_menu.SetActive(false);
        }
        else
        {
            pause_menu.SetActive(true);
        }
        
    }

    public void ON_death_yes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ON_death_no()
    {
        EditorApplication.ExitPlaymode();
    }
}
