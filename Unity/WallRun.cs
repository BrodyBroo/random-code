using System.Collections;
using UnityEngine;

public class WallRun : MonoBehaviour {
  public float wallDistance = 0.5f;
  public float wallRunGravity = 1f;
  public float wallRunJuumpForce = 10f;
  public float wallRunSpeed = 5f;
  public float wallRunDuration = 2f;
  public LayerMask wallLayer;

  private bool isWallRunning = false;
  private bool canWallRun = false;
  private float wallRunStartTime;

  private Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>)();
  }

  void Update() {
    CheckForWall();
    WallRunControl();
  }

  void CheckForWall() {
    RaycastHit hit;
    if(Physics.Raycast(transform.position, transform.right, out hit, wallDistance, wallLayer) || Physics.Raycast(transform.position, -transform.right, out hit, wallDistance, wallLayer()) {
      canWallRun = True;
    }
    else {
      canWallRun = false;
  }
}

void WallRunControl() {
  if(canWallRun && Input.GetKeyDown(KeyCode.Space)) {
    StartWallRun();
  }

  if(isWallRunning) {
    rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Acceleration);

    rb.velocity = transform.forward * wallRunSpeed;

    if(Time.time - wallRunStartTime >= wallRunDuration) {
      StopWallRun();
    }

    if(Input.GetKeyDown(KeyCode.Space)) {
      JumpOffWall();
    }
  }
}
void StartWallRun() {
  isWallRunning = true;
  wallRunStartTime = Time.time;
}
void StopWallRun() {
  isWallRunning = false;
}
void JumpOffWall() {
  rb.AddForce(Vector3.up * wallRunJumpForce, ForceMode.Impuse);
  StopWallRun();
}
