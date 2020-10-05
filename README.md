# PongClassicRecreation

![Image of gameplay](/PongGameplay.PNG)

Recreating the classic Pong in Unity, based on the skeleton project from "Awesome Inc U" : [Unity Pong tutorial](https://www.awesomeincu.com/tutorials/unity-pong/)
Completed in Unity 2019.3.0f5, all in C#.

# For Your Information
This project did not follow the tutorial above, and it is no longer being worked on (thus the v1.0 release). You are free to download the Unity package, or pick and choose from the Assets folder, but the usage therefrom must follow the constraints of the MIT license.

# Similarities
Each paddle is broken down into five separate 2D Box Colliders, each owning a Segment component (vars: angle and speed increase). The collision is raycasted from the ball to the paddle to check for the collision before it happens, removing the possibility of the ball passing through the paddle before the collision can be detected. Multiple past Pong recreations have tried to determine collisions by calculating the distance between the mid-point of the paddle to the ball to determine the angle, although this will not work for inversed numbers (back/top sides of the paddle).
