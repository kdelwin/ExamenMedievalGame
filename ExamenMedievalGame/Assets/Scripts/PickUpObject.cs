using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public int RedGems = 0;
    public int GreenGems = 0;
    public int BlueGems = 0;
    public TextMeshProUGUI RedGemsValue;
    public TextMeshProUGUI GreenGemsValue;
    public TextMeshProUGUI BlueGemsValue;
    public Image MissionImage;

    private List<GameObject> deactivatedObjects = new List<GameObject>();

    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                if (PickedObject != null)
                {
                    if (PickedObject.CompareTag("RedGem"))
                    {
                        RedGems++;
                        MissionTextRedGems();
                    }
                    else if (PickedObject.CompareTag("GreenGem"))
                    {
                        GreenGems++;
                        MissionTextGreenGems();
                    }
                    else if (PickedObject.CompareTag("BlueGem"))
                    {
                        BlueGems++;
                        MissionTextBlueGems();
                    }
                    deactivatedObjects.Add(PickedObject);

                    PickedObject.SetActive(false);
                    ObjectToPickUp = null;
                    PickedObject = null;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MissionImageShowDisapear();
        }
    }

    public void MissionTextRedGems()
    {
        RedGemsValue.text = "(" + RedGems.ToString() + "/3)";
    }

    public void MissionTextGreenGems()
    {
        GreenGemsValue.text = "(" + GreenGems.ToString() + "/3)";
    }

    public void MissionTextBlueGems()
    {
        BlueGemsValue.text = "(" + BlueGems.ToString() + "/3)";
    }

    public void MissionImageShowDisapear()
    {
        if (MissionImage != null)
        {
            MissionImage.gameObject.SetActive(!MissionImage.gameObject.activeSelf);
        }
    }
    public void ReactivarObjetosDesactivados()
    {
        foreach (var obj in deactivatedObjects)
        {
            obj.SetActive(true);
        }
        deactivatedObjects.Clear();
        RedGems = 0;
        GreenGems = 0;
        BlueGems = 0;
        MissionTextRedGems();
        MissionTextGreenGems();
        MissionTextBlueGems();
    }
    public void ReiniciarPosicion(Vector3 nuevaPosicion)
    {
        Debug.Log("ReiniciarPosicion llamado");
        transform.position = nuevaPosicion;

        // Agrega un mensaje de depuración para verificar la posición después de la asignación
        Debug.Log("Nueva posición: " + transform.position);
    }

}