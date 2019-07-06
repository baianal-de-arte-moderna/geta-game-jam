using UnityEngine;

public class JumpOverObjectBehaviour : BaseBehaviour
{
    [SerializeField]
    private string jumpedOverObjectTag;

    private new Rigidbody rigidbody;
    private Vector3 rotationVector = new Vector3();

    private bool hasLookedAt = false;
    private bool hasJumped = false;
    private bool isAirBorn = false;

    private Vector3 initialPosition;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    public override bool InterruptChain()
    {
        return false;
    }

    public override bool IsActive()
    {
        return GameObject.FindWithTag(jumpedOverObjectTag) != null;
    }

    public override void Iterate()
    {
        if (!hasLookedAt)
        {
            hasLookedAt = true;

            GameObject jumpedOverObject = GameObject.FindWithTag(jumpedOverObjectTag);
            rotationVector.Set(jumpedOverObject.transform.position.x, transform.position.y, jumpedOverObject.transform.position.z);
            transform.LookAt(rotationVector);

            rigidbody.AddForce(transform.forward * 100f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(jumpedOverObjectTag) && !hasJumped)
        {
            hasJumped = true;
            isAirBorn = true;
            rigidbody.AddForce(transform.up * 225f);
            rigidbody.AddForce(transform.forward * 75f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAirBorn)
        {
            isAirBorn = false;
            rigidbody.AddForce(transform.forward * -75f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            hasLookedAt = false;
            hasJumped = false;
            isAirBorn = false;

            transform.position = initialPosition;

            rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnEnable()
    {
        hasLookedAt = false;
        hasJumped = false;
        isAirBorn = false;

        rigidbody.velocity = Vector3.zero;
    }
}
