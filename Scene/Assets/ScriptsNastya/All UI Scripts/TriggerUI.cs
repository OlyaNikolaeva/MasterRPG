using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    public GameObject TalktUI;
    public GameObject QuestUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { TalktUI.SetActive(true);
            if (other.tag == "Player" & Input.GetKeyDown("B"))
                TalktUI.SetActive(false);
                QuestUI.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TalktUI.SetActive(false);
            QuestUI.SetActive(false);
        }
            


    }
}
