using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Silder class ����ϱ� ���� �߰��մϴ�.

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
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.

        }
    }
}
