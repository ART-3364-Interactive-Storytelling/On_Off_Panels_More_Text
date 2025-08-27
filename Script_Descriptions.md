# On_Off_Panels_More_Text
## Script Explanations (Detailed)

This document explains the code for four Unity C# scripts, line by line, for students new to Unity and C#. It covers the purpose of each line, including the internals of all functions.

---

## Required Libraries for a 2D Unity Game

```csharp
using UnityEngine;         // Core Unity engine features (required for all Unity scripts)
using UnityEngine.UI;      // For UI elements like buttons and images
using TMPro;               // For TextMeshPro UI text
using System.Collections;  // For using coroutines (timed actions)
```

---

## 1. StoryManager.cs

| Lines      | Code/Section                                      | Explanation                                                                                   |
|------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------|
| 1-2        | using UnityEngine; using TMPro;                    | Import Unity and TextMeshPro libraries.                                                       |
| 4          | public class StoryManager : MonoBehaviour          | Define a new class that can be attached to GameObjects.                                       |
| 5          | private GameObject portal;                         | Declare a variable to store a reference to the Portal object.                                 |
| 6          | public TMP_Text storyText;                         | Reference to the TextMeshPro UI text component.                                               |
| 7          | [TextArea(3, 10)]                                 | Makes the storyPanels array easier to edit in the Inspector.                                  |
| 8          | public string[] storyPanels;                       | Array of story text chunks for each panel.                                                    |
| 9          | private int currentIndex = 0;                      | Tracks which story panel is currently shown.                                                  |
| 11-14      | public Image/Button leftArrow/rightArrow...        | References to UI arrow images and buttons for navigation.                                     |
| 16-19      | void Start() { ... }                               | Unity calls this once at the start. Finds the Portal and shows the first story panel.         |
|            | portal = GameObject.Find("Portal");              | Looks for a GameObject named "Portal" in the scene and stores a reference to it.             |
|            | UpdateStoryText();                                 | Calls the function to update the story text and UI.                                           |
| 21-28      | public void NextPanel() { ... }                    | Moves to the next story panel if not at the end.                                              |
|            | if (currentIndex < storyPanels.Length - 1)         | Checks if we are not already at the last panel.                                               |
|            | currentIndex++;                                    | Increments the index to move to the next panel.                                               |
|            | UpdateStoryText();                                 | Updates the story text and UI to reflect the new panel.                                       |
| 30-37      | public void PreviousPanel() { ... }                | Moves to the previous story panel if not at the start.                                        |
|            | if (currentIndex > 0)                              | Checks if we are not already at the first panel.                                              |
|            | currentIndex--;                                    | Decrements the index to move to the previous panel.                                           |
|            | UpdateStoryText();                                 | Updates the story text and UI to reflect the new panel.                                       |
| 39-48      | void UpdateStoryText() { ... }                     | Updates the story text, arrow visuals, and portal visibility.                                 |
|            | if (storyPanels != null && storyPanels.Length > 0) | Checks if there is at least one story panel.                                                  |
|            | storyText.text = storyPanels[currentIndex];        | Sets the UI text to the current story panel.                                                  |
|            | else storyText.text = "";                         | If there are no panels, clears the text.                                                      |
|            | UpdateArrows();                                    | Updates the appearance and interactability of the navigation arrows.                          |
|            | UpdatePortalVisibility();                          | Shows or hides the Portal object depending on the current panel.                              |
| 50-56      | void UpdatePortalVisibility() { ... }              | Shows the Portal unless on the last panel.                                                    |
|            | if (portal != null)                                | Checks if the Portal object was found.                                                        |
|            | portal.SetActive(currentIndex != storyPanels.Length - 1); | Sets the Portal active unless we're on the last panel.                                 |
| 58-74      | void UpdateArrows() { ... }                        | Dims and disables the left arrow on the first panel and the right arrow on the last panel.    |
|            | if (leftArrow != null)                             | Checks if the left arrow image is assigned.                                                   |
|            | var color = leftArrow.color;                       | Gets the current color of the left arrow.                                                     |
|            | bool isFirst = (currentIndex == 0);                | Checks if we are on the first panel.                                                          |
|            | color.a = isFirst ? 100f/255f : 1f;                | Sets the alpha (opacity) to dim if on the first panel.                                        |
|            | leftArrow.color = color;                           | Applies the new color to the left arrow.                                                      |
|            | if (leftButton != null) leftButton.interactable = !isFirst; | Disables the left button if on the first panel.                                   |
|            | ...same for rightArrow and rightButton...          | Repeats the logic for the right arrow/button on the last panel.                               |

