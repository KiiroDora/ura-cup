--- WHAT IS THIS ? ---
A Horse Race Test inspired racing simulator. It is not fully automated, so I'm releasing it as a Unity project rather than a standalone build. You'll need to put in your own horses and racetracks if you want more than what's provided.

--- HOW DO I USE IT? ---
If you aren't planning on adding new horses or racetracks:
- Open the Unity project
- On the Project tab, open the Scenes folder. You can navigate racetracks by double-clicking each Scene (all Scenes are racetracks except "tp" which is used for navigation in the executable file).
- In the Scene of the racetrack you want to use, navigate the "Horses" section in the Hierarchy tab on the left part of the screen and open it. There should be a list of Horses in it.
- Right-click and delete all horses. 
- On the Project tab, navigate Horses > Prefabs. You can add any horse in any folder by dragging them from the Project tab to the Scene above. Wherever you place them will be their starting point.
- Do this for all racetracks you plan on using.
- On the toolbar at the top, click File > Build and Run. You can watch the races via the program that opens. You can also access the program by using the executable file inside the new build folder that will be created when you press Build and Run. 

--- WHAT IF I WANT TO MAKE MY OWN HORSES? ---
- Make a sprite for your horse (ideally 35x35 pixels.)
- Drag your sprite from the computer to the Sprites > horses folder in the Project tab.
- Click on the sprite, then on the Inspector, change Sprite Mode to single, Texture type to Sprite (2D and UI) and Pixels Per Unit to 50. Change Filter Mode to Point (no filter).
- In Project tab, go to Horses > Data.
- Copy and paste the Base scriptable object (blue cube with red parentheses icon)
- On the Inspector tab to the right, replace the Sprite "CRY_RaceReady" with your own sprite by dragging it from Sprites on top of the Sprite slot.
- Change the Horse Data section as you please.
- Guidelines: Speed, Stamina and Power must add up to 9 and no stat can be below 1.
- Go to Horses > Prefabs.
- Copy and paste the Horse prefab (that weird yellow thing).
- On Inspector, change Sprite Renderer's Sprite slot with your own horse's sprite.
- On Inspector, change Horse Behavior (Script)'s Horse slot to your own horse's data.
- Still on Inspector, navigate the Capsule Collider 2D and adjust its size to fit your horse's.
- Congrats! Now you can drag this Prefab in any racetrack Scene to add it as a participant to that race.

--- WHAT IF I WANT TO MAKE MY OWN RACETRACKS? ---
- Make a copy of any racetrack.
- Adjust the objects in the "Track" part in the Hierarchy tab as you please.
- Make a new button in the "tp" Scene by duplicating one of the buttons in the Canvas, then dragging it somewhere accessible in the scene. 
- Navigate to the Button part in the button's Inspector field, then change the On Click() part with "Track<some number>" to the name of your newly made Scene.
- On the top section, click File > Build Profile > Scene List and drag the Scene file inside the list that appears. Make sure it is below "tp".
- Build and Run. Your racetrack should appear once you click its button.
- There are a few intricacies that may not come to mind, so test the racetrack first by clicking the play button above it. If there is an error it will pop up on Console.
- General suggestions: 
 - If there are multiple starting gates, ensure each Gate object has the tag "Gate" in the inspector.
 - Similarly, make sure every Cheese object has the tag Cheese in case of collision errors with cheese.
 - Animated objects are nested inside each other. If you want to alter the size or position of it, simply alter the outermost object. Don't touch the others inside. It will look and act weird otherwise.
 - If you want to make an obstacle like the Minotaur, make sure its Capsule Collider 2D has Cheese on the Exclude Layers section, and that the Cheese object has the Cheese layer.

--- I ENCOUNTERED A PROBLEM AND DON'T KNOW WHAT TO DO EVEN AFTER READING THIS. ---
e-mail me at kiirodoradora@gmail.com and if I have the time I'll try and see if I can fix it or help you fix it!

--- I WANT TO IMPROVE THIS THING WITH MY OWN CODE. ---
Go ahead! The project is open source. However keep in mind if you somehow use this for like. Actual Real Life Gambling or something I am not liable for anything. This is meant to be strictly for fun.