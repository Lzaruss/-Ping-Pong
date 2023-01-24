using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Raqueta : MonoBehaviour
{

    //Velocidad
    [SerializeField] private float velocidad= 30.0f;
    //Eje vertical
    [SerializeField] private string ejey, ejex;
    
    [SerializeField] private float xMin, xMax;

    void FixedUpdate (){
          //Capto el valor del eje vertical de la raqueta
          float h = Input.GetAxisRaw(ejex);
          float v = Input.GetAxisRaw(ejey);
          Vector2 direccion = new Vector2(h, v);
          GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

          transform.position = new Vector3(
              Mathf.Clamp (transform.position.x, xMin, xMax), 
              transform.position.y,
              transform.position.z
          );   
    }
}