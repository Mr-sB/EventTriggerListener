# EventTriggerListener
Listen unity event, such as click, drag, pointer down/up. Also apply to 3d game object!

# Usage
* First of all, your scene must have an unity EventSystem game object.
* If you want to listen 3d game object's event like UI event, your camera which render 3d game object must add Physic Raycaster component, and the 3d game object must add Collider conponent.
* If you need a blank UI to listen event, you can use EventGraphic component which will not interrupt batch.
