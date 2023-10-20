using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// In the script of every object you want interactable, put ", IInteractable" after MonoBehavior and call the Interact void there
interface IInteractable
{
    public void Interact();
}


public class CameraMechanics : MonoBehaviour
{
    [SerializeField] InputManager input;

    public Transform InteractorSource;
    public float InteractRange = 10f;

    void Awake()
    {
        input = gameObject.transform.parent.GetComponent<InputManager>();

        InteractorSource = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.interactInput)
        {


            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit info, InteractRange)) {
                Debug.Log(info.transform.name);

                if(info.collider.TryGetComponent(out IInteractable interactableObj))
                {
                    interactableObj.Interact();
                }
            }
        }
    }




}
