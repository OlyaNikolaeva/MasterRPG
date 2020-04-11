using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public GameObject QuestUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" & Input.GetKey(KeyCode.Space))
            QuestUI.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            QuestUI.SetActive(false);


    }
}
