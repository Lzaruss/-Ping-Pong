using UnityEngine;

public class Porteria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Bola")
        {
            if (this.name == "Izquierda")
            {
                col.GetComponent<Bola>().reiniciarBola("Derecha");
            } else if (this.name == "Derecha")
            {
                col.GetComponent<Bola>().reiniciarBola("Izquierda");
            }
        }
    }
}