---

## 2. CatFader.cs

| Lines      | Code/Section                                      | Explanation                                                                                   |
|------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------|
| 1-3        | using UnityEngine; using UnityEngine.UI; ...       | Import Unity, UI, and coroutine libraries.                                                    |
| 5          | public class CatFader : MonoBehaviour              | Define a new script for fading a cat image in/out.                                            |
| 6          | public Image catImage;                             | Reference to the cat's UI Image.                                                              |
| 8-15       | void Start() { ... }                               | On start, set the cat invisible and begin the fade loop.                                      |
|            | if (catImage != null)                              | Checks if the cat image is assigned.                                                          |
|            | var color = catImage.color;                        | Gets the current color of the cat image.                                                      |
|            | color.a = 0f;                                      | Sets the alpha to 0 (fully transparent/invisible).                                            |
|            | catImage.color = color;                            | Applies the new color to the cat image.                                                       |
|            | StartCoroutine(FadeCat());                         | Starts the coroutine that handles fading in/out.                                              |
| 17-28      | IEnumerator FadeCat() { ... }                      | Coroutine: Fades in, holds, fades out, waits, and repeats forever.                            |
|            | while (true)                                       | Infinite loop to repeat the fade cycle.                                                       |
|            | yield return StartCoroutine(FadeTo(1f, 5f));       | Fades in to full opacity over 5 seconds.                                                      |
|            | yield return new WaitForSeconds(5f);               | Stays fully visible for 5 seconds.                                                            |
|            | yield return StartCoroutine(FadeTo(0f, 5f));       | Fades out to invisible over 5 seconds.                                                        |
|            | yield return new WaitForSeconds(1f);               | Stays invisible for 1 second before repeating.                                                |
| 30-44      | IEnumerator FadeTo(float, float) { ... }           | Coroutine: Smoothly changes the cat's alpha (opacity) over a set duration.                    |
|            | float startAlpha = catImage.color.a;               | Stores the starting alpha value.                                                              |
|            | float time = 0f;                                   | Timer for the fade.                                                                           |
|            | while (time < duration)                            | Loop until the fade duration is reached.                                                      |
|            | float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration); | Calculates the new alpha value based on time.                                 |
|            | var color = catImage.color; color.a = alpha; catImage.color = color; | Applies the new alpha to the image.                                             |
|            | time += Time.deltaTime;                            | Increments the timer by the time since the last frame.                                        |
|            | yield return null;                                 | Waits for the next frame.                                                                     |
|            | var finalColor = catImage.color; finalColor.a = targetAlpha; catImage.color = finalColor; | Ensures the final alpha is set exactly.         |

---

## 3. Visibility.cs

| Lines      | Code/Section                                      | Explanation                                                                                   |
|------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------|
| 1-2        | using UnityEngine; using UnityEngine.UI;           | Import Unity and UI libraries.                                                                |
| 4          | public class UIImageToggle : MonoBehaviour         | Script to toggle a UI Image's visibility.                                                     |
| 5          | public Image uiImage;                              | Reference to the UI Image to show/hide.                                                       |
| 7-12       | public void ToggleImageVisibility() { ... }        | Enables/disables the image when called (e.g., by a button).                                   |
|            | if (uiImage != null)                              | Checks if the image is assigned.                                                              |
|            | uiImage.enabled = !uiImage.enabled;               | Toggles the image's visibility.                                                               |

---

## 4. SceneManager.cs

| Lines      | Code/Section                                      | Explanation                                                                                   |
|------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------|
| 1          | using UnityEngine;                                 | Import Unity library.                                                                         |
| 3          | public class SceneManager : MonoBehaviour          | Empty script template for scene management.                                                   |
| 5-8        | void Start() { }                                  | Called once at the start (currently empty).                                                   |
| 10-13      | void Update() { }                                 | Called every frame (currently empty).                                                         |

---

**Tip:** In Unity, all scripts that inherit from `MonoBehaviour` can be attached to GameObjects in your scene. Public fields show up in the Inspector, so you can assign references (like UI elements) without changing code.
