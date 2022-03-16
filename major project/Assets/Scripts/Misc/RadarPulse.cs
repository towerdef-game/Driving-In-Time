using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadarPulse : MonoBehaviour
{
    public Transform sweepTransfrom;
    public float rotateSpeed = 180f;
    public float distanceOfRadar = 20;
    public float sizeOdBlips = 15;
    public bool playerDirection = true;
    public Transform player;
    public GameObject civilianPrefab;
    public GameObject enemyPrefab;
    public string greenTag = "NPC";
    public string redTag = "Enemy";

    private float widthOfTheRadar, heightOfTheRadar, widthOfTheBlip, heightOfTheBlip;

    void Start()
    {
        widthOfTheRadar = GetComponent<RectTransform>().rect.width;
        heightOfTheRadar = GetComponent<RectTransform>().rect.height;
        heightOfTheBlip = heightOfTheRadar * sizeOdBlips / 100;
        widthOfTheBlip = widthOfTheRadar * sizeOdBlips / 100;
    }

    void Update()
    {
        sweepTransfrom.eulerAngles -= new Vector3(0, 0, rotateSpeed * Time.deltaTime);
        RemoveBlips();
        DisplayBlips(redTag, enemyPrefab);
        DisplayBlips(greenTag, civilianPrefab);
    }

    private void DisplayBlips(string tag, GameObject blipPrefab)
    {
        Vector3 playerPosition = player.position;
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            float distToTarget = Vector3.Distance(targetPosition, playerPosition);

            if (distToTarget <= distanceOfRadar)
            {

                Vector3 normalisedTargetPosition = NormalisedPos(playerPosition, targetPosition);
                Vector2 positionOfBlip = CalculateAllBlipsPositions(normalisedTargetPosition);
                DrawBlipOnRadar(positionOfBlip, blipPrefab);
            }
        }
    }

    private void RemoveBlips()
    {
        GameObject[] allBlips = GameObject.FindGameObjectsWithTag("RadarBlip");
        foreach (GameObject blip in allBlips)
            Destroy(blip);
    }

    private Vector3 NormalisedPos(Vector3 positionOfPlayer, Vector3 positionOfTarget)
    {
        float normalisedTargetXPosition = (positionOfTarget.x - positionOfPlayer.x) / distanceOfRadar;
        float normalisedTargetZPosition = (positionOfTarget.z - positionOfPlayer.z) / distanceOfRadar;

        return new Vector3(normalisedTargetXPosition, 0, normalisedTargetZPosition);
    }

    private Vector2 CalculateAllBlipsPositions(Vector3 targetPositions)
    {
        float targetAngle = Mathf.Atan2(targetPositions.x, targetPositions.z) * Mathf.Rad2Deg;

        float playerAngle = playerDirection ? player.eulerAngles.y : 0;

        float degreeOfRadarAngle = targetAngle - playerAngle - 90;

        float normalisedDistanceToTarget = targetPositions.magnitude;
        float radiansAngle = degreeOfRadarAngle * Mathf.Deg2Rad;
        float blipPositionX = normalisedDistanceToTarget * Mathf.Cos(radiansAngle);
        float blipPositionY = normalisedDistanceToTarget * Mathf.Sin(radiansAngle);
   
        blipPositionX *= widthOfTheRadar * .5f;
        blipPositionY *= heightOfTheRadar * .5f;

        blipPositionX += (widthOfTheRadar * .5f) - widthOfTheBlip * .5f;
        blipPositionY += (heightOfTheRadar * .5f) - heightOfTheBlip * .5f;

        return new Vector2(blipPositionX, blipPositionY);
    }

    private void DrawBlipOnRadar(Vector2 position, GameObject blipPrefab)
    {
        GameObject blipAllPrefabs = (GameObject)Instantiate(blipPrefab);
        blipAllPrefabs.transform.SetParent(transform);
        RectTransform rectTransform = blipAllPrefabs.GetComponent<RectTransform>();
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, position.x, widthOfTheBlip);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, position.y, heightOfTheBlip);
    }
}
