using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    //Velocidad
    [SerializeField] private float velocidad = 30.0f;
    //Contadores de goles
    [SerializeField] private int golesIzquierda = 0;
    [SerializeField] private int golesDerecha = 0;

    //Cajas de texto de los contadores
    [SerializeField] private Text contadorIzquierda;
    [SerializeField] private Text contadorDerecha;
    
    //Audio Source
    AudioSource fuenteDeAudio;
    
    [SerializeField] private Text resultado;
    //Caja de texto para el temporizador
    [SerializeField] private Text temporizador;
    //variable para contabilizar el tiempo inicializada a 180 segundos (3 minutos)
    private float tiempo = 180;

    //Clips de audio
    [SerializeField] private AudioClip audioGol, audioRaqueta, audioRebote;
    
    //Se ejecuta al arrancar
    void Start () {

        //Velocidad inicial hacia la derecha
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        //Recupero el componente audio source;
        fuenteDeAudio = GetComponent<AudioSource>();
        //Desactivo la caja de resultado
        resultado.enabled = false;
        //Quito la pausa
        Time.timeScale = 1;

        
    }
    
    //Se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision){
        
        //Para el sonido del rebote
        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){

            //Reproduzco el sonido del rebote
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
        else if (micolision.gameObject.name == "Raqueta Izquierda" || micolision.gameObject.name == "Raqueta Derecha" || micolision.gameObject.name == "Raqueta Izquierda2" || micolision.gameObject.name == "Raqueta Derecha2"){
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
    }

    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;

        velocidad = 10;

        if (direccion == "Derecha")
        {
            golesDerecha++;
            contadorDerecha.text = golesDerecha.ToString();
            if (!comprobarFinal())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            }
        } else if (direccion == "Izquierda")
        {
            golesIzquierda++;
            contadorIzquierda.text = golesIzquierda.ToString();
            if (!comprobarFinal())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            }
        }
        
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();
    }
    
    //Compruebo si alguno ha llegado a 5 goles
    bool comprobarFinal(){
        if(SceneManager.GetActiveScene().name == "Juego"){
            //Si el de la izquierda ha llegado a 5
            if (golesIzquierda == 5){
                //Escribo y muestro el resultado
                resultado.text = "¡Jugador Izquierda GANA!\nPulsa Z para volver a Inicio\nPulsa P para volver a jugar";
                //Muestro el resultado, pauso el juego y devuelvo true
                resultado.enabled = true;
                Time.timeScale = 0; //Pausa
                return true;
            }
            //Si el de le aderecha a llegado a 5
            else if (golesDerecha == 5){
                //Escribo y muestro el resultado
                resultado.text = "¡Jugador Derecha GANA!\nPulsa Z para volver a Inicio\nPulsa P para volver a jugar";
                //Muestro el resultado, pauso el juego y devuelvo true
                resultado.enabled = true;
                Time.timeScale = 0; //Pausa
                return true;
            }
            //Si ninguno ha llegado a 5, continúa el juego
            else{
                return false;
            }
        }else{
            //Si el de la izquierda ha llegado a 5
            if (golesIzquierda == 5){
                //Escribo y muestro el resultado
                resultado.text = "¡Jugadores del lado Izquierdo GANAN!\nPulsa Z para volver a Inicio\nPulsa O para volver a jugar";
                //Muestro el resultado, pauso el juego y devuelvo true
                resultado.enabled = true;
                Time.timeScale = 0; //Pausa
                return true;
            }
            //Si el de le aderecha a llegado a 5
            else if (golesDerecha == 5){
                //Escribo y muestro el resultado
                resultado.text = "¡Jugadores del lado derecho GANAN!\nPulsa Z para volver a Inicio\nPulsa O para volver a jugar";
                //Muestro el resultado, pauso el juego y devuelvo true
                resultado.enabled = true;
                Time.timeScale = 0; //Pausa
                return true;
            }
            //Si ninguno ha llegado a 5, continúa el juego
            else{
                return false;
            }
        }
    }
    
    string formatearTiempo(float tiempo){

        //Formateo minutos y segundos a dos dígitos
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(tiempo % 60).ToString("00");
    
        //Devuelvo el string formateado con : como separador
        return minutos + ":" + segundos;
  
    }

    void Update()
    {
        //Incremento la velocidad de la bola
        velocidad = velocidad + 2 * Time.deltaTime;

        //Si aún no se ha acabado el tiempo, decremento su valor y lo muestro en la caja de texto
        if (tiempo >= 0)
        {
            tiempo -= Time.deltaTime; //Le resto el tiempo transcurrido en cada frame
            temporizador.text = formatearTiempo(tiempo); //Formateo el tiempo y lo escribo en la caja de texto
        }
        //Si se ha acabado el tiempo, compruebo quién ha ganado y se acaba el juego
        else
        {
            temporizador.text = "00:00"; //Para evitar valores negativos	
            //Compruebo quién ha ganado
            if (golesIzquierda > golesDerecha)
            {
                //Escribo y muestro el resultado
                resultado.text = "¡Jugador Izquierda GANA!\nPulsa Z para volver a Inicio\nPulsa P para volver a jugar";
            }
            else if (golesDerecha > golesIzquierda)
            {
                //Escribo y muestro el resultado
                resultado.text = "¡Jugador Derecha GANA!\nPulsa Z para volver a Inicio\nPulsa P para volver a jugar";
            }
            else
            {
                //Escribo y muestro el resultado
                resultado.text = "¡EMPATE!\nPulsa Z para volver a Inicio\nPulsa P para volver a jugar";
            }

            //Muestro el resultado, pauso el juego y devuelvo true
            resultado.enabled = true;
            Time.timeScale = 0; //Pausa
        }
    }
}