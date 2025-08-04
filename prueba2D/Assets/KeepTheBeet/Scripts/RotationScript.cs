using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 75f;
    public bool clockwise = true;
    private KTBLogicScript logic;

    private bool firstMilestone;
    private bool secondMilestone;
    private float speedUpgrade = 0f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
    }

    void Update()
    {
        if (logic.remiIsAlive)
        {
            if (clockwise)
            {
                transform.Rotate(new Vector3(0, 0, -rotationSpeed - speedUpgrade) * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed + speedUpgrade) * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        

            if (logic.playerScore > 20) firstMilestone = true;
            if (logic.playerScore > 40) secondMilestone = true;
            if (firstMilestone)
            {
                firstMilestone = false;
                speedUpgrade = 25f;
            }
            if (secondMilestone)
            {
                secondMilestone = false;
                speedUpgrade = 50f;
            }
        }
    }
}
