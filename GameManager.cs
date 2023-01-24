using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  void Update () {
    //Si pulsa la tecla I vuelve al inicio
    if (Input.GetKeyDown(KeyCode.Z)){
      //Cargo la escena de Inicio
      SceneManager.LoadScene("Inicio");
    }
    if (Input.GetKeyDown(KeyCode.P)){
      //Cargo la escena de Inicio
      SceneManager.LoadScene("Juego");
    }
    if (Input.GetKeyDown(KeyCode.O)){
      //Cargo la escena de Inicio
      SceneManager.LoadScene("JuegoX2");
    }
  }
  public void onevsone()
  {
    SceneManager.LoadScene("Juego");
  } 
  
  public void twovstwo()
  {
    SceneManager.LoadScene("JuegoX2");
  } 
}