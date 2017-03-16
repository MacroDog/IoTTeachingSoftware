using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public class FPSPlayerControl : MonoBehaviour
{
    public Behaviour[] comparetoDie;
    [SerializeField]
    private float m_GravityMultiplier = 1f;
    private CharacterController m_CharacterController;
    private Vector3 m_MoveDir = Vector3.zero;
    private Vector3 m_RotationDir = Vector3.zero;
    public Quaternion PitchAngleRange ;
    private Vector3 view_RotationDir;
    private float m_MoveFace = 5;
    private float m_JumpSpeed = 60;
    private float m_RotatityMultiplier = 1;
    private float view_RotatityMulitiplier = 1;
    [SerializeField]
    private Camera view;

    void Start()
    {
        Vector3 s = new Vector3(-60, 30, 0);
        //PitchAngleRange = Quaternion.Equals( s);
        m_CharacterController = this.GetComponent<CharacterController>();

    }
    void Awake()
    {

    }
    void Update()
    {
        if (m_CharacterController.isGrounded == true)
        {
            m_MoveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

            m_MoveDir = Vector3.Normalize(m_MoveDir) * m_MoveFace * Time.fixedDeltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                m_MoveDir.y = m_JumpSpeed * Time.fixedDeltaTime;
            }
        }
        else
        {
            m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
        }

        // m_MoveDir =new Vector3 (0, m_MoveDir.y,0);
        float _yRot = Input.GetAxis("Mouse X") * m_RotatityMultiplier;
        view_RotationDir.x = -Input.GetAxis("Mouse Y") * view_RotatityMulitiplier;
        m_RotationDir.y = _yRot;

    }
    void FixedUpdate()
    {
        transform.localRotation *= Quaternion.Euler(m_RotationDir);
       // Quaternion s = view.transform.localRotation;
        //s *= Quaternion.Euler(view_RotationDir);
       // Debug.Log(s.x);
        //if (s.x> PitchAngleRange.x&&s.x<PitchAngleRange.y)
        //{
        view.transform.localRotation *= Quaternion.Euler(view_RotationDir);
       // }
        
        m_CharacterController.Move(m_MoveDir);
    }
   // public void O

}
