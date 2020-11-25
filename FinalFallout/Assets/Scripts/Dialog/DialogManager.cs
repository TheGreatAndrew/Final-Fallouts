using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
	[SerializeField] PlayerInfo player;
    
	//Displays
	public TMP_Text nameText;
	public TMP_Text dialogText;

	public Animator animator;

	private Queue<string> dialogSentences;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
		dialogSentences = new Queue<string>();
	}

	public void StartInteraction(Interaction interaction)
    {
		foreach (Dialog dialog in interaction.interactionTexts)
        {
			StartDialog(dialog);
        }
    }

	public void StartDialog(Dialog dialog)
	{
		Debug.Log("In Dialog: " + dialog.name);
		Debug.Log("In Dialog: " + dialog.sentences[0]);

		player.inConversation = true;

		animator.SetBool("IsOpen", true);

		nameText.text = dialog.name;

		dialogSentences.Clear();
		
		foreach (string sentence in dialog.sentences)
		{
			dialogSentences.Enqueue(sentence);
		}

		DisplayNextSentence();
		
	}

	public void DisplayNextSentence()
	{
		Debug.Log("Clicked");
		if (dialogSentences.Count == 0)
		{
			EndDialog();
			return;
		}

		string sentence = dialogSentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogText.text += letter;
			yield return null;
		}
	}

	void EndDialog()
	{
		animator.SetBool("IsOpen", false);
		player.inConversation = false;
	}

}
