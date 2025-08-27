using UnityEngine;
using UnityEngine.UI;

public class UIImageToggle : MonoBehaviour
{
    public Image uiImage; // Assign your UI Image in the Inspector

    public void ToggleImageVisibility()
    {
        if (uiImage != null)
            uiImage.enabled = !uiImage.enabled; // Toggle visibility
    }
}