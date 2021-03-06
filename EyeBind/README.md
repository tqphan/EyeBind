#EyeBind 

####About:
EyeBind is an open source keyboard simulator for the [Tobii EyeX](http://www.tobii.com/en/eye-experience/eyex/). It simulates keyboard inputs based on where you look. To understand what EyeBind does, let's first try to understand what the Tobii EyeX does. To put it simply, the Tobii EyeX functions like a second mouse pointer, continuously generating coordinate points of the screen where the user is looking. A region on the screen can be defined so that when these "gaze points" overlap a partcular region, keyboard input is simulated. 

####Basic useful feature list:

* Assign various keyboard operations such as key down, key up, key press, and key toggle to any region on the screen.
* Assign keyboard bindings to eyes blinks (left and/or right eye!).
* Continuously move the mouse pointer to where you look.

####Video:

A video demonstration of EyeBind will be added in the near future...

####Usage Instructions:

Upon Launching EyeBind, the main window will appear:

![Image of EyeBind Main UI](https://raw.githubusercontent.com/tqphan/EyeBind/master/screenshots/EyeBindMainWindow.png)

Click on the **New Profile** button to create a new profile. An optional hotkey can be assigned to quickly switch to this particular profile.

![Image of EyeBind Profile Editor](https://raw.githubusercontent.com/tqphan/EyeBind/master/screenshots/EyeBindProfileEditor.png)

Click on the **New Gaze Region** button to create a "gaze-aware" window. 

![Image of EyeBind Gaze Region](https://raw.githubusercontent.com/tqphan/EyeBind/master/screenshots/EyeBindGazeRegion.png)

Initially, this "Gaze Region" does nothing more than changing colors when you look at it, so let's configure it to do something useful. Select the newly created "Gaze Region" and click on the **Edit Gaze Region** button to open up the "Gaze Region Editor."

![Image of EyeBind Gaze Editor](https://raw.githubusercontent.com/tqphan/EyeBind/master/screenshots/EyeBindRegionEditor-0.png)

In the "Gaze Region Editor" various options can be adjusted. Most options are self-explanatory; however, there are two important tabs that will be explained in details: **Gaze Enter Inputs** and **Gaze Exit Inputs**. The primary function of this software is to simulate keyboard inputs when the user *looks at* a region, and optionally, separate keyboard inputs can be simulated when the user *looks away* from a region. 

Under **Gaze Enter Inputs** tab is where you can define the keyboard inputs to be simulated when you *looks at* a region. Under **Gaze Exit Inputs** tab is where you can define the keyboard inputs to be simulated when you *looks away* from a region.


####Build Instructions:

The EyeBind solution should build in Vistual Studio 2013 without any tweaking required. Be sure to copy the appropriate [Tobii.EyeX.Client library](http://developer.tobii.com/downloads/) to the output directory. EyeBind uses several external open source libraries and all can be installed using [NuGet Packet Manager](https://www.nuget.org/). Scroll down to the end of this document for a complete list of external libraries.

####Download:

* This project is on [GitHub](https://github.com/tqphan/EyeBind), so let me know if I've mess up somewhere. 
* If you prefer not to build EyeBind yourself, the executable of the latest build can be found [here](https://github.com/tqphan/EyeBind/releases).

####Known Issues/Limitations:

* EyeBind's blink detection uses EyeX engine's IsValid property from the Eye Position Data Stream, which is rather limited. The IsValid property would return 'false' when it can't detect an iris. This means there's no way to differentiate when the user is blinking, rolling his eyes back, or dropping dead. Perhaps in a future update there will be an option that requires one eye to be opened in order to detect blinks more accurately.
* Keyboard and mouse simulation in EyeBind uses Windows API's [SendInput](https://msdn.microsoft.com/en-us/library/windows/desktop/ms646310%28v=vs.85%29.aspx) function, and its documentation states, "Applications are permitted to inject input only into applications that are at an equal or lesser integrity level." In other words, EyeBind needs to be executed with administrator privilege in order to function properly.

####Contact:

If you find EyeBind to be useful, send me an [e-mail](quoc@hush.ai). Feedbacks and features requests are also welcomed.

####Short-term goals:

* Add various animations to better indicate the delay times.
* Currently EyeBind is hard-coded to use the EyeX's Fixation Data Stream; however, in a future update, it will allow the user to choose from various data streams provided by the EyeX engine. 
* Translate physical eyeballs locations into keyboard bindings.
* ~~Add global keyboard hot-keys.~~
* UI improvements.
* Allow customizable Gaze Marker.

####Long-term goals:

* Gaze gestures (similar to [mouse gestures](http://en.wikipedia.org/wiki/Pointing_device_gesture)).
* ~~Allow greater visual customization of Gaze Regions (perhaps by using a HTML Renderer).~~

## Credits:

* [Windows Input Simulator](https://inputsimulator.codeplex.com/) for simulation of keyboard/mouse inputs.
* [globalmousekeyhook](https://github.com/gmamaladze/globalmousekeyhook) for global hotkeys detections.
* [HTML-Renderer](https://github.com/ArthurHub/HTML-Renderer) for HTML Rendering.
* [freesfx](http://www.freesfx.co.uk) for sound effects.
* [Icons](https://onedrive.live.com/redir?resid=A0415EEE6CA3D36B!1508&authkey=!ALK3PzR5nVnI4ro&ithint=file%2czip) by Zathras

