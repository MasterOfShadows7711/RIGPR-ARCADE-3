using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    float yawAngle;
    float OrbityawAngle;

    int WorldSpeed;

    Vector3[] ModelSpaceVectices;
    // Start is called before the first frame update
    void Start()
    {

        MeshFilter MF = GetComponent<MeshFilter>();

        ModelSpaceVectices = MF.mesh.vertices;


    }

    // Update is called once per frame
    void Update()
    {

        Matrix4x4 ScaleMatrix = new Matrix4x4(
            new Vector3(1, 0, 0) * 1,
            new Vector3(0, 1, 0) * 1,
            new Vector3(0, 0, 1) * 1,
            Vector3.zero);

        yawAngle += Time.deltaTime / 25f; //1 = 24h 

        Vector3[] TransformedVertices = new Vector3[ModelSpaceVectices.Length];

        Matrix4x4 RotationMatrix = new Matrix4x4(
            new Vector3(Mathf.Cos(yawAngle), 0, -Mathf.Sin(yawAngle)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(yawAngle), 0, Mathf.Cos(yawAngle)),
            Vector3.zero);

        Matrix4x4 TranslationMatrix = new Matrix4x4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(5, 0, 0));

        OrbityawAngle += Time.deltaTime / 250;

        Matrix4x4 OrbitRotationMatrix = new Matrix4x4(
            new Vector3(Mathf.Cos(OrbityawAngle), 0, -Mathf.Sin(OrbityawAngle)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(OrbityawAngle), 0, Mathf.Cos(OrbityawAngle)),
            Vector3.zero);


        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = ScaleMatrix * ModelSpaceVectices[i];
            TransformedVertices[i] = RotationMatrix * TransformedVertices[i];
            TransformedVertices[i] = TranslationMatrix * TransformedVertices[i];
            TransformedVertices[i] = OrbitRotationMatrix * TransformedVertices[i];
        }

        //TranslationMatrix = new Matrix4BY4(
        //    new Vector3(1, 0, 0),
        //    new Vector3(0, 1, 0),
        //    new Vector3(0, 0, 1),
        //    new Vector3(15, 0, 0));




        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();

    }
}
