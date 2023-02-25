using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string WeaponName = string.Empty;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
       
        if(other.gameObject.tag.Equals("Player"))
        {
           
            if(Input.GetKey(KeyCode.E))
            {
                GameObject.Find($"Player/PlayerObject/PlayerCharacterGFX/{WeaponName}").SetActive(true);

                Destroy(gameObject);
            }
            
        }
        
    }
}
