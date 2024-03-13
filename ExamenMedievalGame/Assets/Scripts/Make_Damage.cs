using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Damage : MonoBehaviour
{
    public int cantidad = 100;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Health_Damage>().restarVida(cantidad);
        }
    }
}
