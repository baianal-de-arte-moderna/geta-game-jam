using UnityEngine;

public class JumpOverObjectBehaviour : BaseBehaviour
{
    [SerializeField]
    private string jumpedOverObjectTag;

    [SerializeField]
    private float jumpForceUp;

    [SerializeField]
    private float jumpForceForward;

    private new Rigidbody rigidbody;
    private Vector3 rotationVector = new Vector3();

    private bool hasLookedAt = false;
    private bool hasJumped = false;
    private bool isAirBorn = false;
    private bool wasInactive = false;

    private Vector3 initialPosition;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    public override bool InterruptChain()
    {
        return true;
    }

    public override bool IsActive()
    {
        bool foundObject = GameObject.FindWithTag(jumpedOverObjectTag) != null;
        if (!foundObject)
        {
            wasInactive = true;
        }
        return foundObject || isAirBorn;
    }

    public override void Iterate()
    {
        if (wasInactive && !isAirBorn)
        {
            Reset();
        }

        if (!hasLookedAt)
        {
            hasLookedAt = true;

            GameObject jumpedOverObject = GameObject.FindWithTag(jumpedOverObjectTag);
            rotationVector.Set(jumpedOverObject.transform.position.x, transform.position.y, jumpedOverObject.transform.position.z);
            transform.LookAt(rotationVector);

            rigidbody.AddForce(transform.forward * 100f);
        }
    }

    private void Reset()
    {
        hasLookedAt = false;
        hasJumped = false;
        isAirBorn = false;

        rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(jumpedOverObjectTag) && !hasJumped)
        {
            hasJumped = true;
            isAirBorn = true;
            rigidbody.AddForce(transform.up * jumpForceUp);
            rigidbody.AddForce(transform.forward * jumpForceForward);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAirBorn)
        {
            isAirBorn = false;
            rigidbody.AddForce(transform.forward * -jumpForceForward);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Reset();
            transform.position = initialPosition;
        }
    }

    private void OnEnable()
    {
        Reset();
    }
}
