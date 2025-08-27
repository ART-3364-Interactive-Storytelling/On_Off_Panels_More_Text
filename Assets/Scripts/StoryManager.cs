using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    private GameObject portal;
    public TMP_Text storyText; // Assign your TextMeshPro UI component in the Inspector
    [TextArea(3, 10)]
    public string[] storyPanels; // Fill this array with your story chunks in the Inspector
    private int currentIndex = 0;

    public UnityEngine.UI.Image leftArrow;  // Assign in Inspector
    public UnityEngine.UI.Image rightArrow; // Assign in Inspector
    public UnityEngine.UI.Button leftButton;  // Assign in Inspector (button containing leftArrow)
    public UnityEngine.UI.Button rightButton; // Assign in Inspector (button containing rightArrow)

    void Start()
    {
        portal = GameObject.Find("Portal"); // Cache reference at start
        UpdateStoryText();
    }

    public void NextPanel()
    {
        if (currentIndex < storyPanels.Length - 1)
        {
            currentIndex++;
            UpdateStoryText();
        }
    }

    public void PreviousPanel()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateStoryText();
        }
    }

    void UpdateStoryText()
    {
        if (storyPanels != null && storyPanels.Length > 0)
            storyText.text = storyPanels[currentIndex];
        else
            storyText.text = "";
        UpdateArrows();
        UpdatePortalVisibility();
    }

    void UpdatePortalVisibility()
    {
        if (portal != null)
        {
            // Portal is active on all panels except the last
            portal.SetActive(currentIndex != storyPanels.Length - 1);
        }
    }

    void UpdateArrows()
    {
        if (leftArrow != null)
        {
            var color = leftArrow.color;
            bool isFirst = (currentIndex == 0);
            color.a = isFirst ? 100f/255f : 1f;
            leftArrow.color = color;
            if (leftButton != null)
                leftButton.interactable = !isFirst;
        }
        if (rightArrow != null)
        {
            var color = rightArrow.color;
            bool isLast = (currentIndex == storyPanels.Length - 1);
            color.a = isLast ? 100f/255f : 1f;
            rightArrow.color = color;
            if (rightButton != null)
                rightButton.interactable = !isLast;
        }
    }
}