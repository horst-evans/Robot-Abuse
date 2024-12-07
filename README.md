# Robot-Abuse
User can interact with and explore a semi-ragdolled robot who arms and legs can be detached and re-attached at will.

## Features:
### Camera Movement
Movement is controlled via the `ControlManager` script.
Users can adjust the speed of translation and the speed of rotation.
They can also adjust the target model, although for this project that is only the robot.

Use the WASD keys or the Arrow keys to pan the robot around the scene.
Use the IJKL keys to rotate the robot in place.
The Translation and Rotation inputs can occur simultaneously.

### Highlighting
Highlighting is controlled by the `Interactable` script.
Users can adjust the material used for highlighting. An outline material has been provided, which can furthur be modified in regards to outline color and weight.
Users can also adjust whether highlight is turned on at all, although for the purposes of this project it is always enabled on relevant gameobjects.

The Interactables script applies the highlight material as an additional material in the rendere for the attached renderer and all child renderers.

### Robot Mouse Movement
#### Torso
The user can hover over the torso (this will highlight the entire robot, see above). By clicking and dragging with the mouse, the entire robot base and any attached limbs (head or arms) will move too.
Detached limbs will not move.
#### Limbs
Limbs are detachable components of the robot that, once detached, are no longer associated with the main body. Current limbs are the Head and both Arms. Unlick the torso, dragging a limb will "pop" it off from the main body, and it will be independe.
To re-attach, bring the detached limb close to the original location. Once a minimum distance threshold is reached, the limb wil "pop" back on.

This functionaliy is controlled by the `Interactable` script. The snap point and snap threshold can be adjusted.

### Attach State
When the robot has all limbs attached, text in the top right will be green and say "Status: ATTACHED".

While even one limb is detached, the text will read "Status: DETACHED".

### Unit Tests
Any unit tests can be run from `TestRunner` tool (Window >> General >> Test Runner).

### Bonus Features
#### Ragdoll
The robot is a partial ragdoll, with the legs set up to be affected by gravity while attached to a kinematic torso. Move or rotate him to observe!

This is primarily setup by the `Ragdoll` tool (GameObject >> 3D Object >> Ragdoll), and is run by `Rigidbody` and `CharacterJoint` scripts. To disable ragdoll, remove the `CharacterJoint` scripts and set the associated `Rigidbody` to `isKinematic = true`.

#### Chatty
The robot has opinions on your actions unto its person! These opinions are controlled by the `Vocalize` script.

The user can set what he says for certain actions. An dialouge option is chosen at random when the associated action event is invoked. The `AudioSource` can also be set.

The user can also set the Jaw and JawSpeed. This controls the runtime mouth animation. Jawspeed is the open and close of the mouth in seconds.

### Running the project
This is a fairly simple project. Run the `RobotAbuse` scene to experience it in its entirety!
