# Create the Interactive Storytelling Scene
1. Create a New Unity 2D Project
2. Open Unity Hub and create a new 2D project.
3. Set Up the Scene Hierarchy

## Canvas & UI:

1. Right-click in the Hierarchy > UI > Canvas.
2. Set Canvas “Render Mode” to ```Screen Space - Overlay```.
3. Add a ```UI Panel``` (right-click ```Canvas > UI > Panel```) for your story text background and name it ```Story Panel```
4. Add a ```TextMeshPro - Text (UI)``` object as a child of the ```Text Panel``` for your story text.
5. Add two UI Buttons (right-click ```Canvas > UI > Button```) for navigation arrows (“Back” and “Forward”).
6. Rename them to ```LeftButton``` and ```RightButton```.
7. Set their positions to the left and right of the story panel.
8. Change their images to arrow sprites from the ```Assets -> Sprites``` folder.

## Story Elements (Sprites/UI Images):

Add a UI Image or 2D Sprite for each visual element:

### Fox 
1. Right-click Canvas to create a ```UI > Image``` (or 2D Object > Sprite), name it ```Fox```
2. Click on the Fox in the **Hierarchy** and drag the Fox sprite onto ```Image -> Source Image``` field in the **Inspector**
3. Position the sprite in the scene where you want it.

### Sign
1. Right-click Canvas to create a ```UI > Image``` (or 2D Object > Sprite), name it ```Sign```
2. Click on the Sign in the **Hierarchy** and drag the Sign sprite onto ```Image -> Source Image``` field in the **Inspector**
3. Position the sprite in the scene where you want it.
      
### Portal
1. Right-click Canvas to create a ```UI > Image``` (or 2D Object > Sprite), name it ```Sign```
2. Click on the Portal in the **Hierarchy** and drag the Portal sprite onto ```Image -> Source Image``` field in the **Inspector**
3. Position the sprite in the scene where you want it.
   
### Cat
1. Right-click Canvas to create a ```UI > Image``` (or 2D Object > Sprite), name it ```Cat```
2. Click on the Cat in the **Hierarchy** and drag the Cat sprite onto ```Image -> Source Image``` field in the **Inspector**
3. Position the sprite in the scene where you want it.

## Add and Assign Scripts
Add Scripts:

Place your StoryManager.cs, CatFader.cs, and Visibility.cs scripts in the Scripts folder.
Attach Scripts:

Attach StoryManager to an empty GameObject (e.g., right-click Hierarchy > Create Empty > name it GameManager).
Attach CatFader to the CatImage GameObject.
Attach UIImageToggle (from Visibility.cs) to any UI element you want to toggle (e.g., Fox, Sign, Portal).
5. Link Inspector Fields
Select the GameObject with StoryManager:
Drag the TextMeshPro text object to the storyText field.
Drag the left and right arrow Images to leftArrow and rightArrow.
Drag the left and right Button components to leftButton and rightButton.
For CatFader, drag the CatImage UI Image to the catImage field.
For UIImageToggle, drag the relevant UI Image (e.g., Fox, Sign, Portal) to the uiImage field.
6. Set Up OnClick Events
Select LeftButton in the Hierarchy:

In the Inspector, scroll to the Button component’s “OnClick()” section.
Click the “+” to add a new event.
Drag the GameObject with StoryManager into the object field.
Select StoryManager -> PreviousPanel() from the dropdown.
Repeat for RightButton, but select StoryManager -> NextPanel().

For any toggle button (e.g., to show/hide Fox, Sign, Portal), add an OnClick event and select UIImageToggle -> ToggleImageVisibility().

7. Fill in Story Content
In the Inspector, select the GameObject with StoryManager.
In the storyPanels array, enter your story text chunks (one per panel).
Example:
8. Test and Adjust
Press Play to test navigation, portal visibility, cat fading, and toggling of Fox, Sign, etc.
Adjust positions, colors, and sprites as needed for your desired look.
Tip:
If you want to see two Inspector windows at once, right-click the Inspector tab and select “Add Tab > Inspector,” then lock one Inspector to a GameObject and use the other for navigation.

Let me know if you want a sample Unity hierarchy screenshot, more details on any step, or a sample scene file!
