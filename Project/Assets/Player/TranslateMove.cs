using UnityEngine;

public class TranslateMove : MonoBehaviour
{
    public float Speed = 0.3f;
    public float JumpForce = 1f;

    //даем возможность выбрать тэг пола.
    //так же убедитесь что ваш Player сам не относится к даному слою. 

    //!!!!Нацепите на него нестандартный Layer, например Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody _rb;
    private CapsuleCollider _collider; // теперь прийдется использовать CapsuleCollider
    //и удалите бокс коллайдер если он есть



    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указания.
        //то нужно заблочить поворот по осях X и Z
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //  Защита от дурака
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }

    void Update()
    {
        MovementLogic();
    }
    private void FixedUpdate()
    {
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // что бы скорость была стабильной в любом случае
        // и учитывая что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
        transform.Translate(movement * Speed * Time.deltaTime);
    }

}
