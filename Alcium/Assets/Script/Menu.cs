using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public void Jouer()
    {
        SceneManager.LoadScene("Scène1"); // Mettre la première scène au démarrage du jeu
    }
    public void Quitter()
    {
        Application.Quit(); // Quitter l'app
    }
    public void Settings()
    {
        SceneManager.LoadScene("Reglage");
    }
} 
