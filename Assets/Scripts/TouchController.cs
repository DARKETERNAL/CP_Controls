using UnityEngine;

public class TouchController : BaseController
{
    private Vector3 targetLocation;
    private bool setTargetPosition;

    private float elapsedTime;

    protected override bool Firing
    {
        get
        {
            return Input.GetMouseButtonDown(1);
        }
    }

    protected override float MovementFactor
    {
        get
        {
            return 0.01F;
        }
    }

    protected override bool Moving
    {
        get
        {
            bool result = setTargetPosition;

            if (!result)
            {
                result = Input.GetMouseButtonDown(0);
            }

            return result;
        }
    }

    protected override bool Rotating
    {
        get
        {
            return false;
        }
    }

    protected override float RotationFactor
    {
        get
        {
            return 0F;
        }
    }

    protected override bool Running
    {
        get
        {
            return false;
        }
    }

    protected override void Move()
    {
        if (setTargetPosition)
        {
            float xVal = GetInterpolatedValue(transform.position.x, targetLocation.x);
            float zVal = GetInterpolatedValue(transform.position.z, targetLocation.z);

            elapsedTime += Time.deltaTime;

            transform.position = new Vector3(xVal, transform.position.y, zVal);

            if ((targetLocation - transform.position).magnitude <= 0.5F)
            {
                elapsedTime = 0F;
                setTargetPosition = false;
            }
        }
    }

    private float GetInterpolatedValue(float a, float b)
    {
        return Mathf.Lerp(a, b, MovementSpeed * MovementFactor * elapsedTime);
    }

    protected override void Update()
    {
        if (Moving && !setTargetPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                targetLocation = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(targetLocation);
                setTargetPosition = true;
            }
        }

        base.Update();
    }
}