# Airhockey
*Simple Airhockey Game in Unity*

This is an airhockey game developed in Unity engine. It uses raycasts to set the position of the player's racket. Movement of the player, enemy and puck element
are performed using the physics implemented in Unity.

The enemy only has reactive properties and does not attack actively. The enemy can only move on the Z-axis. The position on this z-axis is set by the line drawn
between the puck and the enemy score location. The position of the enemy is where these two lines meet (puck - score axis, z-axis of enemy).

It should be noted that all axis haad to be frozen in place, to avoid aquard rotation and behaviour of the elements involved.
The puck has a physical material attached to it, which has no friction and a high "bouncyness". This achieves behaviour similar to real air hockey.

This game is engineered to work on pc and android.
