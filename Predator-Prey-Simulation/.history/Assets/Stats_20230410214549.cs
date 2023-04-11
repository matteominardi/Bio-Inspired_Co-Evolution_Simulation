using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    void Start() 
    { 
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 300, Color.red);
        print("ray " + ray);
        RaycastHit2D hit = new RaycastHit2D();

        print(Physics.Raycast(ray, out hit));
        if (Physics2D.Raycast(ray, Vector3.forward))
        {
            print("hit");
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "SelectableObject")
            {
                ISelectable selectedObject;
                if (hit.collider.gameObject.name == "Predator")
                {
                    selectedObject = hit.collider.gameObject.GetComponent<Predator>();
                }
                else
                {
                    selectedObject = hit.collider.gameObject.GetComponent<Prey>();
                }
                string health = selectedObject.Lifepoints.ToString();
                string fitness = selectedObject.Fitness.ToString();
                string energy = selectedObject.Energy.ToString();
                string speed = selectedObject.Speed.ToString();
                string alive = selectedObject.Alive.ToString();
                
                gameObject.transform.Find("txtHealth").GetComponent<UnityEngine.UI.Text>().text = health;


            }

            Debug.DrawRay(ray.origin, ray.direction * 300, Color.blue);
        }
    }
}
