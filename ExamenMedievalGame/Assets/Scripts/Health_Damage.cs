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
        if (!invincible && hp > 0)
        {
            hp -= cantidad;
            StartCoroutine(Invulnerabilidad());
        }
        if(hp == 0)
        {
            transform.position = new Vector3(65.324f, 1.035f, 61.445f);
            vidas--;
            if(vidas == 2)
            {
                EliminarVida3();
            }
            if(vidas == 1)
            {
                EliminarVida2();
            }
        }
        if(vidas == 0)
        {
            transform.position = new Vector3(65.324f, 1.035f, 61.445f);
            EliminarVida1();
            MostrarImagenGameOver();
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
        }
        else
        {
            Debug.LogError("La referencia de Image no está asignada en el Inspector.");
        }
    }


    IEnumerator Invulnerabilidad()
    {
        invincible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invincible = false;
    }

    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<PlayerController>().playerSpeed;
        GetComponent<PlayerController>().playerSpeed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<PlayerController>().playerSpeed = velocidadActual;
    }
}
