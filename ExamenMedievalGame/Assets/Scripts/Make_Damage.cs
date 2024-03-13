using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Damage : MonoBehaviour
{
    public int cantidad = 100;
    public Vector3 respawnPosition = new Vector3(65.324f, 1.035f, 61.445f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPosition;
            other.GetComponent<Health_Damage>().restarVida(cantidad);
        }
    }
}