using UnityEngine;

public class MiningSensor : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionRange = 20f;
    public LayerMask miningLayer;

    public GameObject sensorStrenght1Object;
    public GameObject sensorStrenght2Object;
    public GameObject sensorStrenght3Object;


    private void Update()
    {
        DetectNearbyMines();
    }

    private void DetectNearbyMines()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, detectionRange, miningLayer);

        foreach (Collider collider in colliders)
        {
            Vector3 minePosition = collider.transform.position;
            float distance = Vector3.Distance(playerTransform.position, minePosition);
            Debug.LogWarning("Distance: "+distance+" detectionRange "+ detectionRange );
            if (distance <= detectionRange / 3)
            {
                Debug.Log("Birinci Aşama: Yakın Mesafe Madeni Algıla");
                // Burada birinci aşama işlemleri yapabilirsiniz.
                ActiceDeactiveSensorStrenghts(true, true,true);

            }
            else if (distance <= (detectionRange / 3) * 2)
            {
                Debug.Log("İkinci Aşama: Orta Mesafe Madeni Algıla");
                // Burada ikinci aşama işlemleri yapabilirsiniz.
                ActiceDeactiveSensorStrenghts(false, true, true);


            }
            else if (distance <= detectionRange)
            {
                Debug.Log("Üçüncü Aşama: Uzak Mesafe Madeni Algıla");
                // Burada üçüncü aşama işlemleri yapabilirsiniz.
                ActiceDeactiveSensorStrenghts(false, false, true);

            }
            else
            {
                Debug.Log("Üçüncü Aşama: Uzak Mesafe Madeni Algıla");
                // Burada üçüncü aşama işlemleri yapabilirsiniz.
                ActiceDeactiveSensorStrenghts(false, false, false);

            }
        }
    }

    private void ActiceDeactiveSensorStrenghts(bool isActiveFirstSensorWave,bool isActiveSecondSensorWave, bool isActiveThirdSensorWave)
    {
        sensorStrenght1Object.SetActive(isActiveFirstSensorWave);
        sensorStrenght2Object.SetActive(isActiveSecondSensorWave);
        sensorStrenght3Object.SetActive(isActiveThirdSensorWave);
    }
}