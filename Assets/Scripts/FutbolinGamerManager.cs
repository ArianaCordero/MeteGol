using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FutbolinGameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreJ1Text;
    public TMP_Text scoreJ2Text;
    public TMP_Text ganadorText;

    [Header("Configuracion")]
    public int golesParaGanar = 3;

    [Header("Referencias de GameObjects")]
    public GameObject pelota;
    public GameObject jugador1;
    public GameObject jugador2;
    public Transform spawnPelota;
    public Transform spawnJugador1;
    public Transform spawnJugador2;

    public static FutbolinGameManager Instance { get; set; }

    private int scoreJ1 = 0;
    private int scoreJ2 = 0;
    private bool juegoTerminado = false;

    void Start()
    {
        Instance = this;
        ActualizarUI();
        if (ganadorText != null)
            ganadorText.gameObject.SetActive(false);
    }

    public void AnotarGol(int jugador)
    {
        if (juegoTerminado) return;
        if (jugador == 1) scoreJ1++;
        else scoreJ2++;

        ActualizarUI();

        if (scoreJ1 >= golesParaGanar || scoreJ2 >= golesParaGanar)
        {
            juegoTerminado = true;
            MostrarGanador();
        }
        else
        {
            Invoke("ResetPosiciones", 1.5f);
        }
    }

    void ActualizarUI()
    {
        if (scoreJ1Text != null) scoreJ1Text.text = "J1: " + scoreJ1;
        if (scoreJ2Text != null) scoreJ2Text.text = "J2: " + scoreJ2;
    }

    void ResetPosiciones()
    {
        if (pelota != null && spawnPelota != null)
        {
            Rigidbody rb = pelota.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            pelota.transform.position = spawnPelota.position;
        }
        if (jugador1 != null && spawnJugador1 != null)
        {
            jugador1.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            jugador1.transform.position = spawnJugador1.position;
        }
        if (jugador2 != null && spawnJugador2 != null)
        {
            jugador2.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            jugador2.transform.position = spawnJugador2.position;
        }
    }

    void MostrarGanador()
    {
        if (ganadorText != null)
        {
            ganadorText.gameObject.SetActive(true);
            ganadorText.text = (scoreJ1 >= golesParaGanar) ? "JUGADOR 1 GANA!" : "JUGADOR 2 GANA!";
        }
        Invoke("VolverAlMenu", 3f);
    }

    void VolverAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}