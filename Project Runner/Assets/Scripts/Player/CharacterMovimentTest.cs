using Unity.Cinemachine;
using UnityEngine;

public class CharacterMovimentTest : MonoBehaviour
{
    [AddComponentMenu("")] // Don't display in add component menu

    public bool useCharacterForward = false;
    public float turnSpeed = 10f;
    public KeyCode sprintJoystick = KeyCode.JoystickButton2;
    public KeyCode sprintKeyboard = KeyCode.Space;

    private float turnSpeedMultiplier;
    private float speed = 0f;
    private float direction = 0f;
    private bool isSprinting = false;
    private Animator anim;
    private Vector3 targetDirection;
    private Vector2 input;
    private Quaternion freeRotation;
    private float velocity;

    private Camera activeCamera;
    private CinemachineBrain cinemachineBrain;

    [SerializeField] private float timerentrepassos;
    [SerializeField] private float timerpassos;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Pega o CinemachineBrain da câmera principal
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            cinemachineBrain = mainCam.GetComponent<CinemachineBrain>();
            activeCamera = mainCam;
        }

        timerpassos = timerentrepassos;
    }

    void FixedUpdate()
    {
        if (cinemachineBrain != null && cinemachineBrain.ActiveVirtualCamera != null)
        {
            activeCamera = cinemachineBrain.OutputCamera;
        }

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        speed = useCharacterForward ? Mathf.Abs(input.x) + input.y : Mathf.Abs(input.x) + Mathf.Abs(input.y);
        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
        anim.SetFloat("Speed", speed);

        direction = (input.y < 0f && useCharacterForward) ? input.y : 0f;
        anim.SetFloat("Direction", direction);

        isSprinting = (Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && input != Vector2.zero && direction >= 0f;
        anim.SetBool("IsSprinting", isSprinting);

        UpdateTargetDirection();

        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            float differenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            float eulerY = transform.eulerAngles.y;

            if (differenceRotation < 0 || differenceRotation > 0)
                eulerY = freeRotation.eulerAngles.y;

            Vector3 euler = new Vector3(0, eulerY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        }
    }

    public void PlayerMorreu()
    {
        gameObject.SetActive(false);
    }

    public virtual void UpdateTargetDirection()
    {
        if (activeCamera == null) return;

        if (!useCharacterForward)
        {
            turnSpeedMultiplier = 1f;
            Vector3 forward = activeCamera.transform.forward;
            forward.y = 0f;

            Vector3 right = activeCamera.transform.right;
            right.y = 0f;

            targetDirection = input.x * right + input.y * forward;
        }
        else
        {
            turnSpeedMultiplier = 0.2f;
            Vector3 forward = transform.forward;
            forward.y = 0f;

            Vector3 right = transform.right;
            targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
        }
    }
}
