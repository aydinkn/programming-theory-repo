# Introduction
This prototype is for Unity's programming theory which is about the 4 pillars of OOP

## Player
In the game, there is a blue cube that the player controls. Player can move with **A** and **B** keys and it can shoot a bullet with **SpaceBar**.

## Enemies
There are 2 types of enemies.
Green boxes are basic **enemies**. They can move left and right and they can shoot a bullet like the player.
Red spheres are **smart enemies**. They can do whatever the basic enemies does but they can also **dodge** the player's bullet. So shooting them is a little hard to success.

## Programming structure
There is a **Spaceship** abstract class. It has some common fields like **speed** (for move), **boundaryX** (to not move out of the screen), **projectilePrefab** and projectile related fields (for shooting).
It also defines **Move** abstract function so it's a must to define how to move in child classes. It also have **Shoot** virtual function to instantiate projectile and set the projectile properties.

**PlayerSpaceship** class inherited from **Spaceship** class. It **overrides Move function** so player can move with specific keys whenver you want. It also **overrides Shoot function** because player have **fireRate** implementation to not shoot all the time.
Of course it has **OnTriggerEnter** function. When enemy projectile collides, player dies and **GameOver** scene appears.

**EnemySpaceship** class inherited from **Spaceship** class. It **overrides Move function** so it can move left and right with a little distance from the starting point (some kind of cycle). It is using InvokeRepeating function with Shoot function as method name.
It also has **OnTriggerEnter** function. When player projectile collides, the enemy dies.

**SmartEnemySpaceship** class inherited from **EnemySpaceship** class. It has **FixedUpdate** method to calculate is neccessary the dodge. It is using **Physics.OverlapBox** function to calculate. Simply we put an invisible box in front of the object and
when overlaps the player projectile it set **dodging** field to true and **overrided Move** function takes care of **dodge move**. Of course **dodgeRate** implemented so if you can fast enough you can shoot them but be careful about enemy projectiles :) 

**Projectile** class has **speed** and **deadZone** fields. It also has **Speed** property so spaceships cannot set negative speed for projectiles because it doesn't make sense. It has **Move** function to move and check the deadzone with **IsInDeadZone** function. If it is in deadzone, it destroy itself

https://github.com/aydinkn/programming-theory-repo/assets/5111036/df1a8587-d280-4fcf-b0a5-6c720117451f
