using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System;
using TMPro;

[RequireComponent(typeof(DialogueAnimationHandler))]
public class InkDialougeSystem : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;
	DialogueAnimationHandler dialogueAnimation;

	[SerializeField] private Player player;

	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	private Canvas canvasText = null;
	[SerializeField]
	private Canvas canvasButtom = null;

	//UI Prefabs
	[SerializeField]
	private TextMeshProUGUI textPrefab = null;
	[SerializeField]
	private TextMeshProUGUI speakerPosition = null;
	[SerializeField]
	private Button buttonPrefab = null;
	[SerializeField]
	private Button continueButtom = null;



	//CharacterUI
	string speaker = null;
	string dialogue = null;

	void Awake()
	{
		dialogueAnimation = GetComponent<DialogueAnimationHandler>();
		RemoveChildren();
	}

	public void StartStory()
	{
		continueButtom.gameObject.SetActive(true);
		story = new Story(inkJSONAsset.text);

		try
		{
			story.EvaluateFunction("changePlayerName", player.CharacterName);
		}
		catch
        {
			Debug.Log("ChangePlayerName Method does not exist in JSON");
        }

		if (OnCreateStory != null) OnCreateStory(story);
		dialogueAnimation.DialogueStart();
		RefreshView();
	}

	void TagInputs(string tag)
	{
		switch (tag.Substring(0, tag.IndexOf(".")))
		{
			case "Animation":
				var animation = tag.Substring("Animation.".Length, tag.Length - "Animation.".Length);
				AnimationHandling(animation);
				break;
			case "Idle":
				var idle = tag.Substring("Idle.".Length, tag.Length - "Idle.".Length);
				IdleHandling(idle);
				break;
		}
	}

	void IdleHandling(string s)
	{
		var character = s.Substring(0, s.IndexOf(".") + 1);
		var idle = s.Substring(character.Length, s.Length - character.Length);
		var rawImage = idle.Substring(idle.IndexOf(".") + 1);
		idle = idle.Substring(0, idle.IndexOf("."));

		Texture[] textures = Resources.LoadAll<Texture>("Textures/CharacterTextures/" + character.Substring(0, character.Length - 1) + "Textures");

		foreach (Texture texture in textures)
		{
			if (texture.name.Contains(idle))
			{
				switch (rawImage)
				{
					case "One":
						dialogueAnimation.image1.texture = texture;
						break;
					case "Two":
						dialogueAnimation.image2.texture = texture;
						break;
					case "Three":
						dialogueAnimation.image3.texture = texture;
						break;
					case "Four":
						dialogueAnimation.image4.texture = texture;
						break;
				}
			}
		}
	}

	void AnimationHandling(string s)
	{

		if (s.EndsWith(".IN"))
		{
			var animation = s.Substring(0, s.IndexOf(".IN"));

			switch (animation)
			{
				case "One":
					dialogueAnimation.Animate(1, true);
					break;
				case "Two":
					dialogueAnimation.Animate(2, true);
					break;
				case "Three":
					dialogueAnimation.Animate(3, true);
					break;
				case "Four":
					dialogueAnimation.Animate(4, true);
					break;
			}

		}
		else if (s.EndsWith(".OUT"))
		{
			var animation = s.Substring(0, s.IndexOf(".OUT"));

			switch (animation)
			{
				case "One":
					dialogueAnimation.Animate(1, false);
					break;
				case "Two":
					dialogueAnimation.Animate(2, false);
					break;
				case "Three":
					dialogueAnimation.Animate(3, false);
					break;
				case "Four":
					dialogueAnimation.Animate(4, false);
					break;
			}
		}
	}

	string ConfigurateText(string text)
	{
		if (text.StartsWith("["))
		{
			speaker = text.Substring(1, text.IndexOf("]") - 1);
			speakerPosition.text = speaker;
			dialogue = text.Substring(speaker.Length + 2);
			return dialogue;
		}
		else
		{
			return text;
		}
	}

	public void RefreshView()
	{
		if (story.canContinue)
		{
			RemoveChildren();
			string text = story.Continue();
			text = text.Trim();
			CreateContentView(ConfigurateText(text));

			foreach (var tag in story.currentTags)
			{
				TagInputs(tag);
			}

			//Display all choices
			if (story.currentChoices.Count > 0)
			{
				for (int i = 0; i < story.currentChoices.Count; i++)
				{
					Choice choice = story.currentChoices[i];
					Button button = CreateChoiceView(choice.text.Trim());
					button.onClick.AddListener(delegate
					{
						OnClickChoiceButton(choice);
					});
				}
			}
		}
		else if (canvasButtom.GetComponentsInChildren<Button>().Length <= 0)
		{
			dialogueAnimation.DialogueFinished();
			continueButtom.gameObject.SetActive(false);
		}
	}

	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

	void CreateContentView(string text)
	{
		TextMeshProUGUI storyText = (TextMeshProUGUI)Instantiate(textPrefab);
		storyText.text = text;
		storyText.transform.SetParent(canvasText.transform, false);
	}

	Button CreateChoiceView(string text)
	{
		Button choice = (Button)Instantiate(buttonPrefab);
		choice.transform.SetParent(canvasButtom.transform, false);

		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text = text;

		HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	void RemoveChildren()
	{
		int childCount = canvasText.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(canvasText.transform.GetChild(i).gameObject);
		}

		childCount = canvasButtom.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(canvasButtom.transform.GetChild(i).gameObject);
		}
	}
}