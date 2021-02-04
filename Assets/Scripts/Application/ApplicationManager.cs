using System;
using UnityEngine;
using UnityEngine.SceneManagement;

 
    public static class ApplicationManager
    {
        static ApplicationManager()
        {
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public static void OpenMainMenu()
        {

        
        SceneManager.LoadSceneAsync(ScenesConfig.MeinMenuScene, LoadSceneMode.Additive);
        Time.timeScale = 0f;
    }

    public static void StartGame()
    {

        SceneManager.UnloadSceneAsync(ScenesConfig.MeinMenuScene);
        SceneManager.LoadSceneAsync(ScenesConfig.FirstGameLevel, LoadSceneMode.Additive);
        Time.timeScale = 1f;

    }



        public static void QuitGame()
        {
            Application.Quit();
        Debug.Log("quit game");
        }
    }
 