using System.Collections;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playercam;
    public float throwForce = 10;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    // Start is called before the first frame update
    void Update()
    {
        // check distance entre objet et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        // si - ou = 2.5 unités de distance = on peut ramasser
        if (dist <= 1.9f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        // si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playercam;
            beingCarried = true;
        }
        // Si on porte l'objet
        if (beingCarried)
        {
            // si l'objet touche un mur / objet avec collider
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            //clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playercam.forward * throwForce);
            }
            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
