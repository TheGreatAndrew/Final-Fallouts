using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Interaction interaction;

	public void TriggerInteraction()
    {
		FindObjectOfType<DialogManager>().StartInteraction(interaction);
    }
}
