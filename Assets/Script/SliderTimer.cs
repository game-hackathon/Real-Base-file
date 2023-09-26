using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Silder class 사용하기 위해 추가합니다.

public class SliderTimer : MonoBehaviour
{
    public Slider slTimer;

    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            slTimer.value += Time.deltaTime;
            // 시간이 변경한 만큼 slider Value 변경을 합니다.

        }
    }
}
