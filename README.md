# Object-Pooling-Unity

## Basic object pooling script made for unity, that's easily added in any game.

This script is mainly put up here for me to be able to reuse it easily without opening older projects. 
However do feel free to use it to any degree you'd like


## How to use
* Create an empty script in your asset folder
* Copy the code from this GitHub to the c# script
* Make a private reference to the class 'Pool' with a name like for example: _bulletPool
* In the start function do this _bulletPool = new Pool(gameobject that you pool, amount of items in the pool, transform)
* For best practices make the transform reference an object that's empty with a name like "Pool_BulletHolder"
* After that simply initate the object by doing var object = _objectPool.Get().GetComponent<>();
* Add the method in the DisableAfterTime file to disable said object so it goes back to the pool.
