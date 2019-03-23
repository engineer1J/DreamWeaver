// tutorial : https://www.youtube.com/watch?v=Q75C0kZhu80

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour {
    Quaternion _start, _end;

    float _angle = 90.0f;
    float _speed = 2.0f;
    // 시작 때 딜레이를 주기 위해
    public float _startTime = 0.0f;

    Vector3 force;

	// Use this for initialization
	void Start () {
        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // rigidbody에 힘을 가하는 경우 fixedUpdate사용
    private void FixedUpdate()
    {
        // 시작 딜레이
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    void ResetTimer() {
        _startTime = 0.0f;
    }

    //회전각 정하는 함수
    Quaternion PendulumRotation(float angle) {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if(angleZ > 100)
        {
            angleZ -= 360;
        }
        else if(angleZ < -100)
        {
            angleZ += 360;
        }
        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.x, pendulumRotation.y, angleZ);

        return pendulumRotation;

    }
}
