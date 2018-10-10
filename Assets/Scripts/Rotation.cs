using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    public GameObject objectMg;
    public Button ButtonRotate;
    public Button ButtonMove;
    public Button ButtonAnimation;
    public int angle = 10;
    public bool isRotate = true;
    private bool rotateStatus = false;
    private float rotateSpeed = 10f;
    private int rotationNumber = 0;
    private const int ROTATE_LIMIT = 1000;


    public void Up()
    {
        if (isRotate) 
        {
            objectMg.transform.Rotate(Vector3.right, angle, Space.World);
        }
        else
        {
            objectMg.transform.Translate(Vector3.up, Space.World);
        }
    }


    public void Down()
    {
        if (isRotate)
        {
            objectMg.transform.Rotate(Vector3.left, angle, Space.World);
        }
        else
        {
            objectMg.transform.Translate(Vector3.down, Space.World);
        }
    }


    public void Left()
    {
        if (isRotate)
        {
            objectMg.transform.Rotate(Vector3.up, angle, Space.World);         
        }
        else
        {
            objectMg.transform.Translate(Vector3.left, Space.World);
        }
    }


    public void Right()
    {
        if (isRotate)
        {
            objectMg.transform.Rotate(Vector3.down, angle, Space.World);
        }
        else
        {
            objectMg.transform.Translate(Vector3.right , Space.World);
        }
    }


    public void Rotasi()
    {
        Text text = ButtonAnimation.GetComponentInChildren(typeof(Text)) as Text;

        if (!rotateStatus)
        {
            rotateStatus = true;
            text.text = "Stop \n Animation";
        }
        else
        {
            rotateStatus = false;          
            text.text = "Animation";
        }
    }


    public void Rotate()
    {
        isRotate = true;
        Text text = ButtonRotate.GetComponentInChildren(typeof(Text)) as Text;
        text.color = new Color(192, 192, 192);
        Text text1 = ButtonMove.GetComponentInChildren(typeof(Text)) as Text;
        text1.color = Color.grey;
    }


    public void Move()
    {
        isRotate = false;
        Text text = ButtonRotate.GetComponentInChildren(typeof(Text)) as Text;
        text.color = Color.grey;
        Text text1 = ButtonMove.GetComponentInChildren(typeof(Text)) as Text;
        text1.color = new Color(192, 192, 192);
    }


    
    private void Update()
    {
        if (rotateStatus)
        {
            rotationNumber++;

            if (rotationNumber < ROTATE_LIMIT)
            {
                objectMg.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }
            else if (rotationNumber < 2 * ROTATE_LIMIT)
            {
                objectMg.transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
            }
            else if (rotationNumber < 3 * ROTATE_LIMIT)
            {
                objectMg.transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
            }
            else if (rotationNumber < 4 * ROTATE_LIMIT)
            {
                objectMg.transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
            }
            else
            {
                rotationNumber = 0;
            }
        }
    }
}
