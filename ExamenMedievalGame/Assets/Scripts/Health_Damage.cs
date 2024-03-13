using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health_Damage : MonoBehaviour
{

    public int hp = 100;
    public bool invincible = false;
    public float tiempo_invencible = 1f;
    public float tiempo_frenado = 0.2f;
    public TextMeshProUGUI textvidas;
    public Image imagenGameOver;
    public Image Life1;
    public Image Life3;
    public Image Life2;
    public int vidas = 3;

    private void Start()
    {
        if (imagenGameOver != null)
        {
            imagenGameOver.gameObject.SetActive(false);
        }
    }

    public void restarVida(int cantidad)
    {
        if (hp > 0)
        {
            hp -= cantidad;
        }

        if (hp == 0)
        {
            vidas--;

            if (vidas == 2)
            {
                EliminarVida3();
            }
            else if (vidas == 1)
            {
                EliminarVida2();
            }
            else if (vidas == 0)
            {
                EliminarVida1();
                MostrarImagenGameOver();
            }
        }
    }

    void MostrarImagenGameOver()
    {
        if (imagenGameOver != null)
        {
            imagenGameOver.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("La referencia de Image no está asignada en el Inspector.");
        }
    }
    void EliminarVida2()
    {
        if (Life2 != null)
        {
            Life2.gameObject.SetActive(false);

            PickUpObject pickUpScript = GetComponent<PickUpObject>();
            pickUpScript.ReiniciarPosicion(new Vector3(65.324f, 1.035f, 61.445f));
            Debug.Log("ReiniciarPosicion llamado");
        }
        else
        {
            Debug.LogError("La referencia de Image no está asignada en el Inspector.");
        }
    }
    void EliminarVida3()
    {
        if (Life3 != null)
        {
            Life3.gameObject.SetActive(false);

            PickUpObject pickUpScript = GetComponent<PickUpObject>();
            pickUpScript.ReiniciarPosicion(new Vector3(65.324f, 1.035f, 61.445f));
            Debug.Log("ReiniciarPosicion llamado");
        }
        else
        {
            Debug.LogError("La referencia de Image no está asignada en el Inspector.");
        }
    }

    void EliminarVida1()
    {
        if (Life1 != null)
        {
            Life1.gameObject.SetActive(false);

            PickUpObject pickUpScript = GetComponent<PickUpObject>();
            pickUpScript.ReiniciarPosicion(new Vector3(65.324f, 1.035f, 61.445f));
            Debug.Log("ReiniciarPosicion llamado");
        }
        else
        {
            Debug.LogError("La referencia de Image no está asignada en el Inspector.");
        }
    }
    private void Update()
    {
        if (imagenGameOver.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                reiniciarJuego();
            }
        }
    }

    private void reiniciarJuego()
    {
        Debug.Log("Se activó el método");
        imagenGameOver.gameObject.SetActive(false);
        vidas = 3;
        Life1.gameObject.SetActive(true);
        Life2.gameObject.SetActive(true);
        Life3.gameObject.SetActive(true);

        PickUpObject pickUpScript = GetComponent<PickUpObject>();

        // Llama primero a ReactivarObjetosDesactivados
        pickUpScript.ReactivarObjetosDesactivados();
        Debug.Log("ReactivarObjetosDesactivados llamado");

        // Luego, llama a ReiniciarPosicion
        pickUpScript.ReiniciarPosicion(new Vector3(65.324f, 1.035f, 61.445f));
        Debug.Log("ReiniciarPosicion llamado");
    }
}