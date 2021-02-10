using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Esto es para cambiar a la scena que queramos con su nombre
    public void ChangeSceneTo(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    //Esto es para ir a la siguiente escena de la cronologia
    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
