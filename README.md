# EyeBind 

####About:
EyeBind is an open source keyboard simulator for the [Tobii EyeX](http://www.tobii.com/en/eye-experience/eyex/). It simulates keyboard inputs based on where you look. To understand what EyeBind does, let's first try to understand what the Tobii EyeX does. To put it simply, the Tobii EyeX functions like a second mouse pointer, continuously generating coordinate points of the screen where the user is looking. A region on the screen can be defined so that when these "gaze points" overlap a partcular region, keyboard input is simulated. 

Binding keyboard operations to a region of the screen when certain input intersects with that region is nothing new. In fact, I have done it for years using my mouse and [AutoHotkey](http://ahkscript.org) even before owning an EyeX. However, the Tobii EyeX helps streamlined this process. 

####Basic useful feature list:

* Assign various keyboard operations such as key down, key up, key press, and key toggle to any region on the screen.
* Assign keyboard bindings to eyes blinks (left and/or right eye!).
* Continuously move the mouse pointer to where you look.

####Screenshots:
![Image of EyeBind Main UI](https://i.imgur.com/lQulZvN.png)
![Image of EyeBind General Settings](https://i.imgur.com/L7pB31m.png)

For more screenshots, [click here.](https://imgur.com/a/v1jjX/all)

####Video:

A video demonstration of EyeBind will be added in the near future.

####Short-term goals:

* Add various animations to better indicate the delay times.
* Currently EyeBind is hard-coded to use the EyeX's Fixation Data Stream; however, in a future update, it will allow the user to choose from various data streams provided by the EyeX engine. 
* Translate physical eyeballs locations into keyboard bindings.
* Add global keyboard hot-keys.  
* UI improvements.
* Allow customizable Gaze Marker.

####Long-term goals:

* Gaze gestures (similar to [mouse gestures](http://en.wikipedia.org/wiki/Pointing_device_gesture)).
* Allow greater visual customization of Gaze Regions (perhaps by using a HTML Renderer).

####Known Issues/Limitations:

* EyeBind's blink detection uses EyeX engine's IsValid property from the Eye Position Data Stream, which is rather limited. The IsValid property would return 'false' when it can't detect an iris. This means there's no way to differentiate when the user is blinking, rolling his eyes back, or dropping dead. Perhaps in a future update there will be an option that requires one eye to be opened in order to detect blinks more accurately.
* Keyboard and mouse simulation in EyeBind uses Windows API's [SendInput](https://msdn.microsoft.com/en-us/library/windows/desktop/ms646310%28v=vs.85%29.aspx) function, and its documentation states, "Applications are permitted to inject input only into applications that are at an equal or lesser integrity level." In other words, EyeBind needs to be executed with administrator privilege in order to function properly.

####Build Instructions:

The EyeBind solution should build in Vistual Studio 2013 without any tweaking required. Be sure to copy the appropriate [Tobii.EyeX.Client library](http://developer.tobii.com/downloads/) to the output directory.

####Download:

* This project is on [GitHub](https://github.com/tqphan/EyeBind), so let me know if I've mess up somewhere. 
* If you prefer not to build EyeBind yourself, the executable of the latest build can be found [here](https://github.com/tqphan/EyeBind/releases).

####Contact:

If you find EyeBind to be useful, send me an [e-mail](quoc@hush.ai) so I know my time wasn't wasted. Feedbacks and features requests are also welcomed. 
I coded EyeBind primarily for myself, but that isn't entirely true since many of the features in EyeBind would have been hard-coded if it was created purely out of self-interest. The other reason why EyeBind exists is because I find proprietary solutions, especially ones marketed towards disabled users, to be over priced. Hopefully, this will help disabled gamers who can't afford them.

## Props to other open source projects used in EyeBind:

* [Windows Input Simulator](https://inputsimulator.codeplex.com/) for simulation of keyboard/mouse inputs.
* [freesfx](http://www.freesfx.co.uk) for sound effects.
* [globalmousekeyhook](https://github.com/gmamaladze/globalmousekeyhook) for global hotkeys detections.


