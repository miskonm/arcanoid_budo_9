using UnityEngine;

namespace Arkanoid.Utils
{
    public static class GizmosUtils
    {
        #region Public methods

        public static void DrawArc2D(Vector3 startPoint, Vector2 centerDirection, float minAngle, float maxAngle,
            float radius, int stepsCount = 15)
        {
            Vector2 defaultDirection = Vector2.up;
            Quaternion quaternion = Quaternion.FromToRotation(defaultDirection, centerDirection);
            Vector3 angles = quaternion.eulerAngles;

            float newMinAngle = minAngle - angles.z;
            float minAngleRad = newMinAngle * Mathf.Deg2Rad;
            Vector2 directionMin = new Vector2(Mathf.Sin(minAngleRad), Mathf.Cos(minAngleRad)).normalized * radius;
            Vector3 minEndPoint = startPoint + (Vector3)directionMin;
            Gizmos.DrawLine(startPoint, minEndPoint);

            float newMaxAngle = maxAngle - angles.z;
            float maxAngleRad = newMaxAngle * Mathf.Deg2Rad;
            Vector2 directionMax = new Vector2(Mathf.Sin(maxAngleRad), Mathf.Cos(maxAngleRad)).normalized * radius;
            Gizmos.DrawLine(startPoint, startPoint + (Vector3)directionMax);

            float angleDif = newMaxAngle - newMinAngle;
            float angleDegree = angleDif / stepsCount;
            Vector3 pointA = minEndPoint;
            float currentAngle = newMinAngle;
            for (int i = 0; i < stepsCount; i++)
            {
                currentAngle += angleDegree;
                float angleRad = currentAngle * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Sin(angleRad), Mathf.Cos(angleRad)).normalized * radius;
                Vector3 pointB = startPoint + (Vector3)direction;
                Gizmos.DrawLine(pointA, pointB);
                pointA = pointB;
            }
        }

        #endregion
    }
}